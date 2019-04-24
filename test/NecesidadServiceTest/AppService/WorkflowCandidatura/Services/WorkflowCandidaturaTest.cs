using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recruiting.Business.Repositories;
using Recruiting.Business.Services.WorkflowCandidatura;
using Recruiting.Data.EntityFramework.Repositories;
using Recruiting.Infra.Transactions;

namespace TestNecesidadService.AppService.WorkflowCandidatura.Services
{
    [TestClass]
    public class WorkflowCandidaturaTest
    {
        #region Constants

        private const int ETAPA_ORIGEN_ID = 1;
        private const int ESTADO_ORIGEN_ID = 1;
        private const int TIPO_DECISION_ID = 1;
        private const int ETAPA_FIN_ID = 1;
        private const int ESTADO_FIN_ID = 1;
        private const string VISTA_ESPERADA = "http://url1.com";

        #endregion

        #region Fields

        private IRelacionEtapaRepository _relacionEtapaRepository;
        private IRelacionVistaEtapaRepository _relacionVistaEtapaRepository;
        private IWorkflowCandidaturaService _workflowCandidaturaService;

        #endregion

        #region Constructor

        public WorkflowCandidaturaTest()
        {
            _relacionEtapaRepository = new RelacionEtapaRepository();
            _relacionVistaEtapaRepository = new RelacionVistaEtapaRepository();
            _workflowCandidaturaService = new WorkflowCandidaturaService(_relacionEtapaRepository, _relacionVistaEtapaRepository);
        }

        #endregion

        #region Test Method

        [TestMethod]
        public void IsExecutableTest()
        {
            using(var tx = new TransactionManager())
            {
                //1 - Arrange

                //2- Action

                var isExecutable = _workflowCandidaturaService.IsExecutable(ETAPA_ORIGEN_ID, TIPO_DECISION_ID, ESTADO_ORIGEN_ID);

                //3- Assert

                Assert.IsTrue(isExecutable);
            }
        }

        [TestMethod]
        public void IsNotExecutableTest()
        {
            using (var tx = new TransactionManager())
            {
                //1 - Arrange
                var etapaOrigenId = 2;
                var tipoDecisionId = 2;
                var estadoOrigenId = 1;

                //2- Action

                var isExecutable = _workflowCandidaturaService.IsExecutable(etapaOrigenId, tipoDecisionId, estadoOrigenId);

                //3- Assert

                Assert.IsFalse(isExecutable);
            }
        }

        [TestMethod]
        public void ExecuteTest()
        {
            //1 - Arrange

            //2- Action

            var dto = _workflowCandidaturaService.Execute(ETAPA_ORIGEN_ID, TIPO_DECISION_ID);

            //3- Assert

            Assert.IsTrue(dto.IsValid);
            Assert.IsTrue(dto.EtapaFinId == ETAPA_FIN_ID);
            Assert.IsTrue(dto.EstadoFinId == ESTADO_FIN_ID);
        }

        [TestMethod]
        public void GetVistaTest()
        {
            //1 - Arrange

            //2- Action
            var vista = _workflowCandidaturaService.GetVista(ETAPA_ORIGEN_ID, ESTADO_ORIGEN_ID);

            //3- Assert

            Assert.IsTrue(vista == VISTA_ESPERADA);
        }

        #endregion
    }
}
