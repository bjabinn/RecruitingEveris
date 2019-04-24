using Recruiting.Application.Candidaturas.Enums;
using Recruiting.Application.Candidaturas.Services;
using Recruiting.Application.Candidaturas.ViewModel;
using Recruiting.Application.CandidaturasOfertas.Services;
using Recruiting.Application.FunnelProcesos.Services;
using Recruiting.Application.FunnelProcesos.ViewModels;
using Recruiting.Application.Maestros.Enums;
using Recruiting.Application.Maestros.Services;
using Recruiting.Application.Usuarios.ViewModels;
using Recruiting.Business.Repositories;
using Recruiting.Data.EntityFramework.Repositories;
using RecruitingWeb.Components.DataTable.ServerSide;
using RecruitingWeb.Constantes;
using RecruitingWeb.Helpers;
using RecruitingWeb.Models;
using RecruitingWeb.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace RecruitingWeb.Controllers
{
    public class FunnelProcesosController : Controller
    {
        #region Fields

        private readonly IMaestroRepository _maestroRepository;
        private readonly IMaestroService _maestroService;
        private readonly IFunnelProcesosService _funnelProcesosService;
        private readonly ICandidaturaEstadoRepository _candidaturaEstadoRepository;
        private readonly ICandidaturaEstadoService _candidaturaEstadoService;
        private readonly ICandidaturaOfertaRepository _candidaturaOfertaRepository;
        private readonly ICandidaturaOfertaService _candidaturaOfertaService;

        #endregion

        #region Construct
        public FunnelProcesosController()
        {
            _maestroRepository = new MaestroRepository();
            _maestroService = new MaestroService(_maestroRepository);
            _funnelProcesosService = new FunnelProcesosService();
            _candidaturaEstadoRepository = new CandidaturaEstadoRepository();
            _candidaturaEstadoService = new CandidaturaEstadoService(_candidaturaEstadoRepository);
            _candidaturaOfertaRepository = new CandidaturaOfertaRepository();
            _candidaturaOfertaService = new CandidaturaOfertaService(_candidaturaOfertaRepository);
        }
        #endregion

        #region Index UI


        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.VerFunnelProcesos)]
        public ActionResult Index()
        {
            var filtro = new FiltroFunnelModels();

            filtro = GenerateViewElementsIndex(filtro);

            return View(filtro);
        }

        
        #endregion

        #region Graficas

        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.VerFunnelProcesos)]
        public JsonResult LoadGraficasFunnel(string FechaInicio, string FechaFin, string TipoTecnologiaId, string TipoCategoriaId, string CentroIdUsuario, string CandidaturaOfertaId)
        {

            var response = new JsonResult();
            var funnelProcesoGraficasModels = new FunnelProcesoGraficasModels
            {
                DatosFiltradoCV = new DatosFiltradoCVViewModel(),
                DatosEntrevistas = new DatosEntrevistasViewModel(),                
                DatosCartaOferta = new DatosCartaOfertaViewModel()
            };

            if (HttpContext.Session["CentroIdUsuario"] != null)
            {
                var centroUsuario = HttpContext.Session["CentroIdUsuario"].ToString();
                if(!string.IsNullOrEmpty(centroUsuario))
                {
                    CentroIdUsuario = centroUsuario;
                }
            }

            var filtroFunnelProcesos = new FiltroFunnelProcesosViewModel();

            if(!string.IsNullOrEmpty(FechaInicio))
            {
                filtroFunnelProcesos.FechaInicio = Convert.ToDateTime(FechaInicio);
            }
            if (!string.IsNullOrEmpty(FechaFin))
            {
                filtroFunnelProcesos.FechaFin = Convert.ToDateTime(FechaFin);
            }
            if (!string.IsNullOrEmpty(TipoTecnologiaId))
            {
                filtroFunnelProcesos.TipoTecnologiaId = Convert.ToInt32(TipoTecnologiaId);
            }
            if (!string.IsNullOrEmpty(TipoCategoriaId))
            {
                filtroFunnelProcesos.TipoCategoriaId = Convert.ToInt32(TipoCategoriaId);
            }
            if (!string.IsNullOrEmpty(CentroIdUsuario))
            {
                filtroFunnelProcesos.CentroIdUsuario = Convert.ToInt32(CentroIdUsuario);
            }
            if (!string.IsNullOrEmpty(CandidaturaOfertaId))
            {
                filtroFunnelProcesos.CandidaturaOfertaId = Convert.ToInt32(CandidaturaOfertaId);
            }


            var responseDatosFiltrado = _funnelProcesosService.GetDatosFunnelFiltradoCV(filtroFunnelProcesos);
            if(responseDatosFiltrado.IsValid)
            {
                funnelProcesoGraficasModels.DatosFiltradoCV = responseDatosFiltrado.DatosFiltradoCV;              
            }

            var responseDatosEntrevistas = _funnelProcesosService.GetDatosFunnelEntrevistas(filtroFunnelProcesos);

            if (responseDatosEntrevistas.IsValid)
            {
                funnelProcesoGraficasModels.DatosEntrevistas = responseDatosEntrevistas.DatosEntrevistas;
                
            }         

            var responseDatosCartaOferta = _funnelProcesosService.GetDatosCartaOferta(filtroFunnelProcesos);

            if (responseDatosCartaOferta.IsValid)
            {
                funnelProcesoGraficasModels.DatosCartaOferta = responseDatosCartaOferta.DatosCartaOferta;
                funnelProcesoGraficasModels.IsValid = true;
            }

            response.Data = funnelProcesoGraficasModels;
            
            return response;

        }

        #endregion

        #region Tablas

        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.VerFunnelProcesos)]
        public virtual JsonResult LoadDesgloseTecnologia([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel)
        {        

            var request = requestModel.ConvertToDataTableRequestViewModel();

            var listaTecnologias = GeneraListaTecnologia();

            if (HttpContext.Session["CentroIdUsuario"] != null)
            {
                var centroUsuario = HttpContext.Session["CentroIdUsuario"].ToString();
                if (!string.IsNullOrEmpty(centroUsuario))
                {
                    request.CustomFilters.Add("CentroIdUsuario", centroUsuario);
                }
            }

            var response = _funnelProcesosService.GetDatosDesgloseTecnologia(request, listaTecnologias);

            if (!response.IsValid)
            {
                return null;
            }

            var result = from c in response.ListaDesgloseTecnologia
                         select new object[]
            {
                c.NombreTecnologia.Length <= 11 ? c.NombreTecnologia : string.Format("<span title=\"{0}\">{1}</span>" , c.NombreTecnologia.ToString(), c.NombreTecnologia.Substring(0, 11) + "..."),
                string.Format("<a>{0}</a>", c.DatosFiltradoCV.TotalCreados),
                string.Format("<a>{0}</a>", c.DatosFiltradoCV.NumeroPendienteFiltrados),
                string.Format("<a>{0}</a>", c.DatosFiltradoCV.NumeroSupera),
                string.Format("<a>{0}</a>", c.DatosFiltradoCV.NumeroDescartados),
                string.Format("<a>{0}</a>", c.DatosFiltradoCV.NumeroRenuncias),
                string.Format("<a>{0}</a>", c.DatosFiltradoCV.NumeroStandBy),
                string.Format("<a>{0}</a>", c.DatosEntrevistas.NumeroPendientesCitacion),
                string.Format("<a>{0}</a>", c.DatosEntrevistas.NumeroFeedback),
                string.Format("<a>{0}</a>", c.DatosEntrevistas.NumeroSupera),
                string.Format("<a>{0}</a>", c.DatosEntrevistas.NumeroDescartados),
                string.Format("<a>{0}</a>", c.DatosEntrevistas.NumeroRenuncias),
                string.Format("<a>{0}</a>", c.DatosEntrevistas.NumeroStandBy),
                string.Format("<a>{0}</a>", c.DatosCartaOferta.NumeroPendientesCitacion),
                string.Format("<a>{0}</a>", c.DatosCartaOferta.NumeroFeedback),
                string.Format("<a>{0}</a>", c.DatosCartaOferta.NumeroAceptadas),
                string.Format("<a>{0}</a>", c.DatosCartaOferta.NumeroRechazadas),
                string.Format("<a>{0}</a>", c.DatosCartaOferta.NumeroDescartadas),
                string.Format("<a>{0}</a>", c.DatosCartaOferta.NumeroRenuncias),
                string.Format("<a>{0}</a>", c.DatosCartaOferta.NumeroStandBy),
                this.RenderRazorViewToString("Table/dataTecnologia", c),

            };

            var jsonResponse = new DataTablesResponse(requestModel.Draw, result, response.TotalElementos, response.TotalElementos);
            return Json(jsonResponse, JsonRequestBehavior.AllowGet);
        }

        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.VerFunnelProcesos)]
        public virtual JsonResult LoadDesgloseCategoria([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel)
        {

            var request = requestModel.ConvertToDataTableRequestViewModel();

            var listaCategorias = GeneraListaCategoria();

            if (HttpContext.Session["CentroIdUsuario"] != null)
            {
                var centroUsuario = HttpContext.Session["CentroIdUsuario"].ToString();
                if (!string.IsNullOrEmpty(centroUsuario))
                {
                    request.CustomFilters.Add("CentroIdUsuario", centroUsuario);
                }
            }

            var response = _funnelProcesosService.GetDatosDesgloseCategoria(request, listaCategorias);

            if (!response.IsValid)
            {
                return null;
            }

            var result = from c in response.ListaDesgloseCategoria
                         select new object[]
            {
                c.NombreCategoria.Length <= 11 ? c.NombreCategoria : string.Format("<span title=\"{0}\">{1}</span>" , c.NombreCategoria.ToString(), c.NombreCategoria.Substring(0, 11) + "..."),
                string.Format("<a>{0}</a>", c.DatosFiltradoCV.TotalCreados),
                string.Format("<a>{0}</a>", c.DatosFiltradoCV.NumeroPendienteFiltrados),
                string.Format("<a>{0}</a>", c.DatosFiltradoCV.NumeroSupera),
                string.Format("<a>{0}</a>", c.DatosFiltradoCV.NumeroDescartados),
                string.Format("<a>{0}</a>", c.DatosFiltradoCV.NumeroRenuncias),
                string.Format("<a>{0}</a>", c.DatosFiltradoCV.NumeroStandBy),
                string.Format("<a>{0}</a>", c.DatosEntrevistas.NumeroPendientesCitacion),
                string.Format("<a>{0}</a>", c.DatosEntrevistas.NumeroFeedback),
                string.Format("<a>{0}</a>", c.DatosEntrevistas.NumeroSupera),
                string.Format("<a>{0}</a>", c.DatosEntrevistas.NumeroDescartados),
                string.Format("<a>{0}</a>", c.DatosEntrevistas.NumeroRenuncias),
                string.Format("<a>{0}</a>", c.DatosEntrevistas.NumeroStandBy),
                string.Format("<a>{0}</a>", c.DatosCartaOferta.NumeroPendientesCitacion),
                string.Format("<a>{0}</a>", c.DatosCartaOferta.NumeroFeedback),
                string.Format("<a>{0}</a>", c.DatosCartaOferta.NumeroAceptadas),
                string.Format("<a>{0}</a>", c.DatosCartaOferta.NumeroRechazadas),
                string.Format("<a>{0}</a>", c.DatosCartaOferta.NumeroDescartadas),
                string.Format("<a>{0}</a>", c.DatosCartaOferta.NumeroRenuncias),
                string.Format("<a>{0}</a>", c.DatosCartaOferta.NumeroStandBy),
                this.RenderRazorViewToString("Table/dataCategoria", c)

            };

            var jsonResponse = new DataTablesResponse(requestModel.Draw, result, response.TotalElementos, response.TotalElementos);
            return Json(jsonResponse, JsonRequestBehavior.AllowGet);
        }

        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.VerFunnelProcesos)]
        public virtual JsonResult LoadDesgloseTecnologiaCategoria([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel)
        {

            var request = requestModel.ConvertToDataTableRequestViewModel();           

            if (HttpContext.Session["CentroIdUsuario"] != null)
            {
                var centroUsuario = HttpContext.Session["CentroIdUsuario"].ToString();
                if (!string.IsNullOrEmpty(centroUsuario))
                {
                    request.CustomFilters.Add("CentroIdUsuario", centroUsuario);
                }
            }

            var response = _funnelProcesosService.GetDatosDesgloseTecnologiaCategoria(request);

            if (!response.IsValid)
            {
                return null;
            }

            var result = from c in response.ListaDesgloseTecnologiaCategoria
                         select new object[]
            {
                string.Format("<a>{0}</a>", c.DatosFiltradoCV.TotalCreados),
                string.Format("<a>{0}</a>", c.DatosFiltradoCV.NumeroPendienteFiltrados),
                string.Format("<a>{0}</a>", c.DatosFiltradoCV.NumeroSupera),
                string.Format("<a>{0}</a>", c.DatosFiltradoCV.NumeroDescartados),
                string.Format("<a>{0}</a>", c.DatosFiltradoCV.NumeroRenuncias),
                string.Format("<a>{0}</a>", c.DatosFiltradoCV.NumeroStandBy),
                string.Format("<a>{0}</a>", c.DatosEntrevistas.NumeroPendientesCitacion),
                string.Format("<a>{0}</a>", c.DatosEntrevistas.NumeroFeedback),
                string.Format("<a>{0}</a>", c.DatosEntrevistas.NumeroSupera),
                string.Format("<a>{0}</a>", c.DatosEntrevistas.NumeroDescartados),
                string.Format("<a>{0}</a>", c.DatosEntrevistas.NumeroRenuncias),
                string.Format("<a>{0}</a>", c.DatosEntrevistas.NumeroStandBy),
                string.Format("<a>{0}</a>", c.DatosCartaOferta.NumeroPendientesCitacion),
                string.Format("<a>{0}</a>", c.DatosCartaOferta.NumeroFeedback),
                string.Format("<a>{0}</a>", c.DatosCartaOferta.NumeroAceptadas),
                string.Format("<a>{0}</a>", c.DatosCartaOferta.NumeroRechazadas),
                string.Format("<a>{0}</a>", c.DatosCartaOferta.NumeroDescartadas),
                string.Format("<a>{0}</a>", c.DatosCartaOferta.NumeroRenuncias),
                string.Format("<a>{0}</a>", c.DatosCartaOferta.NumeroStandBy),
                this.RenderRazorViewToString("Table/dataTecnologiaCategoria", c)

            };

            var jsonResponse = new DataTablesResponse(requestModel.Draw, result, response.TotalElementos, response.TotalElementos);
            return Json(jsonResponse, JsonRequestBehavior.AllowGet);
        }


        [RecruitingAuthorizeAttribute(AccessLevel = PermisosConst.VerFunnelProcesos)]
        [ValidateInput(false)]
        public virtual JsonResult LoadCandidaturasModal([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel)
        {            
            var request = requestModel.ConvertToDataTableRequestViewModel();

            var response = _funnelProcesosService.GetCandidaturasModal(request);

            if (!response.IsValid)
            {
                return null;
            }

            ////Esto muestra el estado "Entrevista" aunque físicamente estemos en "Segunda Entrevista".
            var estadoCandidaturaEntrevista = GenerateEstadosElements().First(x => x.Value == ((int)TipoEstadoCandidaturaEnum.Entrevista).ToString()).Text;
            foreach (var candidaturaRow in response.CandidaturaModalViewModel)
            {
                if (candidaturaRow.EstadoId == (int)TipoEstadoCandidaturaEnum.SegundaEntrevista)
                {
                    candidaturaRow.Estado = estadoCandidaturaEntrevista;
                }
            }

            var result = from c in response.CandidaturaModalViewModel
                         select new object[]
                         {
                                c.CandidaturaId,
                                c.OrigenCv == null ? "" : c.OrigenCv.ToString(),
                                (c.EstadoId == (int)TipoEstadoCandidaturaEnum.Renuncia
                                || c.EstadoId == (int)TipoEstadoCandidaturaEnum.Descartado ) ? string.Format("<span class=\"Statered\">{0}</span>", c.Estado) :  c.Estado,
                                (c.EstadoId == (int)TipoEstadoCandidaturaEnum.Contratado) ? string.Format("<span class=\"hidden\">{0}</span>", c.Etapa) :   c.Etapa,
                                c.Candidato,
                                c.TipoTecnologia == null ? "" : c.TipoTecnologia.ToString(),
                                c.Entrevistador,
                                (c.EtapaId == (int)TipoEtapaCandidaturaEnum.FiltradoTecnico
                                || c.EtapaId == (int)TipoEtapaCandidaturaEnum.Inicio
                                || c.EtapaId == (int)TipoEtapaCandidaturaEnum.AgendarEntrevistas ) ? "": FormatHelper.Format(c.Agendada.Date, "dd/MM/yyyy"),
                                c.Perfil,
                                c.Modulo,
                                c.Centro,
                                this.RenderRazorViewToString("Table/actionColumnModalCandidatura", c),
                         };

            var centroUsuarioId = HttpContext.Session["CentroIdUsuario"];
            if ((centroUsuarioId != null) && result.Any())
            {
                var resultTemp = new List<object[]>();
                result.ToList().ForEach(x =>
                {
                    var item = x.ToList();
                    item.RemoveAt(10);
                    resultTemp.Add(item.ToArray());
                });
                result = resultTemp;
            }


            var jsonResponse = new DataTablesResponse(requestModel.Draw, result, response.TotalElementos, response.TotalElementos);

            return Json(jsonResponse, JsonRequestBehavior.AllowGet);          

        }

        [HttpPost]
        public JsonResult GetOfertasByNombre(string textSearch)
        {
            var UsuarioRolPermisoViewModel = (UsuarioRolPermisoViewModel)HttpContext.Session["Usuario"];
            var centroId = UsuarioRolPermisoViewModel.CentroIdUsuario;
            var response = _candidaturaOfertaService.GetOfertasByNombre(textSearch, centroId);
            var isValid = response.IsValid;
            var errorMessage = response.ErrorMessage;
            var ofertas = response.Ofertas.Select(x => new SelectListItem()
            {
                Text = x.NombreOferta,
                Value = x.OfertaId.ToString()
            });

            return Json(new { IsValid = isValid, ErrorMessage = errorMessage, Items = ofertas });
        }

        #endregion

        private IEnumerable<SelectListItem> GeneraListaTecnologia()
        {
            int[] tipoMaestroId =
           {   
                (int)MasterDataTypeEnum.TipoTecnologia

            };

            var response = _maestroService.GetDatosMaestroByTipoId(tipoMaestroId);

            return ControllerHelper.GenerateElements(response, MasterDataTypeEnum.TipoTecnologia);
        }

        private IEnumerable<SelectListItem> GeneraListaCategoria()
        {
            int[] tipoMaestroId =
           {
                (int)MasterDataTypeEnum.Categoria

            };

            var response = _maestroService.GetDatosMaestroByTipoId(tipoMaestroId);

            return ControllerHelper.GenerateElements(response, MasterDataTypeEnum.Categoria);
        }

        private IEnumerable<SelectListItem> GenerateEstadosElements()
        {
            var response = _candidaturaEstadoService.GetEstadosCandidatura();

            if (response.IsValid)
            {
                if ((from value in response.CandidaturaEstadosViewModel where value.Orden == null select value).Any()) //si hay ALGUN estado con el orden sin definir
                {
                    IEnumerable<CandidaturaEstadoRowViewModel> estadosList;
                    estadosList = from value in response.CandidaturaEstadosViewModel orderby value.EstadoCandidatura select value;
                    return new SelectList(estadosList, "EstadoCandidaturaId", "EstadoCandidatura");
                }
                else
                {
                    IEnumerable<CandidaturaEstadoRowViewModel> estadosList;
                    estadosList = from value in response.CandidaturaEstadosViewModel orderby value.Orden select value;
                    return new SelectList(estadosList, "EstadoCandidaturaId", "EstadoCandidatura");
                }
            }
            else
            {
                return new List<SelectListItem>();
            }
        }

        private FiltroFunnelModels GenerateViewElementsIndex(FiltroFunnelModels filtro)
        {
            int[] tipoMaestroId =
           {
                (int)MasterDataTypeEnum.Categoria,
                (int)MasterDataTypeEnum.TipoTecnologia
            };

            var response = _maestroService.GetDatosMaestroByTipoId(tipoMaestroId);

            filtro.TipoCategoriaList = ControllerHelper.GenerateElements(response, MasterDataTypeEnum.Categoria);
            filtro.TipoTecnologiaList = ControllerHelper.GenerateElements(response, MasterDataTypeEnum.TipoTecnologia);
            filtro.CentroList = (IEnumerable<SelectListItem>)HttpContext.Session["ListaCentros"];
            filtro.CentroIdUsuarioLogueado = HttpContext.Session["CentroIdUsuario"] != null ? HttpContext.Session["CentroIdUsuario"].ToString() : string.Empty;

            return filtro;
        }

    }
}