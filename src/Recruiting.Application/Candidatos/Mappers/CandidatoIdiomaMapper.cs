using Recruiting.Application.Candidatos.ViewModels;
using Recruiting.Business.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Recruiting.Application.Candidatos.Mappers
{
    public static class CandidatoIdiomaMapper
    {
        #region Mapper

        public static IEnumerable<CreateEditRowIdiomaCandidatoViewModel> ConvertToCreateEditRowIdiomaCandidatoViewModel(this IEnumerable<CandidatoIdioma> candidatoIdiomaList)
        {
            var response = (candidatoIdiomaList == null)
                ? new List<CreateEditRowIdiomaCandidatoViewModel>()
                : candidatoIdiomaList.Select(x => x.ConvertToCreateEditRowIdiomaCandidatoViewModel()).ToList();

            return response;
        }

        public static void UpdateCandidatoIdioma(this CandidatoIdioma candidatoIdioma, CreateEditRowIdiomaCandidatoViewModel viewModel)
        {
            if (viewModel.CandidatoIdiomasId != null)
            {
                candidatoIdioma.CandidatoIdiomasId = (int)viewModel.CandidatoIdiomasId;
            }
            candidatoIdioma.CandidatoId = viewModel.CandidatoId;
            candidatoIdioma.IdiomaId = viewModel.IdiomaId;
            candidatoIdioma.NivelIdiomaId = viewModel.NivelIdiomaId;
        }

        #region Private Methods

        private static CreateEditRowIdiomaCandidatoViewModel ConvertToCreateEditRowIdiomaCandidatoViewModel(this CandidatoIdioma candidatoIdioma)
        {
            return new CreateEditRowIdiomaCandidatoViewModel()
            {
                CandidatoIdiomasId = candidatoIdioma.CandidatoIdiomasId,
                CandidatoId = candidatoIdioma.CandidatoId,
                IdiomaId = candidatoIdioma.IdiomaId,
                NivelIdiomaId = candidatoIdioma.NivelIdiomaId,
                Idioma = candidatoIdioma.Idioma.Nombre,
                NivelIdioma = candidatoIdioma.NivelIdioma.Nombre
            };
        }

        #endregion

        #endregion
    }
}
