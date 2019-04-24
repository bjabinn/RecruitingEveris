using Recruiting.Application.Candidatos.ViewModels;
using Recruiting.Business.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Recruiting.Application.Candidatos.Mappers
{
    public static class CandidatoExperienciaMapper
    {
        #region Mapper

        public static IEnumerable<CreateEditRowExperienciaCandidatoViewModel> ConvertToCreateEditRowExpCandidatoViewModel(this IEnumerable<CandidatoExperiencia> candidatoExperienciaList)
        {
            var response = (candidatoExperienciaList == null)
                ? new List<CreateEditRowExperienciaCandidatoViewModel>()
                : candidatoExperienciaList.Select(x => x.ConvertToCreateEditRowExperienciaCandidatoViewModel()).ToList();

            return response;
        }

        public static void UpdateCandidatoExperiencia(this CandidatoExperiencia candidatoExperiencia, CreateEditRowExperienciaCandidatoViewModel viewModel)
        {
            candidatoExperiencia.CandidatoExperienciaId = (int)viewModel.CandidatoExperienciaId;
            candidatoExperiencia.CandidatoId = viewModel.CandidatoId;
            candidatoExperiencia.TipoTecnologiaId = viewModel.TipoTecnologiaId;
            candidatoExperiencia.NivelTecnologiaId = viewModel.NivelTecnologiaId;
            candidatoExperiencia.Experiencia = viewModel.Experiencia;
        }

        #region Private Methods

        private static CreateEditRowExperienciaCandidatoViewModel ConvertToCreateEditRowExperienciaCandidatoViewModel(this CandidatoExperiencia candidatoExperiencia)
        {
            return new CreateEditRowExperienciaCandidatoViewModel()
            {
                CandidatoExperienciaId = candidatoExperiencia.CandidatoExperienciaId,
                Experiencia = candidatoExperiencia.Experiencia,
                TipoTecnologiaId = candidatoExperiencia.TipoTecnologiaId,
                NivelTecnologiaId = candidatoExperiencia.NivelTecnologiaId,
                CandidatoId = candidatoExperiencia.CandidatoId,
                TipoTecnologia = candidatoExperiencia.TipoTecnologia.Nombre,
                NivelTecnologia = candidatoExperiencia.NivelTecnologia.Nombre
            };
        }

        #endregion

        #endregion
    }
}
