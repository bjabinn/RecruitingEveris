using Recruiting.Application.Candidaturas.Enums;
using Recruiting.Application.FunnelProcesos.ViewModels;
using Recruiting.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Recruiting.Application.FunnelProcesos.Mappers
{
    public static class FunnelProcesosMapper
	{
        #region Mapper

        public static IEnumerable<CandidaturaModalRowViewModel> ConvertToCandidaturaModalRowViewModel(this IEnumerable<Candidatura> candidaturaList)
        {
            var candidaturaModalRowViewModelList = new List<CandidaturaModalRowViewModel>();

            if (candidaturaList == null) return candidaturaModalRowViewModelList;

            candidaturaModalRowViewModelList = candidaturaList.Select(x => x.ConvertToCandidaturaModalRowViewModel()).ToList();

            return candidaturaModalRowViewModelList;
        }

        public static string GetPropertiePath( string name )
		{
			string attributeName = null;

			switch( name )
			{
				case "Estado":
					attributeName = "EstadoCandidaturaId";
					break;

                case "Oferta":
                    attributeName = "Oferta.Nombre";
                    break;

                case "Etapa":
					attributeName = "EtapaCandidaturaId";
					break;
				case "Perfil":
					attributeName = "CategoriaId";
					break;
				case "Entrevistador":
                    attributeName = "Entrevista.EntrevistadorId";
                    break;
				case "Candidato":
					attributeName = "CandidatoId";
					break;
				case "CandidaturaId":
					attributeName = "CandidaturaId";
					break;
				case "Agendada":
                    attributeName = "Entrevistas.FechaEntrevista";
                    break;
				case "TipoTecnologia":
					attributeName = "TipoTecnologiaId";
					break;
                case "Centro":
                    attributeName = "Usuario.Centro.Nombre";
                    break;
                case "Modulo":
                    attributeName = "TipoModulo.Nombre";
                    break;
                case "OrigenCvId":
                    attributeName = "OrigenCvId";
                    break;
            }
			return attributeName;
		}

        #region Private Methods


        private static CandidaturaModalRowViewModel ConvertToCandidaturaModalRowViewModel(this Candidatura candidatura)
        {
            var entrevistadorNombre = string.Empty;
            int? entrevistadorId = null;
            var agendada = new DateTime?();
            var ofertaNombre = String.Empty;

            var tupla = GetEntrevistadorYAgendada(candidatura, candidatura.EtapaCandidatura.TipoEtapaCandidaturaId);
            if (tupla != null)
            {
                if (tupla.Item1 != null)
                {
                    entrevistadorNombre = tupla.Item1.Nombre;
                    entrevistadorId = tupla.Item1.UsuarioId;
                }
                agendada = (tupla.Item2.HasValue) ? (tupla.Item2) : null;
            }
   
            var candidaturaRowViewModel = new CandidaturaModalRowViewModel()
            {
                CandidaturaId = candidatura.CandidaturaId,
                Estado = candidatura.EstadoCandidatura.EstadoCandidatura,
                Etapa = candidatura.EtapaCandidatura.EtapaCandidatura,
                Candidato = candidatura.Candidato.Nombre + ' ' + candidatura.Candidato.Apellidos,
                Oferta = ofertaNombre,
                OrigenCvId = candidatura.OrigenCvId,
                FuenteReclutamientoId = candidatura.FuenteReclutamientoId,
                Entrevistador = entrevistadorNombre,
                EntrevistadorId = entrevistadorId,
                Agendada = (agendada.HasValue) ? agendada.Value : new DateTime(),
                CandidatoId = candidatura.CandidatoId,
                EstadoId = candidatura.EstadoCandidaturaId,
                EtapaId = candidatura.EtapaCandidaturaId,
                TipoTecnologiaId = candidatura.TipoTecnologiaId,
                Modulo = (candidatura.ModuloId.HasValue) ? candidatura.TipoModulo.Nombre : "",
                Centro = candidatura.Usuario.CentroId != null ? candidatura.Usuario.Centro.Nombre : string.Empty,
                FiltradorId = candidatura.FiltradorId,
                SubEntrevistadoresString = "",
            };  

            if (candidatura.Categoria != null)
            {
                candidaturaRowViewModel.Perfil = candidatura.Categoria.Nombre;
            }

            candidaturaRowViewModel.TipoTecnologia = candidatura.TipoTecnologia == null ? null : (candidatura.TipoTecnologia.Nombre ?? null);
            if (candidaturaRowViewModel.OrigenCvId != null)
            {
                candidaturaRowViewModel.OrigenCv = candidatura.OrigenCv.Nombre;
            }
            else
            {
                candidaturaRowViewModel.OrigenCv = "";
            }


            return candidaturaRowViewModel;
        }

        private static Tuple<Usuario, DateTime?> GetEntrevistadorYAgendada(Candidatura candidatura, int etapa)
        {
            Tuple<Usuario, DateTime?> result = null;

            switch (etapa)
            {
                case (int)TipoEtapaCandidaturaEnum.FeedbackPrimeraEntrevista:
                case (int)TipoEtapaCandidaturaEnum.FeedbackSegundaEntrevista:
                case (int)TipoEtapaCandidaturaEnum.AgendarEntrevistas:
                case (int)TipoEtapaCandidaturaEnum.AgendarSegundaEntrevista:
                case (int)TipoEtapaCandidaturaEnum.AgendarCartaOferta:

                    if ((candidatura.Entrevistas != null) && candidatura.Entrevistas.Any())
                    {
                        var entrevista = candidatura.Entrevistas.OrderBy(x => x.EntrevistaId).Last();
                        result = new Tuple<Usuario, DateTime?>(entrevista.Entrevistador, entrevista.FechaEntrevista);
                    }

                    break;

                case (int)TipoEtapaCandidaturaEnum.EntregaCartaOferta:
                case (int)TipoEtapaCandidaturaEnum.FeedbackCartaOferta:
                case (int)TipoEtapaCandidaturaEnum.Fin:

                    if ((candidatura.CartaOfertas != null) && candidatura.CartaOfertas.Any())
                    {
                        var cataOferta = candidatura.CartaOfertas.OrderBy(x => x.CartaOfertaId).Last();
                        result = new Tuple<Usuario, DateTime?>(cataOferta.Entrevistador, cataOferta.FechaCartaOferta);
                    }

                    break;
                case (int)TipoEtapaCandidaturaEnum.FiltradoTecnico:
                    if (candidatura.Filtrador != null)
                    {
                        result = new Tuple<Usuario, DateTime?>(candidatura.Filtrador, null);
                    }
                    break;
            }

            return result;
        }


        #endregion




        #endregion









    }
}
