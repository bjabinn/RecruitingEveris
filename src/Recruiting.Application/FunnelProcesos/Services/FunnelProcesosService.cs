using Recruiting.Application.Candidaturas.Enums;
using Recruiting.Application.FunnelProcesos.Mappers;
using Recruiting.Application.FunnelProcesos.Messages;
using Recruiting.Application.FunnelProcesos.ViewModels;
using Recruiting.Business.BaseClasses.DataTable;
using Recruiting.Business.Entities;
using Recruiting.Business.Helpers;
using Recruiting.Business.Repositories;
using Recruiting.Data.EntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Recruiting.Application.FunnelProcesos.Services
{
    public class FunnelProcesosService : IFunnelProcesosService
    {
        #region Constants
        public const string CandidaturaFiltroSessionKey = "CandidaturaFiltroSessionKey";
        #endregion

        #region Fields

        private readonly ICandidaturaRepository _candidaturaRepository;        
        private readonly IEntrevistaRepository _entrevistaRepository;
        private readonly ICartaOfertaRepository _cartaOfertaRepository;       

        #endregion

        #region Constructor

        public FunnelProcesosService()
        {           
            _candidaturaRepository = new CandidaturaRepository();
            _entrevistaRepository = new EntrevistaRepository();
            _cartaOfertaRepository = new CartaOfertaRepository();
           
        }

        #endregion

        #region QueryRequest

        public GetDatosDesgloseTecnologiaResponse GetDatosDesgloseTecnologia(DataTableRequest request, IEnumerable<SelectListItem> listaTecnologias)
        {
            var response = new GetDatosDesgloseTecnologiaResponse();

            try
            {
                if (request.CustomFilters != null && request.CustomFilters.ContainsKey("BuscarTecnologia"))
                {
                    var buscarTecnologia = request.CustomFilters["BuscarTecnologia"];
                    if (!string.IsNullOrEmpty(buscarTecnologia))
                    {
                        var filtro = new FiltroFunnelProcesosViewModel();

                        if (request.CustomFilters.ContainsKey("FechaInicio") && request.CustomFilters["FechaInicio"] != string.Empty)
                        {
                            filtro.FechaInicio = Convert.ToDateTime(request.CustomFilters["FechaInicio"]);
                        }
                        else
                        {
                            filtro.FechaInicio = DateTime.Today.AddDays(-365);

                        }
                        if (request.CustomFilters.ContainsKey("FechaFin") && request.CustomFilters["FechaFin"] != string.Empty)
                        {
                            filtro.FechaFin = Convert.ToDateTime(request.CustomFilters["FechaFin"]);
                        }
                        if (request.CustomFilters.ContainsKey("TipoCategoriaId") && request.CustomFilters["TipoCategoriaId"] != string.Empty)
                        {
                            filtro.TipoCategoriaId = Convert.ToInt32(request.CustomFilters["TipoCategoriaId"]);
                        }
                        if (request.CustomFilters.ContainsKey("CentroIdUsuario") && request.CustomFilters["CentroIdUsuario"] != string.Empty)
                        {
                            filtro.CentroIdUsuario = Convert.ToInt32(request.CustomFilters["CentroIdUsuario"]);
                        }
                        if (request.CustomFilters.ContainsKey("CandidaturaOfertaId") && request.CustomFilters["CandidaturaOfertaId"] != string.Empty)
                        {
                            filtro.CandidaturaOfertaId = Convert.ToInt32(request.CustomFilters["CandidaturaOfertaId"]);
                        }

                        var listaDesglose = new List<DesgloseTecnologiaViewModel>();

                        foreach (var tecnologia in listaTecnologias)
                        {
                            var tecnologiaId = Convert.ToInt32(tecnologia.Value);
                            var nombreTecnologia = tecnologia.Text;
                            filtro.TipoTecnologiaId = tecnologiaId;

                            DesgloseTecnologiaViewModel desgloseTecnologia = new DesgloseTecnologiaViewModel()
                            {
                                FechaInicio = filtro.FechaInicio,
                                FechaFin = filtro.FechaFin,
                                TecnologiaId = tecnologiaId,
                                NombreTecnologia = nombreTecnologia,
                                CategoriaId = filtro.TipoCategoriaId,
                                CentroIdUsuario = filtro.CentroIdUsuario,
                                DatosFiltradoCV = GetDatosFunnelFiltradoCV(filtro).DatosFiltradoCV
                            };

                            if (desgloseTecnologia.DatosFiltradoCV.TotalCreados != 0)
                            {
                                //Para que haya menos carga en BBDD no se cargan los siguientes datos si la tecnologia no tiene candidaturas creadas
                                desgloseTecnologia.DatosEntrevistas = GetDatosFunnelEntrevistas(filtro).DatosEntrevistas;
                                desgloseTecnologia.DatosCartaOferta = GetDatosCartaOferta(filtro).DatosCartaOferta;

                                listaDesglose.Add(desgloseTecnologia);

                            }
                        }

                        //Esto se hace para las candidaturas que no tuvieran tecnología asignada
                        var tecnologiaIdNull = 0;
                        var nombreTecnologiaNull = "Sin tecnología";
                        filtro.TipoTecnologiaId = tecnologiaIdNull;

                        DesgloseTecnologiaViewModel desgloseTecnologiaNull = new DesgloseTecnologiaViewModel()
                        {
                            FechaInicio = filtro.FechaInicio,
                            FechaFin = filtro.FechaFin,
                            TecnologiaId = tecnologiaIdNull,
                            NombreTecnologia = nombreTecnologiaNull,
                            CategoriaId = filtro.TipoCategoriaId,
                            CentroIdUsuario = filtro.CentroIdUsuario,
                            DatosFiltradoCV = GetDatosFunnelFiltradoCV(filtro).DatosFiltradoCV
                        };


                        if (desgloseTecnologiaNull.DatosFiltradoCV.TotalCreados != 0)
                        {
                            //Para que haya menos carga en BBDD no se cargan los siguientes datos si la tecnologia no tiene candidaturas creadas
                            desgloseTecnologiaNull.DatosEntrevistas = GetDatosFunnelEntrevistas(filtro).DatosEntrevistas;
                            desgloseTecnologiaNull.DatosCartaOferta = GetDatosCartaOferta(filtro).DatosCartaOferta;

                            listaDesglose.Add(desgloseTecnologiaNull);

                        }


                        response.TotalElementos = listaDesglose.Count;

                        listaDesglose = listaDesglose.ApplyColumnSettings(request).ToList();

                        response.IsValid = true;
                        response.ListaDesgloseTecnologia = listaDesglose;
                    }
                    else
                    {
                        response.ListaDesgloseTecnologia = new List<DesgloseTecnologiaViewModel>();
                        response.TotalElementos = 0;
                    }                   
                }
                else
                {
                    response.ListaDesgloseTecnologia = new List<DesgloseTecnologiaViewModel>();
                    response.TotalElementos = 0;
                }
                response.IsValid = true;


            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }
            return response;
        }

        public GetDatosDesgloseCategoriaResponse GetDatosDesgloseCategoria(DataTableRequest request, IEnumerable<SelectListItem> listaCategorias)
        {
            var response = new GetDatosDesgloseCategoriaResponse();

            try
            {
                if (request.CustomFilters != null && request.CustomFilters.ContainsKey("BuscarCategoria"))
                {
                    var buscarCategoria = request.CustomFilters["BuscarCategoria"];
                    if (!string.IsNullOrEmpty(buscarCategoria))
                    {
                        var filtro = new FiltroFunnelProcesosViewModel();

                        if (request.CustomFilters.ContainsKey("FechaInicio") && request.CustomFilters["FechaInicio"] != string.Empty)
                        {
                            filtro.FechaInicio = Convert.ToDateTime(request.CustomFilters["FechaInicio"]);
                        }
                        else
                        {
                            filtro.FechaInicio = DateTime.Today.AddDays(-365);

                        }
                        if (request.CustomFilters.ContainsKey("FechaFin") && request.CustomFilters["FechaFin"] != string.Empty)
                        {
                            filtro.FechaFin = Convert.ToDateTime(request.CustomFilters["FechaFin"]);
                        }
                        if (request.CustomFilters.ContainsKey("TipoTecnologiaId") && request.CustomFilters["TipoTecnologiaId"] != string.Empty)
                        {
                            filtro.TipoTecnologiaId = Convert.ToInt32(request.CustomFilters["TipoTecnologiaId"]);
                        }
                        if (request.CustomFilters.ContainsKey("CentroIdUsuario") && request.CustomFilters["CentroIdUsuario"] != string.Empty)
                        {
                            filtro.CentroIdUsuario = Convert.ToInt32(request.CustomFilters["CentroIdUsuario"]);
                        }
                        if (request.CustomFilters.ContainsKey("CandidaturaOfertaId") && request.CustomFilters["CandidaturaOfertaId"] != string.Empty)
                        {
                            filtro.CandidaturaOfertaId = Convert.ToInt32(request.CustomFilters["CandidaturaOfertaId"]);
                        }

                        var listaDesglose = new List<DesgloseCategoriaViewModel>();

                        foreach (var categoria in listaCategorias)
                        {
                            var categoriaId = Convert.ToInt32(categoria.Value);
                            var nombreCategoria = categoria.Text;
                            filtro.TipoCategoriaId = categoriaId;

                            DesgloseCategoriaViewModel desgloseTecnologia = new DesgloseCategoriaViewModel()
                            {
                                FechaInicio = filtro.FechaInicio,
                                FechaFin = filtro.FechaFin,
                                TecnologiaId = filtro.TipoTecnologiaId,
                                CategoriaId = categoriaId,
                                NombreCategoria = nombreCategoria,
                                CentroIdUsuario = filtro.CentroIdUsuario,
                                DatosFiltradoCV = GetDatosFunnelFiltradoCV(filtro).DatosFiltradoCV
                            };

                            if (desgloseTecnologia.DatosFiltradoCV.TotalCreados != 0)
                            {
                                //Para que haya menos carga en BBDD no se cargan los siguientes datos si la tecnologia no tiene candidaturas creadas
                                desgloseTecnologia.DatosEntrevistas = GetDatosFunnelEntrevistas(filtro).DatosEntrevistas;
                                desgloseTecnologia.DatosCartaOferta = GetDatosCartaOferta(filtro).DatosCartaOferta;

                                listaDesglose.Add(desgloseTecnologia);

                            }
                        }

                        //Esto se hace para las candidaturas que no tuvieran tecnología asignada
                        var categoriaIdNull = 0;
                        var nombreCategoriaNull = "Sin perfil";
                        filtro.TipoCategoriaId = categoriaIdNull;

                        DesgloseCategoriaViewModel desgloseCategoriaNull = new DesgloseCategoriaViewModel()
                        {
                            FechaInicio = filtro.FechaInicio,
                            FechaFin = filtro.FechaFin,
                            TecnologiaId = filtro.TipoTecnologiaId,
                            CategoriaId = categoriaIdNull,
                            NombreCategoria = nombreCategoriaNull,
                            CentroIdUsuario = filtro.CentroIdUsuario,
                            DatosFiltradoCV = GetDatosFunnelFiltradoCV(filtro).DatosFiltradoCV
                        };


                        if (desgloseCategoriaNull.DatosFiltradoCV.TotalCreados != 0)
                        {
                            //Para que haya menos carga en BBDD no se cargan los siguientes datos si la tecnologia no tiene candidaturas creadas
                            desgloseCategoriaNull.DatosEntrevistas = GetDatosFunnelEntrevistas(filtro).DatosEntrevistas;
                            desgloseCategoriaNull.DatosCartaOferta = GetDatosCartaOferta(filtro).DatosCartaOferta;

                            listaDesglose.Add(desgloseCategoriaNull);

                        }


                        response.TotalElementos = listaDesglose.Count;

                        listaDesglose = listaDesglose.ApplyColumnSettings(request).ToList();

                        response.IsValid = true;
                        response.ListaDesgloseCategoria = listaDesglose;
                    }
                    else
                    {
                        response.ListaDesgloseCategoria = new List<DesgloseCategoriaViewModel>();
                        response.TotalElementos = 0;
                    }
                }
                else
                {
                    response.ListaDesgloseCategoria = new List<DesgloseCategoriaViewModel>();
                    response.TotalElementos = 0;
                }
                response.IsValid = true;


            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }
            return response;
        }

        public GetDatosDesgloseTecnologiaCategoriaResponse GetDatosDesgloseTecnologiaCategoria(DataTableRequest request)
        {
            var response = new GetDatosDesgloseTecnologiaCategoriaResponse();

            try
            {
                if (request.CustomFilters != null && request.CustomFilters.ContainsKey("BuscarTecnologiaCategoria"))
                {
                    var buscarTecnologiaCategoria = request.CustomFilters["BuscarTecnologiaCategoria"];
                    if (!string.IsNullOrEmpty(buscarTecnologiaCategoria))
                    {
                        var filtro = new FiltroFunnelProcesosViewModel();

                        if (request.CustomFilters.ContainsKey("FechaInicio") && request.CustomFilters["FechaInicio"] != string.Empty)
                        {
                            filtro.FechaInicio = Convert.ToDateTime(request.CustomFilters["FechaInicio"]);
                        }
                        else
                        {
                            filtro.FechaInicio = DateTime.Today.AddDays(-365);

                        }
                        if (request.CustomFilters.ContainsKey("FechaFin") && request.CustomFilters["FechaFin"] != string.Empty)
                        {
                            filtro.FechaFin = Convert.ToDateTime(request.CustomFilters["FechaFin"]);
                        }
                        if (request.CustomFilters.ContainsKey("TipoTecnologiaId") && request.CustomFilters["TipoTecnologiaId"] != string.Empty)
                        {
                            filtro.TipoTecnologiaId = Convert.ToInt32(request.CustomFilters["TipoTecnologiaId"]);
                        }
                        if (request.CustomFilters.ContainsKey("TipoCategoriaId") && request.CustomFilters["TipoCategoriaId"] != string.Empty)
                        {
                            filtro.TipoCategoriaId = Convert.ToInt32(request.CustomFilters["TipoCategoriaId"]);
                        }
                        if (request.CustomFilters.ContainsKey("CentroIdUsuario") && request.CustomFilters["CentroIdUsuario"] != string.Empty)
                        {
                            filtro.CentroIdUsuario = Convert.ToInt32(request.CustomFilters["CentroIdUsuario"]);
                        }
                        if (request.CustomFilters.ContainsKey("CandidaturaOfertaId") && request.CustomFilters["CandidaturaOfertaId"] != string.Empty)
                        {
                            filtro.CandidaturaOfertaId = Convert.ToInt32(request.CustomFilters["CandidaturaOfertaId"]);
                        }

                        var listaDesglose = new List<DesgloseTecnologiaCategoriaViewModel>();

                        DesgloseTecnologiaCategoriaViewModel desgloseTecnologiaCategoria = new DesgloseTecnologiaCategoriaViewModel()
                        {   
                            FechaInicio = filtro.FechaInicio,
                            FechaFin = filtro.FechaFin,
                            TecnologiaId = filtro.TipoTecnologiaId,
                            CategoriaId = filtro.TipoCategoriaId,
                            CentroIdUsuario = filtro.CentroIdUsuario,
                            DatosFiltradoCV = GetDatosFunnelFiltradoCV(filtro).DatosFiltradoCV
                        };

                        if (desgloseTecnologiaCategoria.DatosFiltradoCV.TotalCreados != 0)
                        {
                            //Para que haya menos carga en BBDD no se cargan los siguientes datos si la tecnologia no tiene candidaturas creadas
                            desgloseTecnologiaCategoria.DatosEntrevistas = GetDatosFunnelEntrevistas(filtro).DatosEntrevistas;
                            desgloseTecnologiaCategoria.DatosCartaOferta = GetDatosCartaOferta(filtro).DatosCartaOferta;

                            listaDesglose.Add(desgloseTecnologiaCategoria);

                        }    

                        response.TotalElementos = listaDesglose.Count;

                        listaDesglose = listaDesglose.ApplyColumnSettings(request).ToList();

                        response.IsValid = true;
                        response.ListaDesgloseTecnologiaCategoria = listaDesglose;
                    }
                    else
                    {
                        response.ListaDesgloseTecnologiaCategoria = new List<DesgloseTecnologiaCategoriaViewModel>();
                        response.TotalElementos = 0;
                    }
                }
                else
                {
                    response.ListaDesgloseTecnologiaCategoria = new List<DesgloseTecnologiaCategoriaViewModel>();
                    response.TotalElementos = 0;
                }
                response.IsValid = true;


            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }
            return response;
        }



        public GetDatosFiltradoCVResponse GetDatosFunnelFiltradoCV(FiltroFunnelProcesosViewModel model)
        {
            var response = new GetDatosFiltradoCVResponse
            {
                DatosFiltradoCV = new DatosFiltradoCVViewModel()
            };

            try
            {
                if(model.FechaInicio == null)
                {
                    model.FechaInicio = DateTime.Today.AddDays(-365);
                }   
                
                var listaCandidaturasCreadas = _candidaturaRepository.GetByCriteria(x => x.IsActivo && x.Created >= model.FechaInicio 
                                                                                    && x.EtapaCandidaturaId != (int)TipoEtapaCandidaturaEnum.Inicio
                                                                                    && x.EstadoCandidaturaId != (int)TipoEstadoCandidaturaEnum.Recontactado).ToList();
                var listaCandidaturasFiltradoDescarte = listaCandidaturasCreadas.Where(x=> x.EstadoCandidaturaId == (int)TipoEstadoCandidaturaEnum.Descartado
                                                                                                  && (x.EtapaCandidaturaId == (int)TipoEtapaCandidaturaEnum.FiltradoTecnico
                                                                                                  || x.EtapaCandidaturaId == (int)TipoEtapaCandidaturaEnum.FiltradoTelefonico)).ToList();
                var listaCandidaturasFiltradoRenuncia = listaCandidaturasCreadas.Where(x => x.EstadoCandidaturaId == (int)TipoEstadoCandidaturaEnum.Renuncia
                                                                                                 && (x.EtapaCandidaturaId == (int)TipoEtapaCandidaturaEnum.FiltradoTecnico
                                                                                                 || x.EtapaCandidaturaId == (int)TipoEtapaCandidaturaEnum.FiltradoTelefonico)).ToList();

                var listaCandidaturasFiltradoStandBy = listaCandidaturasCreadas.Where(x=> x.EstadoCandidaturaId == (int)TipoEstadoCandidaturaEnum.StandBy
                                                                                 && (x.EtapaCandidaturaId == (int)TipoEtapaCandidaturaEnum.FiltradoTecnico
                                                                                 || x.EtapaCandidaturaId == (int)TipoEtapaCandidaturaEnum.FiltradoTelefonico)).ToList();

                var listaCandidaturasPendienteFiltrado = listaCandidaturasCreadas.Where(x => (x.EtapaCandidaturaId == (int)TipoEtapaCandidaturaEnum.FiltradoTecnico
                                                                                    || x.EtapaCandidaturaId == (int)TipoEtapaCandidaturaEnum.FiltradoTelefonico)
                                                                                    && (x.EstadoCandidaturaId == (int)TipoEstadoCandidaturaEnum.FiltradoPeople
                                                                                    || x.EstadoCandidaturaId == (int)TipoEstadoCandidaturaEnum.Entrevista)).ToList(); 


                var listaCandidaturasFiltradoSupera = listaCandidaturasCreadas.Except(listaCandidaturasFiltradoDescarte).Except(listaCandidaturasFiltradoRenuncia)
                                                                               .Except(listaCandidaturasFiltradoStandBy).Except(listaCandidaturasPendienteFiltrado).ToList();

                if(model.FechaFin != null)
                {
                    listaCandidaturasCreadas = listaCandidaturasCreadas.Where(x => x.Created <= model.FechaFin).ToList();
                    listaCandidaturasFiltradoDescarte = listaCandidaturasFiltradoDescarte.Where(x => x.Created <= model.FechaFin).ToList();
                    listaCandidaturasFiltradoRenuncia = listaCandidaturasFiltradoRenuncia.Where(x => x.Created <= model.FechaFin).ToList();
                    listaCandidaturasFiltradoStandBy = listaCandidaturasFiltradoStandBy.Where(x => x.Created <= model.FechaFin).ToList();
                    listaCandidaturasPendienteFiltrado = listaCandidaturasPendienteFiltrado.Where(x => x.Created <= model.FechaFin).ToList();
                    listaCandidaturasFiltradoSupera = listaCandidaturasFiltradoSupera.Where(x => x.Created <= model.FechaFin).ToList();
                }
                if (model.TipoTecnologiaId != null)
                {
                    if(model.TipoTecnologiaId == 0)
                    {
                        listaCandidaturasCreadas = listaCandidaturasCreadas.Where(x => x.TipoTecnologiaId == null).ToList();
                        listaCandidaturasFiltradoDescarte = listaCandidaturasFiltradoDescarte.Where(x => x.TipoTecnologiaId == null).ToList();
                        listaCandidaturasFiltradoRenuncia = listaCandidaturasFiltradoRenuncia.Where(x => x.TipoTecnologiaId == null).ToList();
                        listaCandidaturasFiltradoStandBy = listaCandidaturasFiltradoStandBy.Where(x => x.TipoTecnologiaId == null).ToList();
                        listaCandidaturasPendienteFiltrado = listaCandidaturasPendienteFiltrado.Where(x => x.TipoTecnologiaId == null).ToList();
                        listaCandidaturasFiltradoSupera = listaCandidaturasFiltradoSupera.Where(x => x.TipoTecnologiaId == null).ToList();
                    }
                    else
                    {
                        listaCandidaturasCreadas = listaCandidaturasCreadas.Where(x => x.TipoTecnologiaId == model.TipoTecnologiaId).ToList();
                        listaCandidaturasFiltradoDescarte = listaCandidaturasFiltradoDescarte.Where(x => x.TipoTecnologiaId == model.TipoTecnologiaId).ToList();
                        listaCandidaturasFiltradoRenuncia = listaCandidaturasFiltradoRenuncia.Where(x => x.TipoTecnologiaId == model.TipoTecnologiaId).ToList();
                        listaCandidaturasFiltradoStandBy = listaCandidaturasFiltradoStandBy.Where(x => x.TipoTecnologiaId == model.TipoTecnologiaId).ToList();
                        listaCandidaturasPendienteFiltrado = listaCandidaturasPendienteFiltrado.Where(x => x.TipoTecnologiaId == model.TipoTecnologiaId).ToList();
                        listaCandidaturasFiltradoSupera = listaCandidaturasFiltradoSupera.Where(x => x.TipoTecnologiaId == model.TipoTecnologiaId).ToList();

                    }

                    
                }
                if (model.TipoCategoriaId != null)
                {
                    if (model.TipoCategoriaId == 0)
                    {
                        listaCandidaturasCreadas = listaCandidaturasCreadas.Where(x => x.CategoriaId == null).ToList();
                        listaCandidaturasFiltradoDescarte = listaCandidaturasFiltradoDescarte.Where(x => x.CategoriaId == null).ToList();
                        listaCandidaturasFiltradoRenuncia = listaCandidaturasFiltradoRenuncia.Where(x => x.CategoriaId == null).ToList();
                        listaCandidaturasFiltradoStandBy = listaCandidaturasFiltradoStandBy.Where(x => x.CategoriaId == null).ToList();
                        listaCandidaturasPendienteFiltrado = listaCandidaturasPendienteFiltrado.Where(x => x.CategoriaId == null).ToList();
                        listaCandidaturasFiltradoSupera = listaCandidaturasFiltradoSupera.Where(x => x.CategoriaId == null).ToList();
                    }
                    else
                    {
                        listaCandidaturasCreadas = listaCandidaturasCreadas.Where(x => x.CategoriaId == model.TipoCategoriaId).ToList();
                        listaCandidaturasFiltradoDescarte = listaCandidaturasFiltradoDescarte.Where(x => x.CategoriaId == model.TipoCategoriaId).ToList();
                        listaCandidaturasFiltradoRenuncia = listaCandidaturasFiltradoRenuncia.Where(x => x.CategoriaId == model.TipoCategoriaId).ToList();
                        listaCandidaturasFiltradoStandBy = listaCandidaturasFiltradoStandBy.Where(x => x.CategoriaId == model.TipoCategoriaId).ToList();
                        listaCandidaturasPendienteFiltrado = listaCandidaturasPendienteFiltrado.Where(x => x.CategoriaId == model.TipoCategoriaId).ToList();
                        listaCandidaturasFiltradoSupera = listaCandidaturasFiltradoSupera.Where(x => x.CategoriaId == model.TipoCategoriaId).ToList();
                    }
                }
                if (model.CentroIdUsuario != null)
                {
                    listaCandidaturasCreadas = listaCandidaturasCreadas.Where(x => x.Usuario.Centro.CentroId == model.CentroIdUsuario).ToList();
                    listaCandidaturasFiltradoDescarte = listaCandidaturasFiltradoDescarte.Where(x => x.Usuario.Centro.CentroId == model.CentroIdUsuario).ToList();
                    listaCandidaturasFiltradoRenuncia = listaCandidaturasFiltradoRenuncia.Where(x => x.Usuario.Centro.CentroId == model.CentroIdUsuario).ToList();
                    listaCandidaturasFiltradoStandBy = listaCandidaturasFiltradoStandBy.Where(x => x.Usuario.Centro.CentroId == model.CentroIdUsuario).ToList();
                    listaCandidaturasPendienteFiltrado = listaCandidaturasPendienteFiltrado.Where(x => x.Usuario.Centro.CentroId == model.CentroIdUsuario).ToList();
                    listaCandidaturasFiltradoSupera = listaCandidaturasFiltradoSupera.Where(x => x.Usuario.Centro.CentroId == model.CentroIdUsuario).ToList();
                }

                if (model.CandidaturaOfertaId != null)
                {
                    listaCandidaturasCreadas = listaCandidaturasCreadas.Where(x => x.CandidaturaOfertaId == model.CandidaturaOfertaId).ToList();
                    listaCandidaturasFiltradoDescarte = listaCandidaturasFiltradoDescarte.Where(x => x.CandidaturaOfertaId == model.CandidaturaOfertaId).ToList();
                    listaCandidaturasFiltradoRenuncia = listaCandidaturasFiltradoRenuncia.Where(x => x.CandidaturaOfertaId == model.CandidaturaOfertaId).ToList();
                    listaCandidaturasFiltradoStandBy = listaCandidaturasFiltradoStandBy.Where(x => x.CandidaturaOfertaId == model.CandidaturaOfertaId).ToList();
                    listaCandidaturasPendienteFiltrado = listaCandidaturasPendienteFiltrado.Where(x => x.CandidaturaOfertaId == model.CandidaturaOfertaId).ToList();
                    listaCandidaturasFiltradoSupera = listaCandidaturasFiltradoSupera.Where(x => x.CandidaturaOfertaId == model.CandidaturaOfertaId).ToList();
                }

                response.DatosFiltradoCV.TotalCreados = listaCandidaturasCreadas.Count;
                response.DatosFiltradoCV.NumeroDescartados = listaCandidaturasFiltradoDescarte.Count;
                response.DatosFiltradoCV.NumeroRenuncias = listaCandidaturasFiltradoRenuncia.Count;
                response.DatosFiltradoCV.NumeroStandBy = listaCandidaturasFiltradoStandBy.Count;
                response.DatosFiltradoCV.NumeroPendienteFiltrados = listaCandidaturasPendienteFiltrado.Count;
                response.DatosFiltradoCV.NumeroSupera = listaCandidaturasFiltradoSupera.Count;
                response.IsValid = true;
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }


        public GetDatosEntrevistasResponse GetDatosFunnelEntrevistas(FiltroFunnelProcesosViewModel model)
        {
            var response = new GetDatosEntrevistasResponse
            {
                DatosEntrevistas = new DatosEntrevistasViewModel()
            };

            try
            {
                var listaEstadosAgendadas = new List<int>
                {
                    (int)TipoEstadoCandidaturaEnum.Entrevista,
                    (int)TipoEstadoCandidaturaEnum.SegundaEntrevista,
                    (int)TipoEstadoCandidaturaEnum.CartaOferta,
                    (int)TipoEstadoCandidaturaEnum.Descartado,
                    (int)TipoEstadoCandidaturaEnum.Renuncia,
                    (int)TipoEstadoCandidaturaEnum.RechazaOferta,
                    (int)TipoEstadoCandidaturaEnum.Contratado,
                    (int)TipoEstadoCandidaturaEnum.StandBy
                };

                var listaEtapasAgendadas = new List<int>
                {
                    (int)TipoEtapaCandidaturaEnum.AgendarEntrevistas,
                    (int)TipoEtapaCandidaturaEnum.FeedbackPrimeraEntrevista,
                    (int)TipoEtapaCandidaturaEnum.PendienteDecisionSegundaEntrevista,
                    (int)TipoEtapaCandidaturaEnum.AgendarSegundaEntrevista,
                    (int)TipoEtapaCandidaturaEnum.FeedbackSegundaEntrevista,
                    (int)TipoEtapaCandidaturaEnum.PendienteDecisionCartaOferta,
                    (int)TipoEtapaCandidaturaEnum.AgendarCartaOferta,
                    (int)TipoEtapaCandidaturaEnum.FeedbackCartaOferta,
                    (int)TipoEtapaCandidaturaEnum.Fin
                };



                if (model.FechaInicio == null)
                {
                    model.FechaInicio = DateTime.Today.AddDays(-365);
                }
                

                var listaEntrevistasAgendadas = _candidaturaRepository.GetByCriteria(x => x.IsActivo && x.Created >= model.FechaInicio
                                                                                     && listaEstadosAgendadas.Contains(x.EstadoCandidaturaId)
                                                                                     && listaEtapasAgendadas.Contains(x.EtapaCandidaturaId)).ToList();

                var listaEntrevistasDescartadas = listaEntrevistasAgendadas.Where(x => x.EstadoCandidaturaId == (int)TipoEstadoCandidaturaEnum.Descartado
                                                                                               && (x.EtapaCandidaturaId == (int)TipoEtapaCandidaturaEnum.AgendarEntrevistas
                                                                                               || x.EtapaCandidaturaId == (int)TipoEtapaCandidaturaEnum.FeedbackPrimeraEntrevista
                                                                                               || x.EtapaCandidaturaId == (int)TipoEtapaCandidaturaEnum.PendienteDecisionSegundaEntrevista
                                                                                               || x.EtapaCandidaturaId == (int)TipoEtapaCandidaturaEnum.AgendarSegundaEntrevista
                                                                                               || x.EtapaCandidaturaId == (int)TipoEtapaCandidaturaEnum.FeedbackSegundaEntrevista)).ToList();

                var listaEntrevistasRenuncia = listaEntrevistasAgendadas.Where(x => x.EstadoCandidaturaId == (int)TipoEstadoCandidaturaEnum.Renuncia
                                                                                               && (x.EtapaCandidaturaId == (int)TipoEtapaCandidaturaEnum.AgendarEntrevistas
                                                                                               || x.EtapaCandidaturaId == (int)TipoEtapaCandidaturaEnum.FeedbackPrimeraEntrevista
                                                                                               || x.EtapaCandidaturaId == (int)TipoEtapaCandidaturaEnum.PendienteDecisionSegundaEntrevista
                                                                                               || x.EtapaCandidaturaId == (int)TipoEtapaCandidaturaEnum.AgendarSegundaEntrevista
                                                                                               || x.EtapaCandidaturaId == (int)TipoEtapaCandidaturaEnum.FeedbackSegundaEntrevista)).ToList();

                var listaEntrevistasStandBy = listaEntrevistasAgendadas.Where(x => x.EstadoCandidaturaId == (int)TipoEstadoCandidaturaEnum.StandBy
                                                                                              && (x.EtapaCandidaturaId == (int)TipoEtapaCandidaturaEnum.AgendarEntrevistas
                                                                                              || x.EtapaCandidaturaId == (int)TipoEtapaCandidaturaEnum.FeedbackPrimeraEntrevista
                                                                                              || x.EtapaCandidaturaId == (int)TipoEtapaCandidaturaEnum.PendienteDecisionSegundaEntrevista
                                                                                              || x.EtapaCandidaturaId == (int)TipoEtapaCandidaturaEnum.AgendarSegundaEntrevista
                                                                                              || x.EtapaCandidaturaId == (int)TipoEtapaCandidaturaEnum.FeedbackSegundaEntrevista)).ToList();

                var listaEntrevistasPendientesCitacion = listaEntrevistasAgendadas.Where(x => (x.EstadoCandidaturaId == (int)TipoEstadoCandidaturaEnum.Entrevista
                                                                               || x.EstadoCandidaturaId == (int)TipoEstadoCandidaturaEnum.SegundaEntrevista)
                                                                               && (x.EtapaCandidaturaId == (int)TipoEtapaCandidaturaEnum.AgendarEntrevistas
                                                                               || x.EtapaCandidaturaId == (int)TipoEtapaCandidaturaEnum.AgendarSegundaEntrevista)).ToList();


                var listaEntrevistasFeedback = listaEntrevistasAgendadas.Where(x => (x.EstadoCandidaturaId == (int)TipoEstadoCandidaturaEnum.Entrevista
                                                                               || x.EstadoCandidaturaId == (int)TipoEstadoCandidaturaEnum.SegundaEntrevista)
                                                                               && (x.EtapaCandidaturaId == (int)TipoEtapaCandidaturaEnum.FeedbackPrimeraEntrevista
                                                                               || x.EtapaCandidaturaId == (int)TipoEtapaCandidaturaEnum.PendienteDecisionSegundaEntrevista
                                                                               || x.EtapaCandidaturaId == (int)TipoEtapaCandidaturaEnum.FeedbackSegundaEntrevista)).ToList();




                var listaEntrevistasSuperadas = listaEntrevistasAgendadas.Where(x => (x.EstadoCandidaturaId == (int)TipoEstadoCandidaturaEnum.RechazaOferta
                                                                     || x.EstadoCandidaturaId == (int)TipoEstadoCandidaturaEnum.Descartado
                                                                     || x.EstadoCandidaturaId == (int)TipoEstadoCandidaturaEnum.Contratado
                                                                     || x.EstadoCandidaturaId == (int)TipoEstadoCandidaturaEnum.CartaOferta
                                                                     || x.EstadoCandidaturaId == (int)TipoEstadoCandidaturaEnum.StandBy
                                                                     || x.EstadoCandidaturaId == (int)TipoEstadoCandidaturaEnum.Renuncia) &&
                                                                     (x.EtapaCandidaturaId == (int)TipoEtapaCandidaturaEnum.PendienteDecisionCartaOferta
                                                                     || x.EtapaCandidaturaId == (int)TipoEtapaCandidaturaEnum.AgendarCartaOferta
                                                                     || x.EtapaCandidaturaId == (int)TipoEtapaCandidaturaEnum.FeedbackCartaOferta
                                                                     || x.EtapaCandidaturaId == (int)TipoEtapaCandidaturaEnum.Fin)).ToList();

             
                if (model.FechaFin != null)
                {
                    listaEntrevistasAgendadas = listaEntrevistasAgendadas.Where(x => x.Created <= model.FechaFin).ToList();
                    listaEntrevistasPendientesCitacion = listaEntrevistasPendientesCitacion.Where(x => x.Created <= model.FechaFin).ToList();
                    listaEntrevistasFeedback = listaEntrevistasFeedback.Where(x => x.Created <= model.FechaFin).ToList();
                    listaEntrevistasDescartadas = listaEntrevistasDescartadas.Where(x => x.Created <= model.FechaFin).ToList();
                    listaEntrevistasRenuncia = listaEntrevistasRenuncia.Where(x => x.Created <= model.FechaFin).ToList();
                    listaEntrevistasStandBy = listaEntrevistasStandBy.Where(x => x.Created <= model.FechaFin).ToList();
                    listaEntrevistasSuperadas = listaEntrevistasSuperadas.Where(x => x.Created <= model.FechaFin).ToList();
                }
                if (model.TipoTecnologiaId != null)
                {
                    if(model.TipoTecnologiaId == 0)
                    {
                        listaEntrevistasAgendadas = listaEntrevistasAgendadas.Where(x => x.TipoTecnologiaId == null).ToList();
                        listaEntrevistasPendientesCitacion = listaEntrevistasPendientesCitacion.Where(x => x.TipoTecnologiaId == null).ToList();
                        listaEntrevistasFeedback = listaEntrevistasFeedback.Where(x => x.TipoTecnologiaId == null).ToList();
                        listaEntrevistasDescartadas = listaEntrevistasDescartadas.Where(x => x.TipoTecnologiaId == null).ToList();
                        listaEntrevistasRenuncia = listaEntrevistasRenuncia.Where(x => x.TipoTecnologiaId == null).ToList();
                        listaEntrevistasStandBy = listaEntrevistasStandBy.Where(x => x.TipoTecnologiaId == null).ToList();
                        listaEntrevistasSuperadas = listaEntrevistasSuperadas.Where(x => x.TipoTecnologiaId == null).ToList();
                    }
                    else
                    {
                        listaEntrevistasAgendadas = listaEntrevistasAgendadas.Where(x => x.TipoTecnologiaId == model.TipoTecnologiaId).ToList();
                        listaEntrevistasPendientesCitacion = listaEntrevistasPendientesCitacion.Where(x => x.TipoTecnologiaId == model.TipoTecnologiaId).ToList();
                        listaEntrevistasFeedback = listaEntrevistasFeedback.Where(x => x.TipoTecnologiaId == model.TipoTecnologiaId).ToList();
                        listaEntrevistasDescartadas = listaEntrevistasDescartadas.Where(x => x.TipoTecnologiaId == model.TipoTecnologiaId).ToList();
                        listaEntrevistasRenuncia = listaEntrevistasRenuncia.Where(x => x.TipoTecnologiaId == model.TipoTecnologiaId).ToList();
                        listaEntrevistasStandBy = listaEntrevistasStandBy.Where(x => x.TipoTecnologiaId == model.TipoTecnologiaId).ToList();
                        listaEntrevistasSuperadas = listaEntrevistasSuperadas.Where(x => x.TipoTecnologiaId == model.TipoTecnologiaId).ToList();

                    }
                }
                if (model.TipoCategoriaId != null)
                {
                    if(model.TipoCategoriaId == 0)
                    {
                        listaEntrevistasAgendadas = listaEntrevistasAgendadas.Where(x => x.CategoriaId == null).ToList();
                        listaEntrevistasPendientesCitacion = listaEntrevistasPendientesCitacion.Where(x => x.CategoriaId == null).ToList();
                        listaEntrevistasFeedback = listaEntrevistasFeedback.Where(x => x.CategoriaId == null).ToList();
                        listaEntrevistasDescartadas = listaEntrevistasDescartadas.Where(x => x.CategoriaId == null).ToList();
                        listaEntrevistasRenuncia = listaEntrevistasRenuncia.Where(x => x.CategoriaId == null).ToList();
                        listaEntrevistasStandBy = listaEntrevistasStandBy.Where(x => x.CategoriaId == null).ToList();
                        listaEntrevistasSuperadas = listaEntrevistasSuperadas.Where(x => x.CategoriaId == null).ToList();
                    }
                    else
                    {
                        listaEntrevistasAgendadas = listaEntrevistasAgendadas.Where(x => x.CategoriaId == model.TipoCategoriaId).ToList();
                        listaEntrevistasPendientesCitacion = listaEntrevistasPendientesCitacion.Where(x => x.CategoriaId == model.TipoCategoriaId).ToList();
                        listaEntrevistasFeedback = listaEntrevistasFeedback.Where(x => x.CategoriaId == model.TipoCategoriaId).ToList();
                        listaEntrevistasDescartadas = listaEntrevistasDescartadas.Where(x => x.CategoriaId == model.TipoCategoriaId).ToList();
                        listaEntrevistasRenuncia = listaEntrevistasRenuncia.Where(x => x.CategoriaId == model.TipoCategoriaId).ToList();
                        listaEntrevistasStandBy = listaEntrevistasStandBy.Where(x => x.CategoriaId == model.TipoCategoriaId).ToList();
                        listaEntrevistasSuperadas = listaEntrevistasSuperadas.Where(x => x.CategoriaId == model.TipoCategoriaId).ToList();
                    }
                    
                }
                if (model.CentroIdUsuario != null)
                {
                    listaEntrevistasAgendadas = listaEntrevistasAgendadas.Where(x => x.Usuario.Centro.CentroId == model.CentroIdUsuario).ToList();
                    listaEntrevistasPendientesCitacion = listaEntrevistasPendientesCitacion.Where(x => x.Usuario.Centro.CentroId == model.CentroIdUsuario).ToList();
                    listaEntrevistasFeedback = listaEntrevistasFeedback.Where(x => x.Usuario.Centro.CentroId == model.CentroIdUsuario).ToList();
                    listaEntrevistasDescartadas = listaEntrevistasDescartadas.Where(x => x.Usuario.Centro.CentroId == model.CentroIdUsuario).ToList();
                    listaEntrevistasRenuncia = listaEntrevistasRenuncia.Where(x => x.Usuario.Centro.CentroId == model.CentroIdUsuario).ToList();
                    listaEntrevistasStandBy = listaEntrevistasStandBy.Where(x => x.Usuario.Centro.CentroId == model.CentroIdUsuario).ToList();
                    listaEntrevistasSuperadas = listaEntrevistasSuperadas.Where(x => x.Usuario.Centro.CentroId == model.CentroIdUsuario).ToList();
                }

                if (model.CandidaturaOfertaId != null)
                {
                    listaEntrevistasAgendadas = listaEntrevistasAgendadas.Where(x => x.CandidaturaOfertaId == model.CandidaturaOfertaId).ToList();
                    listaEntrevistasPendientesCitacion = listaEntrevistasPendientesCitacion.Where(x => x.CandidaturaOfertaId == model.CandidaturaOfertaId).ToList();
                    listaEntrevistasFeedback = listaEntrevistasFeedback.Where(x => x.CandidaturaOfertaId == model.CandidaturaOfertaId).ToList();
                    listaEntrevistasDescartadas = listaEntrevistasDescartadas.Where(x => x.CandidaturaOfertaId == model.CandidaturaOfertaId).ToList();
                    listaEntrevistasRenuncia = listaEntrevistasRenuncia.Where(x => x.CandidaturaOfertaId == model.CandidaturaOfertaId).ToList();
                    listaEntrevistasStandBy = listaEntrevistasStandBy.Where(x => x.CandidaturaOfertaId == model.CandidaturaOfertaId).ToList();
                    listaEntrevistasSuperadas = listaEntrevistasSuperadas.Where(x => x.CandidaturaOfertaId == model.CandidaturaOfertaId).ToList();
                }

                response.DatosEntrevistas.TotalAgendadas = listaEntrevistasAgendadas.Count;
                response.DatosEntrevistas.NumeroPendientesCitacion = listaEntrevistasPendientesCitacion.Count;
                response.DatosEntrevistas.NumeroFeedback = listaEntrevistasFeedback.Count;
                response.DatosEntrevistas.NumeroDescartados = listaEntrevistasDescartadas.Count;
                response.DatosEntrevistas.NumeroRenuncias = listaEntrevistasRenuncia.Count;
                response.DatosEntrevistas.NumeroStandBy = listaEntrevistasStandBy.Count;
                response.DatosEntrevistas.NumeroSupera = listaEntrevistasSuperadas.Count;

                response.IsValid = true;
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public GetDatosCartaOfertaResponse GetDatosCartaOferta(FiltroFunnelProcesosViewModel model)
        {
            var response = new GetDatosCartaOfertaResponse
            {
                DatosCartaOferta = new DatosCartaOfertaViewModel()
            };

            try
            {
                var listaEstadosAgendadas = new List<int>
                {                      
                    (int)TipoEstadoCandidaturaEnum.RechazaOferta,
                    (int)TipoEstadoCandidaturaEnum.Descartado,
                    (int)TipoEstadoCandidaturaEnum.Contratado,
                    (int)TipoEstadoCandidaturaEnum.CartaOferta,
                    (int)TipoEstadoCandidaturaEnum.StandBy,
                    (int)TipoEstadoCandidaturaEnum.Renuncia

                };

                var listaEtapasAgendadas = new List<int>
                {
                    (int)TipoEtapaCandidaturaEnum.PendienteDecisionCartaOferta,
                    (int)TipoEtapaCandidaturaEnum.AgendarCartaOferta,
                    (int)TipoEtapaCandidaturaEnum.FeedbackCartaOferta,
                    (int)TipoEtapaCandidaturaEnum.Fin
                };
           



                if (model.FechaInicio == null)
                {
                    model.FechaInicio = DateTime.Today.AddDays(-365);
                }


                var listaCartaOfertasAgendadas = _candidaturaRepository.GetByCriteria(x => x.IsActivo && x.Created >= model.FechaInicio
                                                                                     && listaEstadosAgendadas.Contains(x.EstadoCandidaturaId)
                                                                                     && (listaEtapasAgendadas.Contains(x.EtapaCandidaturaId))).ToList();


                var listaCartaOfertasPendientesCitacion = listaCartaOfertasAgendadas.Where(x => x.EstadoCandidaturaId == (int)TipoEstadoCandidaturaEnum.CartaOferta
                                                                               && (x.EtapaCandidaturaId == (int)TipoEtapaCandidaturaEnum.AgendarCartaOferta)
                                                                               || x.EtapaCandidaturaId == (int)TipoEtapaCandidaturaEnum.PendienteDecisionCartaOferta).ToList();

                var listaCartaOfertasFeedBack = listaCartaOfertasAgendadas.Where(x => x.EstadoCandidaturaId == (int)TipoEstadoCandidaturaEnum.CartaOferta
                                                                               && x.EtapaCandidaturaId == (int)TipoEtapaCandidaturaEnum.FeedbackCartaOferta).ToList();

                var listaCartaOfertasRenuncia = listaCartaOfertasAgendadas.Where(x => x.EstadoCandidaturaId == (int)TipoEstadoCandidaturaEnum.Renuncia).ToList();

                var listaCartaOfertasDescarte = listaCartaOfertasAgendadas.Where(x => x.EstadoCandidaturaId == (int)TipoEstadoCandidaturaEnum.Descartado).ToList();

                var listaCartaOfertasAceptadas = listaCartaOfertasAgendadas.Where(x => x.EstadoCandidaturaId == (int)TipoEstadoCandidaturaEnum.Contratado).ToList();
                var listaCartaOfertasRechazadas = listaCartaOfertasAgendadas.Where(x=> x.EstadoCandidaturaId == (int)TipoEstadoCandidaturaEnum.RechazaOferta).ToList();

                var listaCartaOfertasStandBy = listaCartaOfertasAgendadas.Where(x => x.EstadoCandidaturaId == (int)TipoEstadoCandidaturaEnum.StandBy).ToList();



                if (model.FechaFin != null)
                {
                    listaCartaOfertasAgendadas = listaCartaOfertasAgendadas.Where(x => x.Created <= model.FechaFin).ToList();
                    listaCartaOfertasPendientesCitacion = listaCartaOfertasPendientesCitacion.Where(x => x.Created <= model.FechaFin).ToList();
                    listaCartaOfertasFeedBack = listaCartaOfertasFeedBack.Where(x => x.Created <= model.FechaFin).ToList();
                    listaCartaOfertasRenuncia = listaCartaOfertasRenuncia.Where(x => x.Created <= model.FechaFin).ToList();
                    listaCartaOfertasDescarte = listaCartaOfertasDescarte.Where(x => x.Created <= model.FechaFin).ToList();
                    listaCartaOfertasAceptadas = listaCartaOfertasAceptadas.Where(x => x.Created <= model.FechaFin).ToList();
                    listaCartaOfertasRechazadas = listaCartaOfertasRechazadas.Where(x => x.Created <= model.FechaFin).ToList();
                    listaCartaOfertasStandBy = listaCartaOfertasStandBy.Where(x => x.Created <= model.FechaFin).ToList();

                }
                if (model.TipoTecnologiaId != null)
                {
                    if(model.TipoTecnologiaId == 0)
                    {
                        listaCartaOfertasAgendadas = listaCartaOfertasAgendadas.Where(x => x.TipoTecnologiaId == null).ToList();
                        listaCartaOfertasPendientesCitacion = listaCartaOfertasPendientesCitacion.Where(x => x.TipoTecnologiaId == null).ToList();
                        listaCartaOfertasFeedBack = listaCartaOfertasFeedBack.Where(x => x.TipoTecnologiaId == null).ToList();
                        listaCartaOfertasRenuncia = listaCartaOfertasRenuncia.Where(x => x.TipoTecnologiaId == null).ToList();
                        listaCartaOfertasDescarte = listaCartaOfertasDescarte.Where(x => x.TipoTecnologiaId == null).ToList();
                        listaCartaOfertasAceptadas = listaCartaOfertasAceptadas.Where(x => x.TipoTecnologiaId == null).ToList();
                        listaCartaOfertasRechazadas = listaCartaOfertasRechazadas.Where(x => x.TipoTecnologiaId == null).ToList();
                        listaCartaOfertasStandBy = listaCartaOfertasStandBy.Where(x => x.TipoTecnologiaId == null).ToList();

                    }
                    else
                    {
                        listaCartaOfertasAgendadas = listaCartaOfertasAgendadas.Where(x => x.TipoTecnologiaId == model.TipoTecnologiaId).ToList();
                        listaCartaOfertasPendientesCitacion = listaCartaOfertasPendientesCitacion.Where(x => x.TipoTecnologiaId == model.TipoTecnologiaId).ToList();
                        listaCartaOfertasFeedBack = listaCartaOfertasFeedBack.Where(x => x.TipoTecnologiaId == model.TipoTecnologiaId).ToList();
                        listaCartaOfertasRenuncia = listaCartaOfertasRenuncia.Where(x => x.TipoTecnologiaId == model.TipoTecnologiaId).ToList();
                        listaCartaOfertasDescarte = listaCartaOfertasDescarte.Where(x => x.TipoTecnologiaId == model.TipoTecnologiaId).ToList();
                        listaCartaOfertasAceptadas = listaCartaOfertasAceptadas.Where(x => x.TipoTecnologiaId == model.TipoTecnologiaId).ToList();
                        listaCartaOfertasRechazadas = listaCartaOfertasRechazadas.Where(x => x.TipoTecnologiaId == model.TipoTecnologiaId).ToList();
                        listaCartaOfertasStandBy = listaCartaOfertasStandBy.Where(x => x.TipoTecnologiaId == model.TipoTecnologiaId).ToList();
                    }
                }
                if (model.TipoCategoriaId != null)
                {
                    if(model.TipoCategoriaId == 0)
                    {
                        listaCartaOfertasAgendadas = listaCartaOfertasAgendadas.Where(x => x.CategoriaId == null).ToList();
                        listaCartaOfertasPendientesCitacion = listaCartaOfertasPendientesCitacion.Where(x => x.CategoriaId == null).ToList();
                        listaCartaOfertasFeedBack = listaCartaOfertasFeedBack.Where(x => x.CategoriaId == null).ToList();
                        listaCartaOfertasRenuncia = listaCartaOfertasRenuncia.Where(x => x.CategoriaId == null).ToList();
                        listaCartaOfertasDescarte = listaCartaOfertasDescarte.Where(x => x.CategoriaId == null).ToList();
                        listaCartaOfertasAceptadas = listaCartaOfertasAceptadas.Where(x => x.CategoriaId == null).ToList();
                        listaCartaOfertasRechazadas = listaCartaOfertasRechazadas.Where(x => x.CategoriaId == null).ToList();
                        listaCartaOfertasStandBy = listaCartaOfertasStandBy.Where(x => x.CategoriaId == null).ToList();
                    }
                    else
                    {
                        listaCartaOfertasAgendadas = listaCartaOfertasAgendadas.Where(x => x.CategoriaId == model.TipoCategoriaId).ToList();
                        listaCartaOfertasPendientesCitacion = listaCartaOfertasPendientesCitacion.Where(x => x.CategoriaId == model.TipoCategoriaId).ToList();
                        listaCartaOfertasFeedBack = listaCartaOfertasFeedBack.Where(x => x.CategoriaId == model.TipoCategoriaId).ToList();
                        listaCartaOfertasRenuncia = listaCartaOfertasRenuncia.Where(x => x.CategoriaId == model.TipoCategoriaId).ToList();
                        listaCartaOfertasDescarte = listaCartaOfertasDescarte.Where(x => x.CategoriaId == model.TipoCategoriaId).ToList();
                        listaCartaOfertasAceptadas = listaCartaOfertasAceptadas.Where(x => x.CategoriaId == model.TipoCategoriaId).ToList();
                        listaCartaOfertasRechazadas = listaCartaOfertasRechazadas.Where(x => x.CategoriaId == model.TipoCategoriaId).ToList();
                        listaCartaOfertasStandBy = listaCartaOfertasStandBy.Where(x => x.CategoriaId == model.TipoCategoriaId).ToList();
                    }
                    
                }
                if (model.CentroIdUsuario != null)
                {
                    listaCartaOfertasAgendadas = listaCartaOfertasAgendadas.Where(x => x.Usuario.Centro.CentroId == model.CentroIdUsuario).ToList();
                    listaCartaOfertasPendientesCitacion = listaCartaOfertasPendientesCitacion.Where(x => x.Usuario.Centro.CentroId == model.CentroIdUsuario).ToList();
                    listaCartaOfertasFeedBack = listaCartaOfertasFeedBack.Where(x => x.Usuario.Centro.CentroId == model.CentroIdUsuario).ToList();
                    listaCartaOfertasRenuncia = listaCartaOfertasRenuncia.Where(x => x.Usuario.Centro.CentroId == model.CentroIdUsuario).ToList();
                    listaCartaOfertasDescarte = listaCartaOfertasDescarte.Where(x => x.Usuario.Centro.CentroId == model.CentroIdUsuario).ToList();
                    listaCartaOfertasAceptadas = listaCartaOfertasAceptadas.Where(x => x.Usuario.Centro.CentroId == model.CentroIdUsuario).ToList();
                    listaCartaOfertasRechazadas = listaCartaOfertasRechazadas.Where(x => x.Usuario.Centro.CentroId == model.CentroIdUsuario).ToList();
                    listaCartaOfertasStandBy = listaCartaOfertasStandBy.Where(x => x.Usuario.Centro.CentroId == model.CentroIdUsuario).ToList();
                }

                if (model.CandidaturaOfertaId != null)
                {
                    listaCartaOfertasAgendadas = listaCartaOfertasAgendadas.Where(x => x.CandidaturaOfertaId == model.CandidaturaOfertaId).ToList();
                    listaCartaOfertasPendientesCitacion = listaCartaOfertasPendientesCitacion.Where(x => x.CandidaturaOfertaId == model.CandidaturaOfertaId).ToList();
                    listaCartaOfertasFeedBack = listaCartaOfertasFeedBack.Where(x => x.CandidaturaOfertaId == model.CandidaturaOfertaId).ToList();
                    listaCartaOfertasRenuncia = listaCartaOfertasRenuncia.Where(x => x.CandidaturaOfertaId == model.CandidaturaOfertaId).ToList();
                    listaCartaOfertasDescarte = listaCartaOfertasDescarte.Where(x => x.CandidaturaOfertaId == model.CandidaturaOfertaId).ToList();
                    listaCartaOfertasAceptadas = listaCartaOfertasAceptadas.Where(x => x.CandidaturaOfertaId == model.CandidaturaOfertaId).ToList();
                    listaCartaOfertasRechazadas = listaCartaOfertasRechazadas.Where(x => x.CandidaturaOfertaId == model.CandidaturaOfertaId).ToList();
                    listaCartaOfertasStandBy = listaCartaOfertasStandBy.Where(x => x.CandidaturaOfertaId == model.CandidaturaOfertaId).ToList();
                }

                response.DatosCartaOferta.TotalAgendadas = listaCartaOfertasAgendadas.Count;
                response.DatosCartaOferta.NumeroPendientesCitacion = listaCartaOfertasPendientesCitacion.Count;
                response.DatosCartaOferta.NumeroFeedback = listaCartaOfertasFeedBack.Count;
                response.DatosCartaOferta.NumeroRenuncias = listaCartaOfertasRenuncia.Count;
                response.DatosCartaOferta.NumeroAceptadas = listaCartaOfertasAceptadas.Count;
                response.DatosCartaOferta.NumeroDescartadas = listaCartaOfertasDescarte.Count;
                response.DatosCartaOferta.NumeroRechazadas = listaCartaOfertasRechazadas.Count;
                response.DatosCartaOferta.NumeroStandBy = listaCartaOfertasStandBy.Count;

                response.IsValid = true;
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public GetCandidaturasModalResponse GetCandidaturasModal(DataTableRequest request)
        {
            var response = new GetCandidaturasModalResponse();

            try
            {

                if (request.CustomFilters.ContainsKey("BuscarModalCandidatura"))
                {
                    var buscar = request.CustomFilters["BuscarModalCandidatura"];
                    if (!string.IsNullOrEmpty(buscar))
                    {
                        var query = FilterString(request.CustomFilters);
                        var filtered = query.ApplyColumnSettings(request, FunnelProcesosMapper.GetPropertiePath);
                        response.CandidaturaModalViewModel = filtered.ConvertToCandidaturaModalRowViewModel();
                        response.TotalElementos = query.Count();
                    }
                    else
                    {
                        response.CandidaturaModalViewModel = new List<CandidaturaModalRowViewModel>();
                        response.TotalElementos = 0;
                    }

                   
                }
                else
                {
                    response.CandidaturaModalViewModel = new List<CandidaturaModalRowViewModel>();
                    response.TotalElementos = 0;
                }

                response.IsValid = true;

            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        #endregion

        #region privateMethods

        private IQueryable<Candidatura> FilterString(IDictionary<string, string> customFilter)
        {
            var query = _candidaturaRepository.GetAll();

            query = query.Where(x => x.IsActivo);

            if (customFilter.ContainsKey("FechaInicio") && (customFilter["FechaInicio"] != string.Empty))
            {
                var FechaInicio = Convert.ToDateTime(customFilter["FechaInicio"]);
                query = query.Where(x => x.Created >= FechaInicio);
            }

            if (customFilter.ContainsKey("FechaFin") && (customFilter["FechaFin"] != string.Empty))
            {
                var FechaFin = Convert.ToDateTime(customFilter["FechaFin"]);
                query = query.Where(x => x.Created <= FechaFin);
            }

            if (customFilter.ContainsKey("TipoTecnologiaId") && (customFilter["TipoTecnologiaId"] != string.Empty))
            {
                var TipoTecnologiaId = Convert.ToInt32(customFilter["TipoTecnologiaId"]);

                if(TipoTecnologiaId == 0)
                {
                    query = query.Where(x => x.TipoTecnologiaId == null);
                }
                else
                {
                    query = query.Where(x => x.TipoTecnologiaId == TipoTecnologiaId);
                }
            }

            if (customFilter.ContainsKey("TipoCategoriaId") && (customFilter["TipoCategoriaId"] != string.Empty))
            {
                var CategoriaId = Convert.ToInt32(customFilter["TipoCategoriaId"]);

                if (CategoriaId == 0)
                {
                    query = query.Where(x => x.CategoriaId == null);
                }
                else
                {
                    query = query.Where(x => x.CategoriaId == CategoriaId);
                }
            }

            if (customFilter.ContainsKey("Estados") && (customFilter["Estados"] != string.Empty))
            {
                var ids = customFilter["Estados"].Split(',').Select(x => int.Parse(x.Trim()));            
                query = query.Where(x => ids.Contains(x.EstadoCandidaturaId));
            } 

            if (customFilter.ContainsKey("Etapas") && (customFilter["Etapas"] != string.Empty))
            {
                var ids = customFilter["Etapas"].Split(',').Select(x => int.Parse(x.Trim()));
                query = query.Where(x => ids.Contains(x.EtapaCandidaturaId));
            }

            if (customFilter.ContainsKey("CandidaturaOfertaId") && (customFilter["CandidaturaOfertaId"] != string.Empty))
            {
                var CandidaturaOfertaId = Convert.ToInt32(customFilter["CandidaturaOfertaId"]);

                query = query.Where(x => x.CandidaturaOfertaId == CandidaturaOfertaId);
            }

            //se filtra por el centro del usuario logado salvo cuando hay un Centro de busqueda que buscaria los del centro en cuestion (CentroSearch)
            if (customFilter.ContainsKey("CentroIdUsuario") && (customFilter["CentroIdUsuario"] != string.Empty))
            {           
                var CentroUsuarioId = Convert.ToInt32(customFilter["CentroIdUsuario"]);
                query = query.Where(x => x.Usuario.Centro.CentroId == CentroUsuarioId);
                
            }

            return query;
        }

        #endregion

    }
}
