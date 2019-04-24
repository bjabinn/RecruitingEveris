using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recruiting.Application.Decisiones.Services;
using Recruiting.Business.Repositories;
using Recruiting.Data.EntityFramework.Repositories;
using Recruiting.Infra.Transactions;

namespace TestNecesidadService.AppService.TipoDecision.Services
{
    [TestClass]
    public class TipoDecisionTest
    {
        #region Constants

        private const int TIPO_ETAPA_CANDIDATURA_ID = 1;

        #endregion

        #region Fields

        private ITipoDecisionRepository _tipoDecisionRepository;
        private ITipoDecisionService _tipoDecisionService;

        #endregion

        #region Constructors

        public TipoDecisionTest()
        {
            _tipoDecisionRepository = new TipoDecisionRepository();
            _tipoDecisionService = new TipoDecisionService(_tipoDecisionRepository);
        }
        #endregion

        #region Test Methods
        
        [TestMethod]
        public void GetDecisionesByEtapaId()
        {
            using (var tx = new TransactionManager())
            {
                //1 - Arrange

                //2 - Action

                var response = _tipoDecisionService.GetDecisionesByEtapaId(TIPO_ETAPA_CANDIDATURA_ID);

                //3 - Assert

                Assert.IsTrue(response.IsValid);
            }
        }

        #endregion
    }
}
