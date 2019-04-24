using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recruiting.Application.Base.ViewModel;
using Recruiting.Application.Ofertas.Services;
using Recruiting.Application.Ofertas.ViewModels;
using Recruiting.Business.BaseClasses.DataTable;
using Recruiting.Business.Repositories;
using Recruiting.Data.EntityFramework.Repositories;
using Recruiting.Infra.Transactions;
using System;
using System.Collections.Generic;

namespace TestNecesidadService.AppService.Oferta.Services
{
    [TestClass]
    public class OfertaServiceTest
    {
        #region Constants

        private int USER_ID = 1;
        private DateTime CREATED_DATE = new DateTime(2015, 4, 18);
        private DateTime MODIFIED_DATE = new DateTime(2015, 4, 20);
        private int OFERTA_ID = 4;
        private string NOMBRE_OFERTA = "Oferta Programador .NET";
        private string DESC_OFERTA = "Oferta programacion .NET con MVC y Entity Framework";
        private int ESTADO_OFERTA = 14;
        private int PAGE_SIZE = 5;
        private int PAGE_NUMBER = 1;

        #endregion

        #region Fields

        private IOfertaRepository _ofertaRepository;
        private IOfertaService _ofertaService;

        #endregion

        #region Constructor

        public OfertaServiceTest()
        {
            _ofertaRepository = new OfertaRepository();
            _ofertaService = new OfertaService(_ofertaRepository, new CandidaturaRepository());
        }

        #endregion

        #region Test Method

        [TestMethod]
        public void OfertaSave()
        {
            using (var tx = new TransactionManager())
            {
                var modifiableEntityViewModel = new ModifiableEntityViewModel()
                {
                    CreatedBy = USER_ID,
                    Created = CREATED_DATE
                };

                var viewModel = new CreateEditOfertaViewModel()
                {
                    Nombre = NOMBRE_OFERTA,
                    Descripcion = DESC_OFERTA,
                    FechaPublicacion = CREATED_DATE,
                    EstadoOfertaId = ESTADO_OFERTA,
                };

                var response = _ofertaService.SaveOferta(viewModel);

                Assert.IsTrue(response.IsValid);
                Assert.IsNotNull(response.OfertaId);
            }
        }

        [TestMethod]
        public void UpdateOferta()
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

                var viewModel = new CreateEditOfertaViewModel()
                {
                    OfertaId = OFERTA_ID,
                    Nombre = NOMBRE_OFERTA,
                    Descripcion = DESC_OFERTA,
                    FechaPublicacion = CREATED_DATE,
                    EstadoOfertaId = ESTADO_OFERTA,
                };

                var response = _ofertaService.SaveOferta(viewModel);

                Assert.IsTrue(response.IsValid);
                Assert.Equals(response.OfertaId, OFERTA_ID);
            }
        }

        [TestMethod]
        public void DeleteOferta()
        {
            using (var tx = new TransactionManager())
            {
                var response = _ofertaService.DeleteOferta(OFERTA_ID);

                Assert.IsTrue(response.IsValid);
            }
        }

        [TestMethod]
        public void GetOfertaById()
        {
            using (var tx = new TransactionManager())
            {
                var response = _ofertaService.GetOfertaById(OFERTA_ID);

                Assert.IsTrue(response.IsValid);
            }
            
        }

        [TestMethod]
        public void GetOfertas()
        {
            using (var tx = new TransactionManager())
            {
                var customFilters = new Dictionary<string, string>();
                customFilters.Add("filterNombre", ".NET");

                var table = new DataTableRequest()
                {
                    PageSize = PAGE_SIZE,
                    PageNumber = PAGE_NUMBER,
                    CustomFilters = customFilters
                };

                var response = _ofertaService.GetOfertas(table);

                Assert.IsTrue(response.IsValid);
            }

        }

        #endregion
    }
}
