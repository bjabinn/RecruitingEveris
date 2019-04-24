﻿using System;

namespace Recruiting.Application.Graph.ViewModels
{
    public class CuentaTokenViewModel
    {
        public int CuentaTokenId { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaExpiracion { get; set; }
        public DateTime? FechaCreacionToken { get; set; }
        public DateTime? FechaExpiracionToken { get; set; }

    }
}