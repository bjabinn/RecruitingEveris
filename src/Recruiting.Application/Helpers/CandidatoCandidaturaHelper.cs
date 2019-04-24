using Recruiting.Application.Candidaturas.Messages;
using Recruiting.Business.Repositories;
using System;
using System.Linq;

namespace Recruiting.Application.Helpers
{
    internal class CandidatoCandidaturaHelper
    {
        internal DownloadCVResponse GetCVCandidaturaByCandidaturaId(ICandidaturaRepository candidaturaRepository, int candidaturaId)
        {
            var response = new DownloadCVResponse();

            try
            {
                var candidatura = candidaturaRepository.GetOne(x => x.CandidaturaId == candidaturaId);
                
                response.IsValid = true;
                response.UrlCV = candidatura.UrlCV;
                response.NombreCV = candidatura.NombreCV;
                response.CandidaturaId = candidatura.CandidaturaId;
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        internal DownloadCVResponse GetLastCVCandidaturaByCandidatoId(ICandidaturaRepository candidaturaRepository, int candidatoId)
        {
            var response = new DownloadCVResponse();

            try
            {
                var candidaturaId = candidaturaRepository.GetByCriteria(x => x.CandidatoId == candidatoId).Max(t => t.CandidaturaId);
                var candidatura = candidaturaRepository.GetOne(x => x.CandidaturaId == candidaturaId);
                

                response.IsValid = true;
                response.UrlCV = candidatura.UrlCV;
                response.NombreCV = candidatura.NombreCV;
                response.CandidaturaId = candidatura.CandidaturaId;
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }
    }
}
