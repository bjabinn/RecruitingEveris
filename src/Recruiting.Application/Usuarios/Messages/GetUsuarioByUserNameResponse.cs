﻿using Recruiting.Application.Base;
using Recruiting.Application.Usuarios.ViewModels;

namespace Recruiting.Application.Usuarios.Messages
{
    public class GetUsuarioByUserNameResponse : ApplicationResponseBase
    {
        public CreateEditUsuarioViewModel UsuarioViewModel { get; set; }
    }
}
