﻿using System;

namespace Recruiting.Application.Usuarios.ViewModels
{
    [Serializable]
    public class UsuarioRolViewModel
    {
        public int UsuarioId { get; set; }
        public int RolId { get; set; }
        public string RolNombre { get; set; }
        public bool ContieneRol { get; set; }
    }
}
