using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using BibliotecaDeClasesWinformYBlazor;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;


public class AuthContext : IAuthContext
{
    private readonly IJSRuntime _jsRuntime; //Permite interacción JavaScript par acceder al sessionStorage
    private readonly NavigationManager _navigationManager;
    private string _userToken;      //
    private string _userName;       //Datos extraidos del token
    private int _userId;            //
    private bool _isInitialized = false; // En desuso
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

    //Invoca al evento OnChange para notificar alos componentes que la autenticación cambió
    public void NotifyStateChanged() => OnChange?.Invoke(); 
    public string UserName => _userName;    // Devuelve nomrbe y Id almacenados
    public int UserId => _userId;           //

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
            //Creamos instancia del handler. Permite leer el token
            var handler = new JwtSecurityTokenHandler();    
            var token = handler.ReadJwtToken(_userToken); //Deserializamos el token y lo guardamos

            _userName = token.Claims.FirstOrDefault(c => c.Type == "unique_name")?.Value ?? "Usuario";  //
            _userId = int.Parse(token.Claims.FirstOrDefault(c => c.Type == "sub")?.Value ?? "0");       //
           /*                       Accedemos a los claims y extraemos la info del usuario              */                                                                        

            var expirationTime = token.ValidTo;
            ScheduleExpirationCheck(expirationTime); //Verificamos expiración del token

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
            // Programamos chequeo de expiración. Si expiró, llamamos a HandleTokenExpired
            _expirationTimer = new Timer(_ => HandleTokenExpired(), null, timeUntilExpiration, Timeout.InfiniteTimeSpan);
        }
    }

    private async void HandleTokenExpired()
    {
        try
        {   //Reestablece la auth como un Logout
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
        _userName = string.Empty;       //
        _userId = 0;                    // Parámetros a 0
        _expirationTimer?.Dispose();    //
        _expirationTimer = null;        //
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
        { //Toma el token desde el sessionStorage del navegador
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


    public async Task LogoutAsync() //Logout. Resetea a 0 la info y borra el token del sessionStorage
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