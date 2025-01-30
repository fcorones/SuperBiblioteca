﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BibliotecaDeClasesWinformYBlazor.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string ContraseñaHasheada { get; set; } = string.Empty;

        public string RolNombre { get; set; } = string.Empty;

        public bool Eliminado { get; set; } = false;

    }//hacer el winform del FormCrearUsuario y ver si se postea bien, segun la API ya anda bien
}
