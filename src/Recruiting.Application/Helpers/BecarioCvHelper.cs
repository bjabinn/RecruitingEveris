using Recruiting.Application.Becarios.Messages;
using Recruiting.Business.Repositories;
using System;

namespace Recruiting.Application.Helpers
{
    internal class BecarioCvHelper
    {
        internal DownloadCVResponse GetCVBecarioByBecarioId(IBecarioRepository becarioRepository, int becarioId)
        {
            var response = new DownloadCVResponse();

            try
            {
                var becario = becarioRepository.GetOne(x => x.BecarioId == becarioId);
                
                response.IsValid = true;
                response.UrlCV = becario.UrlCV;
                response.NombreCV = becario.NombreCV;
                response.BecarioId = becario.BecarioId;
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
