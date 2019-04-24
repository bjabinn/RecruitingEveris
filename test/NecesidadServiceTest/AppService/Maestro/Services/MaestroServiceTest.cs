using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recruiting.Application.Maestros.Services;
using Recruiting.Business.Repositories;
using Recruiting.Data.EntityFramework.Repositories;
using Recruiting.Infra.Transactions;

namespace TestNecesidadService.AppService.Maestro.Services
{
    [TestClass]
    public class MaestroServiceTest
    {
        #region Constants

        private readonly int[] TIPO_MAESTRO_ID = {4, 12};
        private const int NUM_VALORES_ESPERADOS = 4;
        
        #endregion

        #region Fields

        private IMaestroRepository _maestroRepository;
        private IMaestroService _maestroService;

        #endregion

        #region Constructor

        public MaestroServiceTest()
        {
            _maestroRepository = new MaestroRepository();
            _maestroService = new MaestroService(_maestroRepository);
        }

        #endregion

        #region Test Method

        [TestMethod]
        public void GetDatosMaestroByTipoId()
        {
            using (var tx = new TransactionManager())
            {
                //1 - Arrange

                int numValoresEsperados = NUM_VALORES_ESPERADOS;

                //2 - Action

                var response = _maestroService.GetDatosMaestroByTipoId(TIPO_MAESTRO_ID);

                //3 - Assert

                Assert.IsTrue(response.TotalElementos == numValoresEsperados);
            }

        }

        #endregion
    }
}
