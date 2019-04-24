﻿using Recruiting.Application.Base;
using Recruiting.Application.PersonasLibres.ViewModels;
using System.Collections.Generic;

namespace Recruiting.Application.PersonasLibres.Messages
{
    public class GetEmpleadosFenixResponse : ApplicationResponseBase
    {
        public IEnumerable<EmpleadoFenixRowViewModel> EmpleadoFenixRowViewModelList { get; set; }
        public int TotalElementos { get; set; }
    }
}
