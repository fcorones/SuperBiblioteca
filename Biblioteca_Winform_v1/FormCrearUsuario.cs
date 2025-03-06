using BibliotecaDeClasesWinformYBlazor.Models;
using BibliotecaDeClasesWinformYBlazor.Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Biblioteca_Winform_v1
{
    public partial class FormCrearUsuario : Form
    {
        private readonly UsuarioService _usuarioService;

        private Usuario _usuarioEnEdicion;

        public FormCrearUsuario()
        {
            InitializeComponent();
        }

        public FormCrearUsuario(UsuarioService usuarioService)
        {
            InitializeComponent();
            _usuarioService = usuarioService;

            txtId_Usuario.Enabled = false;
            txtId_Usuario.Text = "0";

            chkCambiarContraseña.Visible = false;
        }


        public FormCrearUsuario(UsuarioService usuarioService, Usuario usuarioEnEdicion = null) : this()
        {
            _usuarioService = usuarioService;
            _usuarioEnEdicion = usuarioEnEdicion;


            chkCambiarContraseña.CheckedChanged += (s, e) =>
            {
                txtContraseña_Usuario.Enabled = chkCambiarContraseña.Checked;
                if (!chkCambiarContraseña.Checked)
                {
                    txtContraseña_Usuario.Text = string.Empty; // Limpiar el campo si se desmarca
                }
            };

            if (_usuarioEnEdicion != null) // Modo modificar
            {
                txtId_Usuario.Text = _usuarioEnEdicion.Id.ToString();
                txtId_Usuario.Enabled = false; // ID no editable
                txtNombre_Usuario.Text = _usuarioEnEdicion.Nombre;
                txtEmail_Usuario.Text = _usuarioEnEdicion.Email;
                txtTelefono_Usuario.Text = _usuarioEnEdicion.Telefono;
                txtDireccion_Usuario.Text = _usuarioEnEdicion.Direccion;
                txtRol_Usuario.Text = _usuarioEnEdicion.RolNombre;
                txtContraseña_Usuario.Text = _usuarioEnEdicion.ContraseñaHasheada;
                // Configurar el campo de contraseña
                //txtContraseña_Usuario.Text = string.Empty; // Vaciar el campo
                chkCambiarContraseña.Checked = false; // Desmarcado por defecto
                txtContraseña_Usuario.Enabled = false; // Deshabilitar campo por defecto

            }
        }


        private async void btnGuardar_ClickAsync(object sender, EventArgs e)
        {
            try
            {
                // Validar que ningún campo esté vacío
                if (string.IsNullOrWhiteSpace(txtNombre_Usuario.Text))
                {
                    MessageBox.Show("El nombre es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (System.Text.RegularExpressions.Regex.IsMatch(txtNombre_Usuario.Text, @"\d"))
                {
                    MessageBox.Show("El nombre no puede contener números.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtNombre_Usuario.Text.Length > 30)
                {
                    MessageBox.Show("El nombre no puede tener más de 30 caracteres.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtEmail_Usuario.Text))
                {
                    MessageBox.Show("El email es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtTelefono_Usuario.Text))
                {
                    MessageBox.Show("El teléfono es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtTelefono_Usuario.Text.Length > 15)
                {
                    MessageBox.Show("El número de teléfono no puede tener más de 15 caracteres.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtDireccion_Usuario.Text))
                {
                    MessageBox.Show("La dirección es obligatoria.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtRol_Usuario.Text))
                {
                    MessageBox.Show("El rol es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validar que el rol sea ADMIN o USUARIO
                string rol = txtRol_Usuario.Text.Trim().ToUpper();
                if (rol != "ADMIN" && rol != "USUARIO")
                {
                    MessageBox.Show("El rol debe ser ADMIN o USUARIO.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validar que el email contenga un arroba
                if (!txtEmail_Usuario.Text.Contains("@"))
                {
                    MessageBox.Show("El email debe contener un arroba (@).", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtEmail_Usuario.Text.Length > 50)
                {
                    MessageBox.Show("El correo electrónico no puede superar los 50 caracteres.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validar que el teléfono solo contenga números y, opcionalmente, un '+'
                if (!System.Text.RegularExpressions.Regex.IsMatch(txtTelefono_Usuario.Text, @"^\+?[0-9]+$"))
                {
                    MessageBox.Show("El teléfono solo puede contener números y, opcionalmente, un '+'.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validar la contraseña si es un nuevo usuario o si se selecciona cambiarla
                if (_usuarioEnEdicion == null || chkCambiarContraseña.Checked)
                {
                    if (string.IsNullOrWhiteSpace(txtContraseña_Usuario.Text))
                    {
                        MessageBox.Show("La contraseña no puede estar vacía.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // Preparar el modelo del usuario
                var usuario = new Usuario
                {
                    Id = _usuarioEnEdicion?.Id ?? 0,
                    Nombre = txtNombre_Usuario.Text.Trim(),
                    Email = txtEmail_Usuario.Text.Trim(),
                    Telefono = txtTelefono_Usuario.Text.Trim(),
                    Direccion = txtDireccion_Usuario.Text.Trim(),
                    RolNombre = rol,
                    ContraseñaHasheada = chkCambiarContraseña.Checked || _usuarioEnEdicion == null
                        ? txtContraseña_Usuario.Text.Trim() // Enviar en texto plano si se cambia o es nuevo
                        : _usuarioEnEdicion.ContraseñaHasheada // Mantener el hash existente si no se cambia
                };

                if (_usuarioEnEdicion == null)
                {
                    // Crear nuevo usuario
                    await _usuarioService.CrearUsuarioAsync(usuario);
                    MessageBox.Show("Usuario creado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Modificar usuario existente
                    await _usuarioService.ModificarUsuarioAsync(usuario);
                    MessageBox.Show("Usuario modificado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }






        /*
         if (!int.TryParse(txtId_Usuario.Text, out int idUsuario))
                {
                    MessageBox.Show("El ID debe ser un número entero válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
         */
        /*
        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(password);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash); // Devuelve la contraseña hasheada en formato base64
            }
        }
        */
        private void chkCambiarContraseña_CheckedChanged(object sender, EventArgs e)
        {
            chkCambiarContraseña.CheckedChanged += (s, e) =>
            {
                txtContraseña_Usuario.Enabled = chkCambiarContraseña.Checked;
                if (!chkCambiarContraseña.Checked)
                {
                    txtContraseña_Usuario.Text = string.Empty; // Limpiar el campo si se desmarca
                }
            };

        }

        private void txtContraseña_Usuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
