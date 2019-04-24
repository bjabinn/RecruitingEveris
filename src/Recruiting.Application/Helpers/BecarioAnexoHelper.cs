using Recruiting.Application.Becarios.Messages;
using Recruiting.Business.Repositories;
using System;

namespace Recruiting.Application.Helpers
{
    internal class BecarioAnexoHelper
    {
        internal DownloadAnexoResponse GetAnexoBecarioByBecarioId(IBecarioRepository becarioRepository, int becarioId)
        {
            var response = new DownloadAnexoResponse();

            try
            {
                var becario = becarioRepository.GetOne(x => x.BecarioId == becarioId);
                
                response.IsValid = true;
                response.UrlAnexo = becario.UrlAnexo;
                response.NombreAnexo = becario.NombreAnexo;
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
