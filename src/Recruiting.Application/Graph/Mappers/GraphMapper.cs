using Recruiting.Application.Graph.ViewModels;
using Recruiting.Business.Entities;

namespace Recruiting.Application.Graph.Mappers
{
    public static class GraphMapper
    {
        #region Mapper
        public static CuentaTokenViewModel ConvertToCuentaTokenViewModel(this CuentaToken token)
        { 
            var cuentaTokenViewModel = new CuentaTokenViewModel()
            {
                CuentaTokenId = token.CuentaTokenId,
                Email = token.Email,
                Token = token.Token,
                FechaCreacion = token.FechaCreacion,
                FechaExpiracion = token.FechaExpiracion,
                FechaCreacionToken = token.FechaCreacionToken,
                FechaExpiracionToken = token.FechaExpiracionToken
                
            };

            return cuentaTokenViewModel;
        }

     

        #region Private Methods

     


        #endregion

        #endregion
    }
}
