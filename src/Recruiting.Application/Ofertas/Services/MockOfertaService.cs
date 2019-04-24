using Recruiting.Application.Ofertas.Messages;
using Recruiting.Application.Ofertas.ViewModels;
using Recruiting.Business.BaseClasses.DataTable;
using System;
using System.Collections.Generic;

namespace Recruiting.Application.Ofertas.Services
{
    public class MockOfertaService : IOfertaService 
    {
        #region Constants

        private const int TOTAL_ELEMENTS = 32;

        #endregion
        
        public GetOfertasResponse GetOfertas(DataTableRequest request)
        {
            var ofertas = new List<OfertaRowViewModel>();
            var response = new GetOfertasResponse()
            {
                IsValid = true,
                OfertaViewModel = ofertas
            };

            for (var i = request.PageSize * request.PageNumber; (i < (request.PageSize * request.PageNumber + request.PageSize)) && (i <= TOTAL_ELEMENTS); i++)
            {
                ofertas.Add(new OfertaRowViewModel()
                {
                    OfertaId = (int) i ,
                    Nombre = string.Format("Nombre {0}", i),
                    Candidatos = (int)i,
                    Estado = string.Format("Estado {0}", i),
                    FechaPublicacion = DateTime.Now.AddDays((double)i)
                });
            }

            response.TotalElementos = TOTAL_ELEMENTS;

            return response;
        }

        public GetOfertaByIdResponse GetOfertaById(int ofertaId)
        {
            var response = new GetOfertaByIdResponse()
            {
                IsValid = true,
                OfertaViewModel = new CreateEditOfertaViewModel()
                {
                    OfertaId = ofertaId,
                    Nombre = string.Format("Nombre {0}", ofertaId),
                    Descripcion = string.Format("Descripcion {0}", ofertaId),
                    FechaPublicacion = DateTime.Now
                }
            };

            return response;
        }

        public SaveOfertaResponse SaveOferta(CreateEditOfertaViewModel ofertaViewModel)
        {
            var response = new SaveOfertaResponse()
            {
                IsValid = true,
                ErrorMessage ="",
                OfertaId = new Random().Next(0, 100)
            };

            return response;
        }

        public DeleteOfertaResponse DeleteOferta(int ofertaId)
        {
            var response = new DeleteOfertaResponse()
            {
                IsValid = true
            };

            return response;
        }

        public GetOfertasResponse GetOfertas()
        {
            throw new NotImplementedException();
        }

        public GetOfertasResponse GetOfertasByCentroUsuarioId(int CentroUsuarioId)
        {
            throw new NotImplementedException();
        }

        public GetOfertasExportToExcelResponse GetOfertasExportToExcel(DataTableRequest request)
        {
            throw new NotImplementedException();
        }

        public GetOfertasByNameAndCentroResponse GetOfertasByNameAndCentro(string textSearch, int? centroId)
        {
            throw new NotImplementedException();
        }
        public GetOfertasNombreIdResponse GetOfertasNombreId(int? centroId = null)
        {
            throw new NotImplementedException();
        }
    }
}
