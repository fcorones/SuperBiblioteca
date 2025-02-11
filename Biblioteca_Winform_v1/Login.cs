using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows.Forms;

namespace Biblioteca_Winform_v1
{
    public partial class Login : Form
    {
        private readonly AuthContext _authContext;
        public Login(AuthContext authContext)
        {
            InitializeComponent();
            _authContext = authContext;
        }

        private async void btnIniciar_Click(object sender, EventArgs e)
        {
            var email = txtUsuarioEmail.Text.Trim();
            var contraseña = txtContraseña.Text.Trim();

            // Validar si el campo email contiene un '@'
            if (!EsEmailValido(email))
            {
                MostrarMensaje("El campo Usuario debe contener un email válido para acceder como administrador.", "Validación de Email");
                return;
            }

            // Mostrar el panel de carga
            MostrarCargando(true);

            try
            {
                var client = BibliotecaDeClasesWinformYBlazor.HttpClientProvider.GetHttpClient();
                var loginData = new { Email = email, Contraseña = contraseña };
                var content = new StringContent(JsonSerializer.Serialize(loginData), Encoding.UTF8, "application/json");

                var response = await client.PostAsync("api/Usuarios/login", content);

                if (response.StatusCode == System.Net.HttpStatusCode.Forbidden)
                {
                    MostrarMensaje("No tienes permisos para acceder a esta aplicación.", "Acceso denegado");
                    return;
                }

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var tokenResponse = JsonSerializer.Deserialize<TokenResponse>(jsonResponse);

                    if (string.IsNullOrEmpty(tokenResponse?.Token))
                    {
                        MostrarMensaje("El token recibido es inválido o está vacío.", "Error");
                        return;
                    }

                    var handler = new JwtSecurityTokenHandler();
                    JwtSecurityToken token;

                    try
                    {
                        token = handler.ReadJwtToken(tokenResponse.Token);
                    }
                    catch (Exception ex)
                    {
                        MostrarMensaje($"Error al decodificar el token: {ex.Message}", "Error");
                        return;
                    }

                    var roleClaim = token.Claims.FirstOrDefault(c => c.Type == "role")?.Value;

                    switch (roleClaim)
                    {
                        case "ADMIN":
                            _authContext.UserToken = tokenResponse.Token;
                            AbrirFormPrincipal();
                            break;

                        case "USUARIO":
                            MostrarMensaje("No tienes permisos para acceder a esta aplicación.", "Acceso denegado");
                            break;

                        default:
                            MostrarMensaje("Rol no reconocido. Acceso denegado.", "Error");
                            break;
                    }
                }
                else
                {
                    MostrarMensaje("Inicio de sesión fallido. Verifica tus credenciales.", "Error");
                }
            }
            catch (Exception ex)
            {
                MostrarMensaje($"Error al intentar iniciar sesión: {ex.Message}", "Error");
            }
            finally
            {
                // Ocultar el panel de carga
                MostrarCargando(false);
            }
        }


        private void MostrarCargando(bool mostrar)
        {
            panelCargando.Visible = mostrar;
            panelCargando.BringToFront(); // Asegurarse de que esté encima de otros controles
            Application.DoEvents(); // Actualizar la interfaz gráfica inmediatamente
        }

        private bool EsEmailValido(string email)
        {
            // Verifica si el email contiene un '@' y no está vacío
            return !string.IsNullOrWhiteSpace(email) && email.Contains("@");
        }

        private void AbrirFormPrincipal()
        {
            var form1 = new Form1();
            this.Hide();
            form1.Show();
        }

        private void MostrarMensaje(string mensaje, string titulo)
        {
            MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void txtContraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnIniciar_Click(sender, e);
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }

    public class TokenResponse
    {
        [JsonPropertyName("token")]
        public string Token { get; set; }
    }
}
