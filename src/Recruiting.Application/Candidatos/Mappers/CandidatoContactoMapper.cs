using Recruiting.Application.Candidatos.ViewModels;
using Recruiting.Business.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Recruiting.Application.Candidatos.Mappers
{
    public static class CandidatoContactoMapper
    {
        #region Mapper
        
        public static IEnumerable<CreateEditRowContactoCandidatoViewModel> ConvertToCreateEditRowContactoCandidatoViewModel(this IEnumerable<CandidatoContacto> candidatoContactoList)
        {
            var response = (candidatoContactoList == null)
                ? new List<CreateEditRowContactoCandidatoViewModel>()
                : candidatoContactoList.Select(x => x.ConvertToCreateEditRowContactoCandidatoViewModel()).ToList();

            return response;
        }

        public static void UpdateCandidatoContacto(this CandidatoContacto candidatoContacto, CreateEditRowContactoCandidatoViewModel viewModel)
        {
            
            candidatoContacto.CandidatoContactoId = (int)viewModel.CandidatoContactoId;
            candidatoContacto.CandidatoId = viewModel.CandidatoId;
            candidatoContacto.Contacto = viewModel.ValorContacto;
            candidatoContacto.IsActivo = true;
            candidatoContacto.TipoMedioContactoId = viewModel.TipoMedioContactoId;
        }

        #region Private Methods

        private static CreateEditRowContactoCandidatoViewModel ConvertToCreateEditRowContactoCandidatoViewModel(this CandidatoContacto candidatoContacto)
        {
            return new CreateEditRowContactoCandidatoViewModel()
            {
                CandidatoContactoId = candidatoContacto.CandidatoContactoId,
                TipoMedioContactoId = candidatoContacto.TipoMedioContactoId,
                ValorContacto = candidatoContacto.Contacto.Replace(" ", ""),
                CandidatoId = candidatoContacto.CandidatoId,
                TipoMedioContacto = candidatoContacto.TipoMedioContacto.Nombre
            };
        }

        #endregion
        
        #endregion
    }
}
