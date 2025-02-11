using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using BibliotecaDeClasesWinformYBlazor;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;


public class AuthContext : IAuthContext
{
    private readonly IJSRuntime _jsRuntime;
    private readonly NavigationManager _navigationManager;
    private string _userToken;
    private string _userName;
    private int _userId;
    private bool _isInitialized = false;
    public event Action OnChange;

    public AuthContext(IJSRuntime jsRuntime, NavigationManager navigationManager)
    {
        _jsRuntime = jsRuntime;
        _navigationManager = navigationManager;
    }

    public string UserToken
    {
        get => _userToken;
        set
        {
            Console.WriteLine($"[AuthContext] Asignando nuevo token: {value}");
            _userToken = value;
            ExtractUserInfo();
            NotifyStateChanged();
        }
    }

    public void NotifyStateChanged() => OnChange?.Invoke();
    public string UserName => _userName;
    public int UserId => _userId;

    private Timer _expirationTimer;

    private void ExtractUserInfo()
    {
        Console.WriteLine("[AuthContext] Ejecutando ExtractUserInfo()");

        if (string.IsNullOrEmpty(_userToken))
        {
            ResetUserInfo();
            return;
        }

        try
        {
            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(_userToken);

            _userName = token.Claims.FirstOrDefault(c => c.Type == "unique_name")?.Value ?? "Usuario";
            _userId = int.Parse(token.Claims.FirstOrDefault(c => c.Type == "sub")?.Value ?? "0");

           
            var expirationTime = token.ValidTo;
            ScheduleExpirationCheck(expirationTime);

            Console.WriteLine($"[AuthContext] Nombre: {_userName}, ID: {_userId}, Expira: {expirationTime}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[AuthContext] Error: {ex.Message}");
            ResetUserInfo();
        }
    }

    private void ScheduleExpirationCheck(DateTime expirationTime)
    {
        _expirationTimer?.Dispose();

        var timeUntilExpiration = expirationTime - DateTime.UtcNow;

        if (timeUntilExpiration <= TimeSpan.Zero)
        {
            // Token ya expirado
            HandleTokenExpired();
        }
        else
        {
            // Programar chequeo de expiración
            _expirationTimer = new Timer(_ => HandleTokenExpired(), null, timeUntilExpiration, Timeout.InfiniteTimeSpan);
        }
    }

    private async void HandleTokenExpired()
    {
        try
        {  
            await LogoutAsync();

            await _jsRuntime.InvokeVoidAsync("alert", "Tu sesión ha expirado. Por favor inicia sesión nuevamente.");
       
            _navigationManager.NavigateTo("/login", forceLoad: true);
        }
        catch (TaskCanceledException)
        {
            
            Console.WriteLine("[AuthContext] La tarea fue cancelada durante el manejo de la expiración del token.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[AuthContext] Error inesperado: {ex.Message}");
        }
    }

    private void ResetUserInfo()
    {
        _userName = string.Empty;
        _userId = 0;
        _expirationTimer?.Dispose();
        _expirationTimer = null;
    }
    public async Task SaveTokenToLocalStorageAsync(string token)
    {
        Console.WriteLine($"[AuthContext] Guardando token en SessionStorage: {token}");
        await _jsRuntime.InvokeVoidAsync("sessionStorage.setItem", "UserToken", token);
        UserToken = token;
    }


    public async Task LoadTokenFromLocalStorageAsync()
    {
        try
        {
            var token = await _jsRuntime.InvokeAsync<string>("sessionStorage.getItem", "UserToken");
            Console.WriteLine($"[AuthContext] Token cargado desde SessionStorage: {token}");

            if (!string.IsNullOrEmpty(token))
            {
                UserToken = token;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[AuthContext] Error al cargar el token desde SessionStorage: {ex.Message}");
        }
    }


    public async Task LogoutAsync()
    {
        Console.WriteLine("[AuthContext] Cerrando sesión. Eliminando token de SessionStorage.");
        await _jsRuntime.InvokeVoidAsync("sessionStorage.removeItem", "UserToken");
        _userToken = string.Empty;
        ResetUserInfo();
        NotifyStateChanged(); // Notificar a los componentes que el estado ha cambiado
    }


    public void Initialize()
    {
        Console.WriteLine("[AuthContext] Inicializando AuthContext.");
        _isInitialized = true;
    }
}