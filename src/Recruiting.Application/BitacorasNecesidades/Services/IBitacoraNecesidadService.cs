using Recruiting.Application.BitacorasNecesidades.Messages;
using Recruiting.Application.BitacorasNecesidades.ViewModels;
using Recruiting.Business.BaseClasses.DataTable;

namespace Recruiting.Application.BitacorasNecesidades.Services
{
    public interface IBitacoraNecesidadService
    {
        #region QueryRequest
        
        #endregion

        #region ActionRequest
        GenerateBitacoraNecesidadResponse GenerateBitacoraCreateNecesidad(int necesidadId);
        GenerateBitacoraEditNecesidadResponse GenerateBitacoraEditNecesidad(DatosComparativaBitacoraViewModel datosBitacoraViewModel);
        GetBitacorasNecesidadResponse GetBitacorasByNecesidadId(DataTableRequest request);
        GenerateBitacoraNecesidadResponse GenerateBitacoraNecesidadManual(int necesidadId, string message);

        #endregion
    }
}
