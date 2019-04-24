using Recruiting.Application.Candidaturas.Enums;
using Recruiting.Application.Dashboard.ViewModels;
using Recruiting.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Recruiting.Application.Dashboard.Mappers
{
    public static class DashboardMapper
	{
        public static AdministradorDashboard UpdateAdministradorDashboard(this AdministradorDashboard administradorDashboard, AlertasAdministradorViewModel viewModel)
        {           
            administradorDashboard.UsuarioId = viewModel.UsuarioId;
            administradorDashboard.NecesidadesCreadasModificadas = viewModel.NecesidadesCreadasModificadas;
            administradorDashboard.PrimeraEntrevista = viewModel.PrimeraEntrevista;
            administradorDashboard.SubEntrevistaPrimeraEntrevista = viewModel.SubEntrevistaPrimeraEntrevista;
            administradorDashboard.SegundaEntrevista = viewModel.SegundaEntrevista;
            administradorDashboard.SubEntrevistaSegundaEntrevista = viewModel.SubEntrevistaSegundaEntrevista;
            administradorDashboard.CartaOferta = viewModel.CartaOferta;
            administradorDashboard.CvPendienteFiltro = viewModel.CvPendienteFiltro;
            administradorDashboard.CandidaturaStandBy = viewModel.CandidaturaStandBy;
            administradorDashboard.BecarioStandBy = viewModel.BecarioStandBy;
            administradorDashboard.IsActivo = true;

            return administradorDashboard;
        }

        public static AlertasAdministradorViewModel ConvertToAlertasAdministradorViewModel(this AdministradorDashboard administradorDashboard)
        {
            AlertasAdministradorViewModel viewModel = new AlertasAdministradorViewModel
            {
                UsuarioId = administradorDashboard.UsuarioId,
                NecesidadesCreadasModificadas = administradorDashboard.NecesidadesCreadasModificadas,
                PrimeraEntrevista = administradorDashboard.PrimeraEntrevista,
                SubEntrevistaPrimeraEntrevista = administradorDashboard.SubEntrevistaPrimeraEntrevista,
                SegundaEntrevista = administradorDashboard.SegundaEntrevista,
                SubEntrevistaSegundaEntrevista = administradorDashboard.SubEntrevistaSegundaEntrevista,
                CartaOferta = administradorDashboard.CartaOferta,
                CvPendienteFiltro = administradorDashboard.CvPendienteFiltro,
                CandidaturaStandBy = administradorDashboard.CandidaturaStandBy,
                BecarioStandBy = administradorDashboard.BecarioStandBy
            };

            return viewModel;
        }

        public static IEnumerable<EntrevistasFueraFechaRowViewModel> ConvertToEntrevistasFueraFechaRowViewModel(this IEnumerable<Entrevista> entrevistaList)
		{
			var entrevistasFueraFechaRowViewModelList = new List<EntrevistasFueraFechaRowViewModel>();


			if (entrevistaList == null) return entrevistasFueraFechaRowViewModelList;

			entrevistasFueraFechaRowViewModelList = entrevistaList.Select(x => x.ConvertToEntrevistasFueraFechaRowViewModel()).ToList();

			return entrevistasFueraFechaRowViewModelList;

		}

		public static IEnumerable<EntrevistasFueraFechaRowViewModel> ConvertToEntrevistasFueraFechaRowViewModel(this IEnumerable<SubEntrevista> subEntrevistaList)
		{
			var entrevistasFueraFechaRowViewModelList = new List<EntrevistasFueraFechaRowViewModel>();


			if (subEntrevistaList == null) return entrevistasFueraFechaRowViewModelList;

			entrevistasFueraFechaRowViewModelList = subEntrevistaList.Where(x => !x.Completada).Select(x => x.ConvertToEntrevistasFueraFechaRowViewModel()).ToList();

			return entrevistasFueraFechaRowViewModelList;

		}

		private static EntrevistasFueraFechaRowViewModel ConvertToEntrevistasFueraFechaRowViewModel( this Entrevista entrevista)
		{

            var entrevistasFueraFechaRowViewModel = new EntrevistasFueraFechaRowViewModel
            {
                Agendada = entrevista.FechaEntrevista,
                Candidato = entrevista.Candidatura.Candidato.Nombre + " " + entrevista.Candidatura.Candidato.Apellidos,
                EntrevistadorId = entrevista.EntrevistadorId,
                Entrevistador = entrevista.Entrevistador.Nombre,
                CandidaturaId = entrevista.CandidaturaId,
                Perfil = entrevista.Candidatura.CategoriaId != null ? entrevista.Candidatura.Categoria.Nombre : string.Empty,
                Tecnologia = entrevista.Candidatura.TipoTecnologia != null ? entrevista.Candidatura.TipoTecnologia.Nombre : string.Empty,
                EntrevistaId = entrevista.EntrevistaId,
                Centro = entrevista.Usuario.CentroId != null ? entrevista.Usuario.Centro.Nombre : string.Empty,
                DiasDeRetraso = Convert.ToInt32((DateTime.Now.Date - entrevista.FechaEntrevista.Date).TotalDays)
            };
            return entrevistasFueraFechaRowViewModel;
		}



		private static EntrevistasFueraFechaRowViewModel ConvertToEntrevistasFueraFechaRowViewModel(this SubEntrevista subEntrevista)
		{

            var entrevistasFueraFechaRowViewModel = new EntrevistasFueraFechaRowViewModel
            {
                Agendada = subEntrevista.FechaEntrevista,
                Candidato = subEntrevista.Entrevista.Candidatura.Candidato.Nombre + " " + subEntrevista.Entrevista.Candidatura.Candidato.Apellidos,
                EntrevistadorId = subEntrevista.EntrevistadorId,
                Entrevistador = subEntrevista.Entrevistador.Nombre,
                Perfil = subEntrevista.Entrevista.Candidatura.Categoria != null ? subEntrevista.Entrevista.Candidatura.Categoria.Nombre : string.Empty,
                Tecnologia = subEntrevista.Entrevista.Candidatura.TipoTecnologia != null ? subEntrevista.Entrevista.Candidatura.TipoTecnologia.Nombre : string.Empty,
                CandidaturaId = subEntrevista.Entrevista.CandidaturaId,
                EntrevistaId = subEntrevista.Entrevista.EntrevistaId,
                TipoSubEntrevista = subEntrevista.TipoSubEntrevista.Nombre,
                Centro = subEntrevista.Entrevista.Usuario.CentroId != null ? subEntrevista.Entrevista.Usuario.Centro.Nombre : string.Empty,
                DiasDeRetraso = Convert.ToInt32((DateTime.Now.Date - subEntrevista.FechaEntrevista.Date).TotalDays)
            };
            return entrevistasFueraFechaRowViewModel;
		}


		public static IEnumerable<EntrevistasFueraFechaRowViewModel> ConvertToCartasFueraFechaRowViewModel(this IEnumerable<CartaOferta> cartasList)
		{
			var entrevistasFueraFechaRowViewModelList = new List<EntrevistasFueraFechaRowViewModel>();


			if (cartasList == null) return entrevistasFueraFechaRowViewModelList;

			entrevistasFueraFechaRowViewModelList = cartasList.Select(x => x.ConvertToCartasFueraFechaRowViewModel()).ToList();

			return entrevistasFueraFechaRowViewModelList;

		}


		private static EntrevistasFueraFechaRowViewModel ConvertToCartasFueraFechaRowViewModel(this CartaOferta carta)
		{
            var entrevistasFueraFechaRowViewModel = new EntrevistasFueraFechaRowViewModel
            {
                Agendada = carta.FechaCartaOferta,
                Candidato = carta.Candidatura.Candidato.Nombre + " " + carta.Candidatura.Candidato.Apellidos,
                Perfil = carta.Candidatura.Categoria != null ? carta.Candidatura.Categoria.Nombre : string.Empty,
                Tecnologia = carta.Candidatura.TipoTecnologia != null ? carta.Candidatura.TipoTecnologia.Nombre : string.Empty,
                EntrevistadorId = carta.EntrevistadorId,
                Entrevistador = carta.Entrevistador.Nombre,
                CandidaturaId = carta.CandidaturaId,
                EntrevistaId = carta.CartaOfertaId,
                Centro = carta.Usuario.CentroId != null ? carta.Usuario.Centro.Nombre : string.Empty
            };
            return entrevistasFueraFechaRowViewModel;
		}

		public static IEnumerable<EntrevistasPlanificadasRowViewModel> ConvertToEntrevistasPlanificadasRowViewModel(this IEnumerable<SubEntrevista> subEntrevistaList)
		{
			if (subEntrevistaList == null) return new List<EntrevistasPlanificadasRowViewModel>();

			var entrevistasPlanificadasRowViewModelList = subEntrevistaList.Select(x => x.ConvertToEntrevistasPlanificadasViewModel()).ToList();

			return entrevistasPlanificadasRowViewModelList;

		}

		public static IEnumerable<EntrevistasPlanificadasRowViewModel> ConvertToEntrevistasPlanificadasRowViewModel(this IEnumerable<Entrevista> entrevistaList)
		{
			if (entrevistaList == null) return new List<EntrevistasPlanificadasRowViewModel>();

			var entrevistasPlanificadasRowViewModelList = entrevistaList.Select(x => x.ConvertToEntrevistasPlanificadasViewModel()).ToList();

			return entrevistasPlanificadasRowViewModelList;

		}

		public static IEnumerable<FiltradoPendienteViewModel> ConvertToFiltradoPendienteViewModelList(this IEnumerable<Candidatura> filtradoList)
		{
			if (filtradoList == null) return new List<FiltradoPendienteViewModel>();

			var filtradoPendienteViewModelList = filtradoList.Select(x => x.ConvertToFiltradoPendienteViewModel()).ToList();

			return filtradoPendienteViewModelList;

		}

		public static IEnumerable<CandidaturasPendienteEntrevistaOCartaOfertaViewModel> ConvertToCandidaturaPendienteEntrevistaViewModelList(this IEnumerable<Candidatura> filtradoList)
		{

			if (filtradoList == null) return new List<CandidaturasPendienteEntrevistaOCartaOfertaViewModel>();

			var candidaturaPendienteEntrevistaViewModelList = filtradoList.Select(x => x.ConvertToCandidaturaPendienteEntrevista()).ToList();

			return candidaturaPendienteEntrevistaViewModelList;

		}

		public static IEnumerable<CandidaturasPendienteEntrevistaOCartaOfertaViewModel> ConvertToCandidaturaPendienteCartaOfertaViewModelList(this IEnumerable<Candidatura> filtradoList)
		{
			if (filtradoList == null) return new List<CandidaturasPendienteEntrevistaOCartaOfertaViewModel>();

			var candidaturaPendienteCartaOfertaViewModelList = filtradoList.Select(x => x.ConvertToCandidaturaPendienteCartaOferta()).ToList();

			return candidaturaPendienteCartaOfertaViewModelList;

		}

		private static CandidaturasPendienteEntrevistaOCartaOfertaViewModel ConvertToCandidaturaPendienteCartaOferta(this Candidatura candidatura)
		{

            var candidaturaPendienteCartaOferta = new CandidaturasPendienteEntrevistaOCartaOfertaViewModel
            {
                Candidato = candidatura.Candidato.Nombre + " " + candidatura.Candidato.Apellidos,
                CandidaturaId = candidatura.CandidaturaId,
                Centro = candidatura.Usuario.Centro.Nombre,
                FechaModificacion = candidatura.Modified.Value
            };


            return candidaturaPendienteCartaOferta;
		}

		public static IEnumerable<CandidaturasPendienteStandByViewModel> ConvertToCandidaturaPendienteStandByViewModelList(this IEnumerable<Candidatura> candidaturaList)
		{

			if (candidaturaList == null) return new List<CandidaturasPendienteStandByViewModel>();

			var candidaturaPendienteStandByViewModelList = candidaturaList.Select(x => x.ConvertToCandidaturaPendienteStandBy()).ToList();

			return candidaturaPendienteStandByViewModelList;

		}
		private static CandidaturasPendienteStandByViewModel ConvertToCandidaturaPendienteStandBy(this Candidatura candidatura)
		{

            var candidaturaPendienteStandBy = new CandidaturasPendienteStandByViewModel
            {
                Candidato = candidatura.Candidato.Nombre + " " + candidatura.Candidato.Apellidos,
                CandidaturaId = candidatura.CandidaturaId,
                Centro = candidatura.Usuario.Centro.Nombre,
                Perfil = candidatura.CategoriaId != null ? candidatura.Categoria.Nombre : string.Empty,
                Tecnologia = candidatura.TipoTecnologia != null ? candidatura.TipoTecnologia.Nombre : string.Empty,
                FechaContactoStandBy = candidatura.FechaContactoStandBy.Value,
                FechaMostrar = candidatura.FechaContactoStandBy.Value.Day + "/" +
                                                       candidatura.FechaContactoStandBy.Value.Month + "/" + candidatura.FechaContactoStandBy.Value.Year,
                DiasDeRetraso = Convert.ToInt32((DateTime.Now.Date - candidatura.FechaContactoStandBy.Value.Date).TotalDays)
            };


            return candidaturaPendienteStandBy;
		}
		public static IEnumerable<BecariosPendientesStandByViewModel> ConvertToBecarioPendienteStandByViewModelList(this IEnumerable<Becario> becarioList)
		{
			if (becarioList == null) return new List<BecariosPendientesStandByViewModel>();

			var becarioPendienteStandByViewModelList = becarioList.Select(x => x.ConvertToBecarioPendienteStandBy()).ToList();

			return becarioPendienteStandByViewModelList;

		}

        private static BecariosPendientesStandByViewModel ConvertToBecarioPendienteStandBy(this Becario becario)
		{

            var becarioPendienteStandBy = new BecariosPendientesStandByViewModel
            {
                Candidato = becario.Candidato.Nombre + " " + becario.Candidato.Apellidos,
                BecarioId = becario.BecarioId,
                CentroProcedencia = becario.BecarioCentroProcedencia != null ? becario.BecarioCentroProcedencia.Centro : string.Empty,
                FechaContactoStandBy = becario.FechaContactoStandBy.Value,
                FechaMostrar = becario.FechaContactoStandBy.Value.Day + "/" +
                                                   becario.FechaContactoStandBy.Value.Month + "/" +
                                                   becario.FechaContactoStandBy.Value.Year,
                DiasDeRetraso = Convert.ToInt32((DateTime.Now.Date - becario.FechaContactoStandBy.Value.Date).TotalDays)
            };

            return becarioPendienteStandBy;
		}


		

		private static CandidaturasPendienteEntrevistaOCartaOfertaViewModel ConvertToCandidaturaPendienteEntrevista(this Candidatura candidatura)
		{

            var candidaturaPendienteEntrevista = new CandidaturasPendienteEntrevistaOCartaOfertaViewModel
            {
                Candidato = candidatura.Candidato.Nombre + " " + candidatura.Candidato.Apellidos,
                CandidaturaId = candidatura.CandidaturaId,
                Centro = candidatura.Usuario.Centro.Nombre,
                FechaModificacion = candidatura.Modified.Value
            };


            return candidaturaPendienteEntrevista;
		}

		private static FiltradoPendienteViewModel ConvertToFiltradoPendienteViewModel(this Candidatura candidatura)
		{

            var filtradoPendiente = new FiltradoPendienteViewModel
            {
                Candidato = candidatura.Candidato.Nombre + " " + candidatura.Candidato.Apellidos,
                CandidaturaId = candidatura.CandidaturaId,
                Perfil = candidatura.CategoriaId != null ? candidatura.Categoria.Nombre : string.Empty,
                Tecnologia = candidatura.TipoTecnologia != null ? candidatura.TipoTecnologia.Nombre : string.Empty,
                CvAvailable = (candidatura.UrlCV != null && candidatura.NombreCV != null),
                Creada = candidatura.Created,
                Centro = candidatura.Usuario.Centro.Nombre
            };

            if (candidatura.FiltradorId != null)
			{
				filtradoPendiente.EntrevistadorId = candidatura.Filtrador.UsuarioId;
				filtradoPendiente.Entrevistador = candidatura.Filtrador.Nombre;
			}
			else
			{
				filtradoPendiente.EntrevistadorId = null;
				filtradoPendiente.Entrevistador = null;
			}

			return filtradoPendiente;
		}

		private static EntrevistasPlanificadasRowViewModel ConvertToEntrevistasPlanificadasViewModel(this Entrevista entrevista)
		{

            var entrevistasPlanificadasRowViewModel = new EntrevistasPlanificadasRowViewModel
            {
                start = entrevista.FechaEntrevista.ToString("yyyy-MM-dd") + "T" + entrevista.FechaEntrevista.ToString("HH:mm:ss"),
                title = entrevista.Candidatura.Candidato.Nombre + " " + entrevista.Candidatura.Candidato.Apellidos,
                url = "/Candidaturas/EjecutarODetalle?CandidaturaId=" + entrevista.CandidaturaId + "&TipoEntrevistaProgramada=" + entrevista.TipoEntrevistaId,
                CandidaturaId = entrevista.CandidaturaId,
                TipoEntrevistaProgramada = entrevista.TipoEntrevistaId
            };

            if (entrevista.TipoEntrevistaId == (int)TipoEntrevistaEnum.PrimeraEntrevista)
			{
				if (entrevista.Candidatura.EstadoCandidaturaId == (int)TipoEstadoCandidaturaEnum.FiltradoPeople
					|| (entrevista.Candidatura.EstadoCandidaturaId == (int)TipoEstadoCandidaturaEnum.Entrevista))
				{
					entrevistasPlanificadasRowViewModel.className = "ccsPrimeraEntrevista";
				}
				else
				{
					entrevistasPlanificadasRowViewModel.className = "ccsPrimeraEntrevistaCompletada";
				}
			}
			else if (entrevista.TipoEntrevistaId == (int)TipoEntrevistaEnum.SegundaEntrevista)
			{
				if (entrevista.Candidatura.EstadoCandidaturaId == (int)TipoEstadoCandidaturaEnum.FiltradoPeople
					|| (entrevista.Candidatura.EstadoCandidaturaId == (int)TipoEstadoCandidaturaEnum.Entrevista)
					|| (entrevista.Candidatura.EstadoCandidaturaId == (int)TipoEstadoCandidaturaEnum.SegundaEntrevista))
				{
					entrevistasPlanificadasRowViewModel.className = "cssEntrevistaDos";
				}
				else
				{
					entrevistasPlanificadasRowViewModel.className = "cssEntrevistaDosCompletada";
				}
			}

			return entrevistasPlanificadasRowViewModel;
		}

		private static EntrevistasPlanificadasRowViewModel ConvertToEntrevistasPlanificadasViewModel(this SubEntrevista subEntrevista)
		{

			var entrevistasPlanificadasRowViewModel = new EntrevistasPlanificadasRowViewModel();

			var candidaturaId = subEntrevista.Entrevista.CandidaturaId;
			var tipoEntrevista = subEntrevista.Entrevista.TipoEntrevistaId;
			var entrevistadorId = subEntrevista.EntrevistadorId.Value;
			var vengoDeCandidaturas = true;

			var datosSubEntrevista = new ParametroSubEntrevistas
			{
				candidaturaId = candidaturaId,
				tipoEntrevista = tipoEntrevista,
				entrevistadorId = entrevistadorId,
				vengoDeCandidaturas = vengoDeCandidaturas
			};

			var datosSubEntrevistaJson = Newtonsoft.Json.JsonConvert.SerializeObject(datosSubEntrevista);

			entrevistasPlanificadasRowViewModel.start = subEntrevista.FechaEntrevista.ToString("yyyy-MM-dd") + "T" + subEntrevista.FechaEntrevista.ToString("HH:mm:ss");
			entrevistasPlanificadasRowViewModel.title = subEntrevista.Entrevista.Candidatura.Candidato.Nombre + " " + subEntrevista.Entrevista.Candidatura.Candidato.Apellidos;
			entrevistasPlanificadasRowViewModel.url = "/Candidaturas/EditarSubEntrevistaSubEntrevistador?candidaturaIdTipoEntrevistaEntrevistadorId=" + datosSubEntrevistaJson;
			entrevistasPlanificadasRowViewModel.CandidaturaId = subEntrevista.Entrevista.CandidaturaId;
			entrevistasPlanificadasRowViewModel.TipoEntrevistaProgramada = subEntrevista.Entrevista.TipoEntrevistaId;

			if (subEntrevista.TipoSubEntrevistaId == (int)TipoSubEntrevistaEnum.Competencial)
			{
				if(subEntrevista.Entrevista.TipoEntrevistaId == (int)TipoEntrevistaEnum.PrimeraEntrevista)
				{
					if (subEntrevista.Completada)
					{
						entrevistasPlanificadasRowViewModel.className = "ccsSubEntrevistaCompetencialCompletada cssBordePrimeraEntrevista";
					}
					else
					{
						entrevistasPlanificadasRowViewModel.className = "ccsSubEntrevistaCompetencial cssBordePrimeraEntrevista";
					}
				}
				else if (subEntrevista.Entrevista.TipoEntrevistaId == (int)TipoEntrevistaEnum.SegundaEntrevista)
				{
					if (subEntrevista.Completada)
					{
						entrevistasPlanificadasRowViewModel.className = "ccsSubEntrevistaCompetencialCompletada cssBordeSegundaEntrevista";
					}
					else
					{
						entrevistasPlanificadasRowViewModel.className = "ccsSubEntrevistaCompetencial cssBordeSegundaEntrevista";
					}
				}             
			}
			else if (subEntrevista.TipoSubEntrevistaId == (int)TipoSubEntrevistaEnum.Tecnica)
			{
				if (subEntrevista.Entrevista.TipoEntrevistaId == (int)TipoEntrevistaEnum.PrimeraEntrevista)
				{
					if (subEntrevista.Completada)
					{
						entrevistasPlanificadasRowViewModel.className = "ccsSubEntrevistaTecnicaCompletada cssBordePrimeraEntrevista";
					}
					else
					{
						entrevistasPlanificadasRowViewModel.className = "ccsSubEntrevistaTecnica cssBordePrimeraEntrevista";
					}
				}
				else if (subEntrevista.Entrevista.TipoEntrevistaId == (int)TipoEntrevistaEnum.SegundaEntrevista)
				{
					if (subEntrevista.Completada)
					{
						entrevistasPlanificadasRowViewModel.className = "ccsSubEntrevistaTecnicaCompletada cssBordeSegundaEntrevista";
					}
					else
					{
						entrevistasPlanificadasRowViewModel.className = "ccsSubEntrevistaTecnica cssBordeSegundaEntrevista";
					}
				}
			}
			else if (subEntrevista.TipoSubEntrevistaId == (int)TipoSubEntrevistaEnum.Gerente)
			{
				if (subEntrevista.Entrevista.TipoEntrevistaId == (int)TipoEntrevistaEnum.PrimeraEntrevista)
				{
					if (subEntrevista.Completada)
					{
						entrevistasPlanificadasRowViewModel.className = "ccsSubEntrevistaGerenteCompletada cssBordePrimeraEntrevista";
					}
					else
					{
						entrevistasPlanificadasRowViewModel.className = "ccsSubEntrevistaGerente cssBordePrimeraEntrevista";
					}
				}
				else if (subEntrevista.Entrevista.TipoEntrevistaId == (int)TipoEntrevistaEnum.SegundaEntrevista)
				{
					if (subEntrevista.Completada)
					{
						entrevistasPlanificadasRowViewModel.className = "ccsSubEntrevistaGerenteCompletada cssBordeSegundaEntrevista";
					}
					else
					{
						entrevistasPlanificadasRowViewModel.className = "ccsSubEntrevistaGerente cssBordeSegundaEntrevista";
					}
				}
			}
			else if (subEntrevista.TipoSubEntrevistaId == (int)TipoSubEntrevistaEnum.Idioma)
			{
				if (subEntrevista.Entrevista.TipoEntrevistaId == (int)TipoEntrevistaEnum.PrimeraEntrevista)
				{
					if (subEntrevista.Completada)
					{
						entrevistasPlanificadasRowViewModel.className = "ccsSubEntrevistaIdiomaCompletada cssBordePrimeraEntrevista";
					}
					else
					{
						entrevistasPlanificadasRowViewModel.className = "ccsSubEntrevistaIdioma cssBordePrimeraEntrevista";
					}
				}
				else if (subEntrevista.Entrevista.TipoEntrevistaId == (int)TipoEntrevistaEnum.SegundaEntrevista)
				{
					if (subEntrevista.Completada)
					{
						entrevistasPlanificadasRowViewModel.className = "ccsSubEntrevistaIdiomaCompletada cssBordeSegundaEntrevista";
					}
					else
					{
						entrevistasPlanificadasRowViewModel.className = "ccsSubEntrevistaIdioma cssBordeSegundaEntrevista";
					}
				}
			}

			return entrevistasPlanificadasRowViewModel;
		}

		public static IEnumerable<EntrevistasPlanificadasRowViewModel> ConvertToEntrevistasPlanificadasRowViewModel(this IEnumerable<CartaOferta> cartaOfertaList)
		{
			if (cartaOfertaList == null) return new List<EntrevistasPlanificadasRowViewModel>();

			var entrevistasPlanificadasRowViewModelList = cartaOfertaList.Select(x => x.ConvertToEntrevistasPlanificadasViewModel()).ToList();

			return entrevistasPlanificadasRowViewModelList;

		}

		private static EntrevistasPlanificadasRowViewModel ConvertToEntrevistasPlanificadasViewModel(this CartaOferta cartaOferta)
		{

            var entrevistasPlanificadasRowViewModel = new EntrevistasPlanificadasRowViewModel
            {
                start = cartaOferta.FechaCartaOferta.ToString("yyyy-MM-dd") + "T" + cartaOferta.FechaCartaOferta.ToString("HH:mm:ss"),
                title = cartaOferta.Candidatura.Candidato.Nombre + " " + cartaOferta.Candidatura.Candidato.Apellidos,


                url = "/Candidaturas/CompletarCartaOferta/" + cartaOferta.CandidaturaId
            };

            return entrevistasPlanificadasRowViewModel;
		}
		private class ParametroSubEntrevistas
		{
			public int candidaturaId;
			public int tipoEntrevista;
			public int entrevistadorId;
			public bool vengoDeCandidaturas;
		}
	}
}


