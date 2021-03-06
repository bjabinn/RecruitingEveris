﻿using System;

namespace Recruiting.Application.FunnelProcesos.ViewModels
{
    public class DesgloseCategoriaViewModel
    {
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public int? TecnologiaId { get; set; }
        public int? CategoriaId { get; set; }
        public string NombreCategoria { get; set; }
        public int? CentroIdUsuario { get; set; }
        public DatosFiltradoCVViewModel DatosFiltradoCV { get; set; }
        public DatosEntrevistasViewModel DatosEntrevistas { get; set; }      
        public DatosCartaOfertaViewModel DatosCartaOferta { get; set; }

    }
}
