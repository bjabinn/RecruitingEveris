﻿using System.Collections.Generic;
using System.Web.Mvc;

namespace Recruiting.Application.PersonasLibres.ViewModels
{
    public class PersonasLibresListCategoriaLineaCeldaviewModel
    {
        public IEnumerable<SelectListItem> ListCategoria { get; set; }
        public IEnumerable<SelectListItem> ListLinea { get; set; }
        public IEnumerable<SelectListItem> ListCelda { get; set; }
    }
}