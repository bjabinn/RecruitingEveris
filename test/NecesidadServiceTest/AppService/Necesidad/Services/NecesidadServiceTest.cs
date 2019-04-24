using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recruiting.Application.Base.ViewModel;
using Recruiting.Application.Necesidades.Services;
using Recruiting.Application.Necesidades.ViewModels;
using Recruiting.Business.BaseClasses.DataTable;
using Recruiting.Business.Repositories;
using Recruiting.Data.EntityFramework.Repositories;
using Recruiting.Infra.Transactions;
using System;
using System.Collections.Generic;

namespace TestNecesidadService.AppService.Necesidad.Services
{
    [TestClass]
    public class NecesidadServiceTest
    {
        #region Constants

        private int USER_ID = 1;
        private DateTime CREATED_DATE = new DateTime(2015, 4, 17);
        private DateTime MODIFIED_DATE = new DateTime(2015, 4, 20);
        private int NECESIDAD_ID = 1;
        private string NOMBRE_NECESIDAD = "Necesidad .NET";
        private int OFICINA_ID = 1;
        private int CENTRO_ID = 2;
        private int SECTOR_ID = 3;
        private int CLIENTE_ID = 1;
        private int PROYECTO_ID = 1;
        private int TIPO_SERVICIO_ID = 4;
        private int TIPO_PERFIL_ID = 5;
        private int TIPO_TECNOLOGIA_ID = 6;
        private int TIPO_CONTRATACION_ID = 7;
        private int TIPO_PREVISION_ID = 8;
        private int MESES_ASIGNACION_ID = 9;
        private string DETALLE_TECNOLOGIA = ".NET MVC";
        private int ESTADO_NECESIDAD_ID = 11;
        private int ESTADO_NECESIDAD_ID_NEW = 10;
        private int PAGE_SIZE = 5;
        private int PAGE_NUMBER = 1;
        private DateTime FECHA_SOLICITUD = new DateTime(2015, 4, 20);
        private DateTime FECHA_COMPROMISO = new DateTime(2015, 5, 2);
        private DateTime FECHA_CIERRE = new DateTime(2015, 6, 30);

        #endregion

        #region Fields

        private INecesidadRepository _necesidadRepository;
        private INecesidadService _necesidadService;

        #endregion

        #region Constructor

        public NecesidadServiceTest()
        {
            _necesidadRepository = new NecesidadRepository();
            _necesidadService = new NecesidadService(_necesidadRepository);
        }

        #endregion

        #region Test Method

        [TestMethod]
        public void SaveNecesidad()
        {
            using (var tx = new TransactionManager())
            {
                var modifiableEntityViewModel = new ModifiableEntityViewModel()
                {
                    CreatedBy = USER_ID,
                    Created = CREATED_DATE
                };

                var viewModel = new CreateEditNecesidadViewModel()
                {
                    Nombre = NOMBRE_NECESIDAD,
                    OficinaId = OFICINA_ID,
                    CentroId = CENTRO_ID,
                    SectorId = SECTOR_ID,
                    ClienteId = CLIENTE_ID,
                    ProyectoId = PROYECTO_ID,
                    TipoServicioId = TIPO_SERVICIO_ID,
                    TipoPerfilId = TIPO_PERFIL_ID,
                    TipoTecnologiaId = TIPO_TECNOLOGIA_ID,
                    TipoContratacionId = TIPO_CONTRATACION_ID,
                    TipoPrevisionId = TIPO_PREVISION_ID,
                    MesesAsignacionId = MESES_ASIGNACION_ID,
                    DetalleTecnologia = DETALLE_TECNOLOGIA,
                    DisponibilidadViajes = false,
                    DisponibilidadReubicacion = false,
                    FechaSolicitud = FECHA_SOLICITUD,
                    FechaCompromiso = FECHA_COMPROMISO,
                    FechaCierre = FECHA_CIERRE,
                    EstadoNecesidadId = ESTADO_NECESIDAD_ID,

                };

                var response = _necesidadService.SaveNecesidad(viewModel);

                Assert.IsTrue(response.IsValid);
                Assert.IsNotNull(response.NecesidadId);
            }
        }

        [TestMethod]
        public void UpdateNecesidad()
        {
            using (var tx = new TransactionManager())
            {
                var modifiableEntityViewModel = new ModifiableEntityViewModel()
                {
                    CreatedBy = USER_ID,
                    Created = CREATED_DATE,
                    ModifiedBy = USER_ID,
                    Modified = MODIFIED_DATE
                };

                var viewModel = new CreateEditNecesidadViewModel()
                {
                    NecesidadId = NECESIDAD_ID,
                    Nombre = NOMBRE_NECESIDAD,
                    OficinaId = OFICINA_ID,
                    CentroId = CENTRO_ID,
                    SectorId = SECTOR_ID,
                    ClienteId = CLIENTE_ID,
                    ProyectoId = PROYECTO_ID,
                    TipoServicioId = TIPO_SERVICIO_ID,
                    TipoPerfilId = TIPO_PERFIL_ID,
                    TipoTecnologiaId = TIPO_TECNOLOGIA_ID,
                    TipoContratacionId = TIPO_CONTRATACION_ID,
                    TipoPrevisionId = TIPO_PREVISION_ID,
                    MesesAsignacionId = MESES_ASIGNACION_ID,
                    DetalleTecnologia = DETALLE_TECNOLOGIA,
                    DisponibilidadViajes = true,
                    DisponibilidadReubicacion = false,
                    FechaSolicitud = FECHA_SOLICITUD,
                    FechaCompromiso = FECHA_COMPROMISO,
                    FechaCierre = FECHA_CIERRE,
                    EstadoNecesidadId = ESTADO_NECESIDAD_ID_NEW,
                };

                var response = _necesidadService.SaveNecesidad(viewModel);

                Assert.IsTrue(response.IsValid);
                Assert.Equals(response.NecesidadId, NECESIDAD_ID);
            }
        }

        [TestMethod]
        public void DeleteNecesidad()
        {
            using (var tx = new TransactionManager())
            {
                var response = _necesidadService.DeleteNecesidad(NECESIDAD_ID, false);

                Assert.IsTrue(response.IsValid);
            }
        }

        [TestMethod]
        public void GetNecesidadById()
        {
            using (var tx = new TransactionManager())
            {
                var response = _necesidadService.GetNecesidadById(NECESIDAD_ID);

                Assert.IsTrue(response.IsValid);
                Assert.Equals(response.NecesidadViewModel.NecesidadId, NECESIDAD_ID);
            }
        }

        [TestMethod]
        public void GetNecesidades()
        {
            using (var tx = new TransactionManager())
            {
                var customFilters = new Dictionary<string, string>();
                customFilters.Add("filterEstado", "10");

                var table = new DataTableRequest()
                {
                    PageSize = PAGE_SIZE,
                    PageNumber = PAGE_NUMBER,
                    CustomFilters = customFilters
                };

                var response = _necesidadService.GetNecesidades(table);

                Assert.IsTrue(response.IsValid);
            }
        }

        #endregion
    }
}
