using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using BibliotecaDeClasesWinformYBlazor;
using Microsoft.JSInterop;

public class AuthContext : IAuthContext
{
    private readonly IJSRuntime _jsRuntime;
    private string _userToken;
    private string _userName;
    private int _userId;
    private bool _isInitialized = false;
    public event Action OnChange;

    public AuthContext(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
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

    private void ExtractUserInfo()
    {
        Console.WriteLine("[AuthContext] Ejecutando ExtractUserInfo()");

        if (string.IsNullOrEmpty(_userToken))
        {
            Console.WriteLine("[AuthContext] No hay token. Reseteando UserName y UserId.");
            _userName = string.Empty;
            _userId = 0;
            return;
        }

        try
        {
            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(_userToken);

            _userName = token.Claims.FirstOrDefault(c => c.Type == "unique_name")?.Value ?? "Usuario";
            _userId = int.Parse(token.Claims.FirstOrDefault(c => c.Type == "sub")?.Value ?? "0");

            Console.WriteLine($"[AuthContext] Nombre extraído del token: {_userName}");
            Console.WriteLine($"[AuthContext] UserId extraído del token: {_userId}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[AuthContext] Error al leer el token: {ex.Message}");
        }
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
        _userName = string.Empty;
        _userId = 0;
        NotifyStateChanged(); // Notificar a los componentes que el estado ha cambiado
    }


    public void Initialize()
    {
        Console.WriteLine("[AuthContext] Inicializando AuthContext.");
        _isInitialized = true;
    }
}