using Recruiting.Application.Oficinas.Mappers;
using Recruiting.Application.Oficinas.Messages;
using Recruiting.Application.Oficinas.ViewModels;
using Recruiting.Business.Entities;
using Recruiting.Business.Repositories;
using Recruiting.Data.EntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Recruiting.Application.Oficinas.Services
{
    public class OficinaService : IOficinaService
    {
        #region Fields

        private readonly IOficinaRepository _oficinaRepository;

        #endregion

        #region Constructors

        public OficinaService(IOficinaRepository oficinaRepository)
        {
            _oficinaRepository = oficinaRepository;
        }

        #endregion

        #region IOficinaService

        public GetOficinasResponse GetOficinas()
        {
            var response = new GetOficinasResponse();

            try
            {
                var oficinaList = _oficinaRepository
                                  .GetByCriteria(x => x.IsActivo)
                                  .OrderBy(p => p.Nombre)
                                  .ToList();

                var listaDeOficinasViewModel = oficinaList.ConvertToDatosOficinaViewModel();

                var selectList = new System.Web.Mvc.SelectList(listaDeOficinasViewModel, "OficinaId", "Nombre");

                response.ListaOficinasIdNombre = selectList;

                response.IsValid = true;
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }


        public GetOficinasResponse GetOficinasByCentro(int centroId)
        {
            var response = new GetOficinasResponse();
            var _correoPlantillaRepository = new CorreoPlantillaRepository();

            try
            {
                var oficinaListTemp = _oficinaRepository
                                  .GetByCriteria(x => x.IsActivo && x.Centro == centroId)
                                  .OrderBy(p => p.Nombre)
                                  .ToList();

                var oficinaList = new List<Oficina>();

                foreach (var oficina in oficinaListTemp)
                {
                    var listaCorreoOficina = _correoPlantillaRepository.GetByCriteria(x => x.IsActivo && x.OficinaId == oficina.OficinaId);
                    if (listaCorreoOficina.Count() > 0)
                    {
                        oficinaList.Add(oficina);
                    }
                }

                var listaDeOficinasViewModel = oficinaList.ConvertToDatosOficinaViewModel();

                var listaDeOficinasViewModelConCentroGenerico = new List<OficinaViewModel>();
                var oficinaGenerica = new OficinaViewModel()
                {
                    OficinaId = null,
                    Nombre = "Genérica",
                    Centro = null
                };
                listaDeOficinasViewModelConCentroGenerico.Add(oficinaGenerica);
                listaDeOficinasViewModelConCentroGenerico.AddRange(listaDeOficinasViewModel);

                var selectList = new System.Web.Mvc.SelectList(listaDeOficinasViewModelConCentroGenerico, "OficinaId", "Nombre");

                response.ListaOficinasIdNombre = selectList;

                response.IsValid = true;
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }



        #endregion

        #region Private Methods


        #endregion
    }
}
