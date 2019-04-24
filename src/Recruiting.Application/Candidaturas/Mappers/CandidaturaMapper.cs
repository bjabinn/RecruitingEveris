using Recruiting.Application.Candidaturas.Enums;
using Recruiting.Application.Candidaturas.ViewModel;
using Recruiting.Application.Helpers;
using Recruiting.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Recruiting.Application.Candidaturas.Mappers
{
	public static class CandidaturaMapper
	{
		#region Mapper

        public static IEnumerable<CandidaturaRowViewModel> ConvertToCandidaturaRowViewModel(this IEnumerable<Candidatura> candidaturaList, Dictionary<int, List<Bitacora>> bitacorasRevertibles)
		{
			var candidaturaRowViewModelList = new List<CandidaturaRowViewModel>();

			if( candidaturaList == null ) return candidaturaRowViewModelList;

            candidaturaRowViewModelList = candidaturaList.Select(x => x.ConvertToCandidaturaRowViewModel(bitacorasRevertibles)).ToList();

			return candidaturaRowViewModelList;
		}

        public static IEnumerable<CandidaturaViewModel> ConvertToCandidaturaViewModel(this IEnumerable<Candidatura> candidaturaList)
        {
            try
            {
                var candidaturaViewModelList = new List<CandidaturaViewModel>();

                if (candidaturaList == null) return candidaturaViewModelList;

                candidaturaViewModelList = candidaturaList.Select(x => x.ConvertToCandidaturaViewModel()).ToList();

                return candidaturaViewModelList;
            }
            catch (Exception)
            {
                return new List<CandidaturaViewModel>();
            }
            
        }

        public static IEnumerable<CandidaturaRowExportToExcelViewModel> ConvertToCandidaturaRowExportToExcelViewModel(this IEnumerable<Candidatura> candidaturaList)
        {
            var candidaturaRowExportToExcelViewModelList = new List<CandidaturaRowExportToExcelViewModel>();

            if (candidaturaList == null) return candidaturaRowExportToExcelViewModelList;

            candidaturaRowExportToExcelViewModelList = candidaturaList.Select(x => x.ConvertToCandidaturaRowExportToExcelViewModel()).ToList();

            return candidaturaRowExportToExcelViewModelList;
        }


        public static CandidaturaViewModel ConvertToCandidaturaViewModel( this Candidatura candidatura )
		{
            try { 
			    var candidaturaViewModel = new CandidaturaViewModel();

			    candidaturaViewModel.CandidaturaId = candidatura.CandidaturaId;
			    candidaturaViewModel.CandidaturaDatosBasicosViewModel = candidatura.ConvertToCandidaturaDatosBasicosViewModel();
			    candidaturaViewModel.FiltroCVViewModel = candidatura.ConvertToCandidaturaFiltradoCvViewModel();
			    candidaturaViewModel.PrimeraEntrevistaViewModel = candidatura.ConvertToPrimeraEntrevistaViewModel();
			    candidaturaViewModel.SegundaEntrevistaViewModel = candidatura.ConvertToSegundaEntrevistaViewModel();
			    candidaturaViewModel.CompletarCartaOfertaViewModel = candidatura.ConvertToCompletarCartaOfertaViewModel();
                candidaturaViewModel.ComentariosRenunciaDescarte = candidatura.ComentariosRenunciaDescarte;
                candidaturaViewModel.TipoRenunciaDescarte = candidatura.MotivoRenunciaDescarteId;
                candidaturaViewModel.TipoRenunciaDescarteNombre = candidatura.MotivoRenunciaDescarte?.Nombre;
                candidaturaViewModel.CandidaturaDatosBasicosViewModel.DatosBasicos.Activo = candidatura.IsActivo;
                candidaturaViewModel.EmailsSeguimiento = candidatura.EmailsSeguimiento;
                candidaturaViewModel.UsuarioCreacionId = candidatura.Usuario.UsuarioId;
                candidaturaViewModel.UbicacionCandidato = candidatura.UbicacionCandidato;
                candidaturaViewModel.CandidaturaDatosBasicosViewModel.DatosBasicos.AnioExperiencia = candidatura.AniosExperiencia;
                return candidaturaViewModel;
            }
            catch (Exception)
            {
                return null;
            }
        }

		public static void UpdateCandidatura( this Candidatura candidatura , CandidaturaDatosBasicosViewModel candidaturaDatosBasicosViewModel )
		{
			if( candidaturaDatosBasicosViewModel.DatosBasicos.CandidaturaId != null )
			{
				candidatura.CandidaturaId = (int) candidaturaDatosBasicosViewModel.DatosBasicos.CandidaturaId;

				candidatura.ModifiedBy = ModifiableEntityHelper.GetCurrentUser();
				candidatura.Modified = ModifiableEntityHelper.GetCurrentDate();
			}
			else
			{
				candidatura.CreatedBy = ModifiableEntityHelper.GetCurrentUser();
				candidatura.Created = ModifiableEntityHelper.GetCurrentDate();

				candidatura.EstadoCandidaturaId = (int) TipoEstadoCandidaturaEnum.FiltradoPeople;
				candidatura.EtapaCandidaturaId = (int) TipoEtapaCandidaturaEnum.Inicio;
			}

			candidatura.CandidatoId = candidaturaDatosBasicosViewModel.DatosBasicos.CandidatoId;
            if (candidaturaDatosBasicosViewModel.DatosBasicos.CategoriaId == 0) {
                candidatura.CategoriaId = null;
            }
            else {
                candidatura.CategoriaId = candidaturaDatosBasicosViewModel.DatosBasicos.CategoriaId;
            }
            candidatura.OfertaId = candidaturaDatosBasicosViewModel.DatosBasicos.OfertaId;
            candidatura.OrigenCvId = candidaturaDatosBasicosViewModel.DatosBasicos.OrigenCvId == null ? null : candidaturaDatosBasicosViewModel.DatosBasicos.OrigenCvId;
            if (candidaturaDatosBasicosViewModel.DatosBasicos.FuenteReclutamientoId != null)
            {
                candidatura.FuenteReclutamientoId = (int)candidaturaDatosBasicosViewModel.DatosBasicos.FuenteReclutamientoId;
            }
            else
            {
                candidatura.FuenteReclutamientoId = null;
            }
            candidatura.SalarioDeseado = candidaturaDatosBasicosViewModel.DatosBasicos.SalarioDeseado;
			candidatura.DatosCurriculo = candidaturaDatosBasicosViewModel.DatosBasicos.DatosCv;
			candidatura.IsActivo = true;
			candidatura.NombreCV = candidaturaDatosBasicosViewModel.DatosBasicos.NombreCV;
			candidatura.CV = candidaturaDatosBasicosViewModel.DatosBasicos.CV;
            candidatura.UrlCV = candidaturaDatosBasicosViewModel.DatosBasicos.UrlCV;
            candidatura.TipoTecnologiaId = (int)candidaturaDatosBasicosViewModel.DatosBasicos.TipoTecnologiaId;
            candidatura.ModuloId = candidaturaDatosBasicosViewModel.DatosBasicos.Modulo;
            candidatura.FiltradorId = candidaturaDatosBasicosViewModel.DatosBasicos.FiltradorId;
            candidatura.Moneda = candidaturaDatosBasicosViewModel.DatosBasicos.Moneda;
            candidatura.OrigenCvId = candidaturaDatosBasicosViewModel.DatosBasicos.OrigenCvId;
            candidatura.FuenteReclutamientoId = candidaturaDatosBasicosViewModel.DatosBasicos.FuenteReclutamientoId;
            candidatura.CandidaturaOfertaId = candidaturaDatosBasicosViewModel.DatosBasicos.CandidaturaOfertaId;
            candidatura.UbicacionCandidato = candidaturaDatosBasicosViewModel.DatosBasicos.UbicacionCandidato;
            candidatura.AniosExperiencia = candidaturaDatosBasicosViewModel.DatosBasicos.AnioExperiencia;

            string emails = "";
            if (candidaturaDatosBasicosViewModel.DatosBasicos.ListEmailReferenciados != null)
            {
                foreach (string emailRef in candidaturaDatosBasicosViewModel.DatosBasicos.ListEmailReferenciados)
                {
                    if (emailRef != "")
                    {
                        emails = string.Concat(emails, emailRef, ";");
                    }
                }
            }
            candidatura.EmailsReferenciados = emails;
            candidatura.NotificarDescarte = true;

        }

		public static void UpdateCandidatura( this Candidatura candidatura , CandidaturaFiltradoCvViewModel candidaturaFiltradoCvViewModel )
		{
			candidatura.CandidaturaId = candidaturaFiltradoCvViewModel.CandidaturaId;
			candidatura.FiltradoCV = candidaturaFiltradoCvViewModel.Filtrado;
			candidatura.DescartarFuturasCandidaturas = candidaturaFiltradoCvViewModel.DescartarFuturasCandidaturas;
			candidatura.Observaciones = candidaturaFiltradoCvViewModel.MotivosObservaciones;
			candidatura.ModifiedBy = ModifiableEntityHelper.GetCurrentUser();
			candidatura.Modified = ModifiableEntityHelper.GetCurrentDate();
		}

		public static void UpdateCandidatura( this Candidatura candidatura , PrimeraEntrevistaViewModel primeraEntrevistaViewModel , int? entrevistaId )
		{
			candidatura.CandidaturaId = primeraEntrevistaViewModel.AgendarPrimeraEntrevista.AgendarPrimeraEntrevista.CandidaturaId;

            candidatura.ModifiedBy = ModifiableEntityHelper.GetCurrentUser();
            candidatura.Modified = ModifiableEntityHelper.GetCurrentDate();


            if ( primeraEntrevistaViewModel.RangoSalarialesyDisponibilidades != null )
			{
				candidatura.CategoriaId = primeraEntrevistaViewModel.RangoSalarialesyDisponibilidades.CategoriaId;
				candidatura.SalarioPropuesto = primeraEntrevistaViewModel.RangoSalarialesyDisponibilidades.SalarioPropuesto;
				candidatura.SalarioDeseado = primeraEntrevistaViewModel.RangoSalarialesyDisponibilidades.SalarioDeseado;
				candidatura.SalarioActual = primeraEntrevistaViewModel.RangoSalarialesyDisponibilidades.SalarioActual;
				if( candidatura.SalarioActual == null ) candidatura.SalarioActual = 0;
				candidatura.DisponibilidadViajes = primeraEntrevistaViewModel.RangoSalarialesyDisponibilidades.DisponibilidadViajes;
				candidatura.CambioResidencia = primeraEntrevistaViewModel.RangoSalarialesyDisponibilidades.CambioResidencia;
				candidatura.IncorporacionId = primeraEntrevistaViewModel.RangoSalarialesyDisponibilidades.IncorporacionId;
			}

			if( candidatura.Entrevistas != null )
			{
				if( candidatura.Entrevistas.Any( x => x.TipoEntrevistaId == (int) TipoEntrevistaEnum.PrimeraEntrevista ))
				{
					candidatura.Entrevistas.Single( x => x.TipoEntrevistaId == (int) TipoEntrevistaEnum.PrimeraEntrevista ).UpdateCandidaturaPrimeraEntrevista( primeraEntrevistaViewModel.AgendarPrimeraEntrevista , entrevistaId );
					candidatura.Entrevistas.Single( x => x.TipoEntrevistaId == (int) TipoEntrevistaEnum.PrimeraEntrevista ).UpdateCandidaturaPrimeraEntrevista( primeraEntrevistaViewModel , entrevistaId );
                 }
				else
				{
					Entrevista entrevista = new Entrevista();
					entrevista.UpdateCandidaturaPrimeraEntrevista( primeraEntrevistaViewModel.AgendarPrimeraEntrevista , entrevistaId );
				}
			}
            if( primeraEntrevistaViewModel.ResultadoPrimeraEntrevista != null)
            {
                candidatura.NotificarDescarte = primeraEntrevistaViewModel.ResultadoPrimeraEntrevista.NotificarDescarte;
            }
			else
			{
				Entrevista entrevista = new Entrevista();
				entrevista.UpdateCandidaturaPrimeraEntrevista( primeraEntrevistaViewModel.AgendarPrimeraEntrevista , entrevistaId );
			}
		}

		public static void UpdateCandidatura( this Candidatura candidatura , SegundaEntrevistaViewModel segundaEntrevistaViewModel , int? entrevistaId )
		{
			candidatura.CandidaturaId = segundaEntrevistaViewModel.AgendarSegundaEntrevista.AgendarSegundaEntrevista.CandidaturaId;
			if( segundaEntrevistaViewModel.RangoSalarialesyDisponibilidades != null )
			{
				candidatura.CategoriaId = segundaEntrevistaViewModel.RangoSalarialesyDisponibilidades.CategoriaId;
				candidatura.SalarioPropuesto = segundaEntrevistaViewModel.RangoSalarialesyDisponibilidades.SalarioPropuesto;
				candidatura.SalarioDeseado = segundaEntrevistaViewModel.RangoSalarialesyDisponibilidades.SalarioDeseado;
				candidatura.SalarioActual = segundaEntrevistaViewModel.RangoSalarialesyDisponibilidades.SalarioActual;
				if( candidatura.SalarioActual == null ) candidatura.SalarioActual = 0;
				candidatura.DisponibilidadViajes = segundaEntrevistaViewModel.RangoSalarialesyDisponibilidades.DisponibilidadViajes;
				candidatura.CambioResidencia = segundaEntrevistaViewModel.RangoSalarialesyDisponibilidades.CambioResidencia;
				candidatura.IncorporacionId = segundaEntrevistaViewModel.RangoSalarialesyDisponibilidades.IncorporacionId;
			}
			candidatura.ModifiedBy = ModifiableEntityHelper.GetCurrentUser();
			candidatura.Modified = ModifiableEntityHelper.GetCurrentDate();

			if( candidatura.Entrevistas.Any( x => x.TipoEntrevistaId == (int) TipoEntrevistaEnum.SegundaEntrevista ))
			{
				candidatura.Entrevistas.Single( x => x.TipoEntrevistaId == (int) TipoEntrevistaEnum.SegundaEntrevista ).UpdateCandidaturaSegundaEntrevista( segundaEntrevistaViewModel.AgendarSegundaEntrevista , entrevistaId );
				candidatura.Entrevistas.Single( x => x.TipoEntrevistaId == (int) TipoEntrevistaEnum.SegundaEntrevista ).UpdateCandidaturaSegundaEntrevista( segundaEntrevistaViewModel , entrevistaId );
			}
			else
			{
				Entrevista entrevista = new Entrevista();
				entrevista.UpdateCandidaturaSegundaEntrevista( segundaEntrevistaViewModel.AgendarSegundaEntrevista , entrevistaId );
			}

            if( segundaEntrevistaViewModel.ResultadoSegundaEntrevista != null)
            {
                candidatura.NotificarDescarte = segundaEntrevistaViewModel.ResultadoSegundaEntrevista.NotificarDescarte;
            }


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
					attributeName = "TipoPerfilDeseadoId";
					break;
				case "Entrevistador":
                    attributeName = "Entrevista.EntrevistadorId";
                    break;
                case "Filtrador":
                    attributeName = "Filtrado.Nombre";
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
                case "UbicacionCandidato":
                    attributeName = "UbicacionCandidato";
                    break;
                case "AnioExperiencia":
                    attributeName = "AniosExperiencia";
                    break;
            }
			return attributeName;
		}

		#region Private Methods

        private static CandidaturaRowViewModel ConvertToCandidaturaRowViewModel(this Candidatura candidatura, Dictionary<int, List<Bitacora>> bitacorasRevertibles)
		{
			var entrevistadorNombre = string.Empty;
			int? entrevistadorId = null;
			var agendada = new DateTime?();
            var ofertaNombre = String.Empty;
            var nivelIngles = "N/A";

            foreach (var cIdioma in candidatura.Candidato.CandidatoIdiomas) {
                if (cIdioma.IdiomaId == 15) {
                    nivelIngles = cIdioma.NivelIdioma.Nombre;
                }
            }
          
            var ofer = convertToOferta(candidatura);
            if (ofer != null) {

                ofertaNombre = ofer.Oferta;
            }


            var tupla = GetEntrevistadorYAgendada( candidatura , candidatura.EtapaCandidatura.TipoEtapaCandidaturaId );
			if( tupla != null )
			{
				if( tupla.Item1 != null )
				{
					entrevistadorNombre = tupla.Item1.Nombre;
					entrevistadorId = tupla.Item1.UsuarioId;
				}
				agendada = (tupla.Item2.HasValue) ? (tupla.Item2): null;
			}

            var listaBitacorasRevertibles = new List<Bitacora>();
            if (bitacorasRevertibles.ContainsKey(candidatura.CandidaturaId))
            {
                listaBitacorasRevertibles = bitacorasRevertibles[candidatura.CandidaturaId];
            }

            var candidaturaRowViewModel = new CandidaturaRowViewModel()
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
                CVAvailable = ((candidatura.CV != null && candidatura.UrlCV == null) || (candidatura.CV == null && candidatura.UrlCV != null)),
                Centro = candidatura.Usuario.CentroId != null ? candidatura.Usuario.Centro.Nombre : string.Empty,
                //GeneradoCartaOferta = candidatura.CartaOfertas.FirstOrDefault() != null && candidatura.CartaOfertas.FirstOrDefault().CartaOfertaGenerada != null,
                GeneradoCartaOferta = candidatura.EtapaCandidatura.TipoEtapaCandidaturaId > (int)TipoEtapaCandidaturaEnum.AgendarEntrevistas && candidatura.EtapaCandidatura.TipoEtapaCandidaturaId != (int)TipoEtapaCandidaturaEnum.Inicio && candidatura.EtapaCandidatura.TipoEtapaCandidaturaId != (int)TipoEtapaCandidaturaEnum.FiltradoTelefonico && candidatura.EtapaCandidatura.TipoEtapaCandidaturaId != (int)TipoEtapaCandidaturaEnum.FeedbackPrimeraEntrevista,
                PuedeRetroceder = listaBitacorasRevertibles.Any(),

                FiltradorId = candidatura.FiltradorId,
                SubEntrevistadoresString = "",
                NumeroDeEntrevistas = 0,
                NivelIdioma = nivelIngles,
                EmailsSeguimiento = candidatura.EmailsSeguimiento,
                UbicacionCandidato = candidatura.UbicacionCandidato
            };
           
            if(candidatura.NumeroDeEntrevistas != null)
            {
                candidaturaRowViewModel.NumeroDeEntrevistas = (int)candidatura.NumeroDeEntrevistas;
            }
                     

            if (candidatura.EstadoCandidaturaId == (int)TipoEstadoCandidaturaEnum.Entrevista)
            {
                var primeraEntrevista = (from entrevista in candidatura.Entrevistas
                                           where entrevista.TipoEntrevistaId == 1 &&
                                           entrevista.IsActivo
                                         select entrevista).ToList();
                
                foreach (var entrevista in primeraEntrevista)
                {
                    foreach (var subEntrevista in entrevista.SubEntrevista)
                    {
                        candidaturaRowViewModel.SubEntrevistadoresString = string.Concat(candidaturaRowViewModel.SubEntrevistadoresString, subEntrevista.EntrevistadorId, ",");                       
                    }
                }
                candidaturaRowViewModel.SubEntrevistadoresString = (candidaturaRowViewModel.SubEntrevistadoresString.Length > 0) ?
                    candidaturaRowViewModel.SubEntrevistadoresString.Remove(candidaturaRowViewModel.SubEntrevistadoresString.Length - 1) :
                    candidaturaRowViewModel.SubEntrevistadoresString;
            }
            if (candidatura.EstadoCandidaturaId == (int)TipoEstadoCandidaturaEnum.SegundaEntrevista)
            {
                var segundaEntrevista = (from entrevista in candidatura.Entrevistas
                                           where entrevista.TipoEntrevistaId == 2 &&
                                           entrevista.IsActivo
                                         select entrevista).ToList();
                foreach (var entrevista in segundaEntrevista)
                {
                    foreach (var subEntrevista in entrevista.SubEntrevista)
                    {
                        candidaturaRowViewModel.SubEntrevistadoresString = string.Concat(candidaturaRowViewModel.SubEntrevistadoresString, subEntrevista.EntrevistadorId, ",");                        
                    }
                }
                candidaturaRowViewModel.SubEntrevistadoresString = (candidaturaRowViewModel.SubEntrevistadoresString.Length > 0) ?
                    candidaturaRowViewModel.SubEntrevistadoresString.Remove(candidaturaRowViewModel.SubEntrevistadoresString.Length - 1) :
                    candidaturaRowViewModel.SubEntrevistadoresString;
            }

            if (candidatura.Categoria != null){
                candidaturaRowViewModel.Perfil = candidatura.Categoria.Nombre;
            }
            
			candidaturaRowViewModel.TipoTecnologia = candidatura.TipoTecnologia == null ? null : (candidatura.TipoTecnologia.Nombre ?? null);
            if(candidaturaRowViewModel.OrigenCvId != null)
            {
                candidaturaRowViewModel.OrigenCv = candidatura.OrigenCv.Nombre;
            }
            else
            {
                candidaturaRowViewModel.OrigenCv = "";
            }
                

            return candidaturaRowViewModel;
		}

        private static CandidaturaRowExportToExcelViewModel ConvertToCandidaturaRowExportToExcelViewModel(this Candidatura candidatura)
        {
            var entrevistadorNombre = string.Empty;            
           
            var agendada =String.Empty;
            var nivelIngles = "N/A";

            var tupla = GetEntrevistadorYAgendada(candidatura, candidatura.EtapaCandidatura.TipoEtapaCandidaturaId);
            if (tupla != null)
            {
                if (tupla.Item1 != null)
                {
                    entrevistadorNombre = tupla.Item1.Nombre;
                }
                agendada = tupla.Item2.ToString();
            }

            foreach (CandidatoIdioma idioma in candidatura.Candidato.CandidatoIdiomas)
            {
                if (idioma.IdiomaId == 15){
                    nivelIngles = idioma.NivelIdioma.Nombre;
                }
            }

            var candidaturaRowExportToExcellViewModel = new CandidaturaRowExportToExcelViewModel()
            {

                CandidaturaId = candidatura.CandidaturaId,
                Oferta = candidatura.CandidaturaOfertaId != null ? candidatura.CandidaturaOferta.NombreOferta : string.Empty,
                FechaCreacion = candidatura.Created.Day + "/" + candidatura.Created.Month + "/" + candidatura.Created.Year,
                Estado = candidatura.EstadoCandidatura.EstadoCandidatura,
                Etapa = candidatura.EtapaCandidatura.EtapaCandidatura,
                Candidato = candidatura.Candidato.Nombre + ' ' + candidatura.Candidato.Apellidos,
                Entrevistador = entrevistadorNombre,
                Agendada = agendada,
                Centro = candidatura.Usuario.CentroId != null ? candidatura.Usuario.Centro.Nombre : string.Empty,
                NivelIngles = nivelIngles,
                //MotivoRenuncia = (candidatura.MotivoRenunciaDescarteId != null) ? candidatura.MotivoRenunciaDescarte.Nombre : "",
                Motivo = candidatura.getMotivo(),
                NumeroDeEntrevistas = candidatura.NumeroDeEntrevistas
            };
            if (candidatura.OrigenCvId.HasValue)
            {
                candidaturaRowExportToExcellViewModel.OrigenCv = candidatura.OrigenCv.Nombre;
            }

            if (candidatura.Categoria != null)
            {
                candidaturaRowExportToExcellViewModel.Perfil = candidatura.Categoria.Nombre;
            }
            if (candidatura.ModuloId.HasValue)
            {
                candidaturaRowExportToExcellViewModel.Modulo = candidatura.TipoModulo.Nombre;
            }

            candidaturaRowExportToExcellViewModel.TipoTecnologia = candidatura.TipoTecnologia == null ? null : (candidatura.TipoTecnologia.Nombre ?? null);

            return candidaturaRowExportToExcellViewModel;
        }

        private static string getMotivo(this Candidatura candidatura)
        {
            if(candidatura.EstadoCandidaturaId == (int)TipoEstadoCandidaturaEnum.RechazaOferta || 
                candidatura.EstadoCandidaturaId == (int)TipoEstadoCandidaturaEnum.Descartado ||
                candidatura.EstadoCandidaturaId == (int)TipoEstadoCandidaturaEnum.Renuncia)
            {
                if (candidatura.MotivoRenunciaDescarteId != null)
                {
                    return candidatura.MotivoRenunciaDescarte.Nombre;
                }
                else
                {
                    if (candidatura.NumeroDeEntrevistas != 0)
                    {
                        var entrevistas = candidatura.Entrevistas.ToList();
                        foreach (var entrevista in entrevistas)
                        {
                            if (entrevista.MotivoId != null)
                            {
                                return entrevista.Motivo.Nombre;
                            }
                        }
                    }
                    if (candidatura.CartaOfertas.Any())
                    {
                        foreach (var cartaOferta in candidatura.CartaOfertas)
                        {
                            if (cartaOferta.MotivoRechazoId != null)
                            {
                                return cartaOferta.MotivoRechazo.Nombre;
                            }
                        }
                    }
                    return "";
                }
            }
            else
            {
                return "";
            }      
        }


        private static Tuple<Usuario, DateTime?> GetEntrevistadorYAgendada( Candidatura candidatura , int etapa )
		{
			Tuple<Usuario , DateTime?> result = null;

			switch( etapa )
			{
				case (int)TipoEtapaCandidaturaEnum.FeedbackPrimeraEntrevista:
				case (int)TipoEtapaCandidaturaEnum.FeedbackSegundaEntrevista:
				case (int)TipoEtapaCandidaturaEnum.AgendarEntrevistas:
				case (int)TipoEtapaCandidaturaEnum.AgendarSegundaEntrevista:
				case (int)TipoEtapaCandidaturaEnum.AgendarCartaOferta:

					if( ( candidatura.Entrevistas != null ) && candidatura.Entrevistas.Any() )
					{
						var entrevista = candidatura.Entrevistas.OrderBy( x => x.EntrevistaId ).Last();
						result = new Tuple<Usuario , DateTime?>( entrevista.Entrevistador , entrevista .FechaEntrevista);
					}

					break;

				case (int)TipoEtapaCandidaturaEnum.EntregaCartaOferta:
				case (int)TipoEtapaCandidaturaEnum.FeedbackCartaOferta:
				case (int)TipoEtapaCandidaturaEnum.Fin:

					if( ( candidatura.CartaOfertas != null ) && candidatura.CartaOfertas.Any() )
					{
						var cataOferta = candidatura.CartaOfertas.OrderBy( x => x.CartaOfertaId ).Last();
						result = new Tuple<Usuario , DateTime?>( cataOferta.Entrevistador , cataOferta.FechaCartaOferta );
					}

					break;
                case (int)TipoEtapaCandidaturaEnum.FiltradoTecnico:
                    if (candidatura.Filtrador != null)
                    {
                        result = new Tuple<Usuario, DateTime?>(candidatura.Filtrador, null);
                    }
                    break;
                case (int)TipoEtapaCandidaturaEnum.FiltradoTelefonico:
                    if (candidatura.Filtrador != null)
                    {
                        result = new Tuple<Usuario, DateTime?>(candidatura.Filtrador, null);
                    }
                    break;
            }

			return result;
		}

        //con esto accedemos a los nombres de otras tablas
        public static CandidaturaRowViewModel convertToOferta(Candidatura candidatura) {

            var result = new CandidaturaRowViewModel();

            if ((candidatura.Oferta != null) )
            {
                var entrevista = candidatura.Oferta.Nombre;
               
                result.Oferta = entrevista;
                
            }

            return result;

        }


        private static CandidaturaDatosBasicosViewModel ConvertToCandidaturaDatosBasicosViewModel( this Candidatura candidatura )
        {
            var emails = new List<string>();
            if (candidatura.EmailsReferenciados != null)
            {
                emails = candidatura.EmailsReferenciados.Split(';').ToList();                
            }

            if (emails.Count > 0 && emails.Last() == "")
            {
                emails.RemoveAt(emails.Count-1);
            }

            var candidaturaDatosBasicosViewModel = new CandidaturaDatosBasicosViewModel()
            {
                DatosBasicos = new CandidaturaDatosBasicos()
                {
                    CandidaturaId = candidatura.CandidaturaId,
                    CandidatoId = candidatura.CandidatoId,
                    DatosCv = candidatura.DatosCurriculo,
                    OfertaId = candidatura.OfertaId,
                    OfertaName = (candidatura.Oferta != null) ? candidatura.Oferta.Nombre : "",
                    FuenteReclutamientoId = candidatura.FuenteReclutamientoId,
                    FuenteReclutamientoNombre = candidatura.FuenteReclutamiento?.Nombre,
                    OrigenCvId = candidatura.OrigenCvId,
                    OrigenCvNombre = candidatura.OrigenCv?.Nombre,
                    ListEmailReferenciados = emails,
                    CategoriaId = candidatura.CategoriaId,
                    CategoriaNombre = candidatura.Categoria?.Nombre,
                    SubidoCv = (candidatura.NombreCV != null),
                    SalarioDeseado = candidatura.SalarioDeseado,
                    EtapaCandidaturaId = candidatura.EtapaCandidaturaId,
                    EtapaCandidatura = candidatura.EtapaCandidatura.EtapaCandidatura,
                    EstadoCandidaturaId = candidatura.EstadoCandidaturaId,
                    EstadoCandidatura = candidatura.EstadoCandidatura.EstadoCandidatura,
                    NombreCandidato = candidatura.Candidato.Nombre + ' ' + candidatura.Candidato.Apellidos,
                    TipoTecnologiaId = candidatura.TipoTecnologiaId,
                    TipoTecnologiaNombre = candidatura.TipoTecnologia?.Nombre,
                    ModuloNombre = candidatura.TipoModulo?.Nombre,
                    CV = candidatura.CV,
                    NombreCV = candidatura.NombreCV,
                    UrlCV = candidatura.UrlCV,
                    FiltradorId = candidatura.FiltradorId,
                    FiltradorNombre = (candidatura.FiltradorId.HasValue) ? candidatura.Filtrador.Nombre : "",
                    Moneda = (candidatura.Moneda != null) ? candidatura.Moneda : "",
                    CandidaturaOfertaId = candidatura.CandidaturaOfertaId,
                    NombreOferta = candidatura.CandidaturaOfertaId != null ? candidatura.CandidaturaOferta.NombreOferta : string.Empty,
                    FechaCreacion = candidatura.Created,
                    UbicacionCandidato = candidatura.UbicacionCandidato,
                    IdiomaCandidatoViewModel = new List<CreateEditRowIdiomaCandidaturaViewModel>(),
                    ExpCandidatoViewModel = new List<ViewModels.CreateEditRowExperienciaCandidatoViewModel>()
                }
            };
            if(candidatura.ModuloId.HasValue)
            {
                candidaturaDatosBasicosViewModel.DatosBasicos.Modulo = candidatura.ModuloId;
            }


			return candidaturaDatosBasicosViewModel;
		}

		private static CandidaturaFiltradoCvViewModel ConvertToCandidaturaFiltradoCvViewModel( this Candidatura candidatura )
		{
			var candidaturaFiltradoCvViewModel = new CandidaturaFiltradoCvViewModel()
			{
				Filtrado = candidatura.FiltradoCV ,
				MotivosObservaciones = candidatura.Observaciones ,
				DescartarFuturasCandidaturas = candidatura.DescartarFuturasCandidaturas ,
				CandidaturaId = candidatura.CandidaturaId ,
                NombreCandidato = candidatura.Candidato.Nombre + ' ' + candidatura.Candidato.Apellidos
                 
        };

			return candidaturaFiltradoCvViewModel;
		}

        #endregion

        #endregion


        public static void UpdateCandidaturaModoEdit(this Candidatura candidatura, CandidaturaViewModel candidaturaViewModel)
        {
            candidatura.ModifiedBy = ModifiableEntityHelper.GetCurrentUser();
            candidatura.Modified = ModifiableEntityHelper.GetCurrentDate();

            if (candidaturaViewModel.CandidaturaDatosBasicosViewModel != null)
            {
                //se actualiza salvo el candidato que no se puede cambiar ni los estados que no deben cambiar 
                //ni los ids                 
                candidatura.CategoriaId = candidaturaViewModel.CandidaturaDatosBasicosViewModel.DatosBasicos.CategoriaId;
                candidatura.OfertaId = candidaturaViewModel.CandidaturaDatosBasicosViewModel.DatosBasicos.OfertaId;
                candidatura.OrigenCvId = (int)candidaturaViewModel.CandidaturaDatosBasicosViewModel.DatosBasicos.OrigenCvId;
                candidatura.MotivoRenunciaDescarteId = candidaturaViewModel.TipoRenunciaDescarte;
                candidatura.UbicacionCandidato = candidaturaViewModel.UbicacionCandidato;
                candidatura.AniosExperiencia = candidaturaViewModel.CandidaturaDatosBasicosViewModel.DatosBasicos.AnioExperiencia;

                if (candidaturaViewModel.CandidaturaDatosBasicosViewModel.DatosBasicos.FuenteReclutamientoId != null)
                {
                    candidatura.FuenteReclutamientoId = (int)candidaturaViewModel.CandidaturaDatosBasicosViewModel.DatosBasicos.FuenteReclutamientoId;
                }
                else
                {
                    candidatura.FuenteReclutamientoId = null;
                }

                candidatura.SalarioDeseado = candidaturaViewModel.CandidaturaDatosBasicosViewModel.DatosBasicos.SalarioDeseado;
                if (candidaturaViewModel.CandidaturaDatosBasicosViewModel.DatosBasicos.NombreCV != null)
                {
                    candidatura.CV = candidaturaViewModel.CandidaturaDatosBasicosViewModel.DatosBasicos.CV;
                    candidatura.NombreCV = candidaturaViewModel.CandidaturaDatosBasicosViewModel.DatosBasicos.NombreCV;
                    candidatura.UrlCV = candidaturaViewModel.CandidaturaDatosBasicosViewModel.DatosBasicos.UrlCV;
                }
                candidatura.DatosCurriculo = candidaturaViewModel.CandidaturaDatosBasicosViewModel.DatosBasicos.DatosCv;
                candidatura.TipoTecnologiaId = (int)candidaturaViewModel.CandidaturaDatosBasicosViewModel.DatosBasicos.TipoTecnologiaId;
                candidatura.ModuloId = candidaturaViewModel.CandidaturaDatosBasicosViewModel.DatosBasicos.Modulo;
                candidatura.FiltradorId = candidaturaViewModel.CandidaturaDatosBasicosViewModel.DatosBasicos.FiltradorId;
                candidatura.CandidaturaOfertaId = candidaturaViewModel.CandidaturaDatosBasicosViewModel.DatosBasicos.CandidaturaOfertaId;                
            }

            if (candidaturaViewModel.FiltroCVViewModel != null)
            {
                candidatura.Observaciones = candidaturaViewModel.FiltroCVViewModel.MotivosObservaciones;
                candidatura.DescartarFuturasCandidaturas = candidaturaViewModel.FiltroCVViewModel.DescartarFuturasCandidaturas;
            }

            if (candidaturaViewModel.PrimeraEntrevistaViewModel != null && (candidatura.Entrevistas.Any(x => x.TipoEntrevistaId == (int)TipoEntrevistaEnum.PrimeraEntrevista)))
            {
                    candidatura.Entrevistas.Single(x => x.TipoEntrevistaId == (int)TipoEntrevistaEnum.PrimeraEntrevista).UpdateCandidaturaPrimeraEntrevista(candidaturaViewModel.PrimeraEntrevistaViewModel);
            }
            if (candidaturaViewModel.SegundaEntrevistaViewModel != null && (candidatura.Entrevistas.Any(x => x.TipoEntrevistaId == (int)TipoEntrevistaEnum.SegundaEntrevista)))
            {
                    candidatura.Entrevistas.Single(x => x.TipoEntrevistaId == (int)TipoEntrevistaEnum.SegundaEntrevista).UpdateCandidaturaSegunaEntrevista(candidaturaViewModel.SegundaEntrevistaViewModel);
            }

            if (candidaturaViewModel.CompletarCartaOfertaViewModel != null && (candidatura.CartaOfertas.Any(x => x.CandidaturaId == candidatura.CandidaturaId)))
            {
                    candidatura.CartaOfertas.Single(x => x.CandidaturaId == candidatura.CandidaturaId).UpdateCandidaturaCartaOferta(candidaturaViewModel.CompletarCartaOfertaViewModel);
            }

            if (candidaturaViewModel.ComentariosRenunciaDescarte != null && candidaturaViewModel.ComentariosRenunciaDescarte != "")
            {
                candidatura.ComentariosRenunciaDescarte = candidaturaViewModel.ComentariosRenunciaDescarte;
                candidatura.MotivoRenunciaDescarteId = candidaturaViewModel.TipoRenunciaDescarte;
            }

            string emails = "";
            if (candidaturaViewModel.CandidaturaDatosBasicosViewModel.DatosBasicos.ListEmailReferenciados != null)
            {
                foreach (string emailRef in candidaturaViewModel.CandidaturaDatosBasicosViewModel.DatosBasicos.ListEmailReferenciados)
                {
                    if (emailRef != "")
                    {
                        emails = string.Concat(emails, emailRef, ";");
                    }
                }
            }
            candidatura.EmailsReferenciados = emails;
        }

        public static void UpdateCandidaturaPrimeraEntrevista(this Entrevista entrevista, PrimeraEntrevistaViewModel entrevistaViewModel)
        {

            entrevista.ModifiedBy = ModifiableEntityHelper.GetCurrentUser();
            entrevista.Modified = ModifiableEntityHelper.GetCurrentDate();

            //de AgendarPrimeraEntrevista
            if (entrevistaViewModel.AgendarPrimeraEntrevista.AgendarPrimeraEntrevista.EntrevistadorId > 0)
            {
                entrevista.EntrevistadorId = entrevistaViewModel.AgendarPrimeraEntrevista.AgendarPrimeraEntrevista.EntrevistadorId;
            }
            entrevista.FechaEntrevista = (DateTime)entrevistaViewModel.AgendarPrimeraEntrevista.AgendarPrimeraEntrevista.FechaEntrevista;
            entrevista.Presencial = entrevistaViewModel.AgendarPrimeraEntrevista.AgendarPrimeraEntrevista.Presencial;
            entrevista.AvisarAlCandidato = entrevistaViewModel.AgendarPrimeraEntrevista.AgendarPrimeraEntrevista.AvisarAlCandidato;
            entrevista.TipoEntrevistaId = (int)TipoEntrevistaEnum.PrimeraEntrevista;
            entrevista.OficinaId = entrevistaViewModel.AgendarPrimeraEntrevista.AgendarPrimeraEntrevista.OficinaId;
            //de RangoSalarialesyDisponibilidades
            if(entrevistaViewModel.RangoSalarialesyDisponibilidades != null)
            {
                entrevista.Observaciones = entrevistaViewModel.RangoSalarialesyDisponibilidades.ObservacionesEntrevista;
                if (entrevistaViewModel.RangoSalarialesyDisponibilidades.CategoriaId != 0)
                {
                    entrevista.Candidatura.CategoriaId = entrevistaViewModel.RangoSalarialesyDisponibilidades.CategoriaId;
                    entrevista.Candidatura.CambioResidencia = entrevistaViewModel.RangoSalarialesyDisponibilidades.CambioResidencia;
                    entrevista.Candidatura.DisponibilidadViajes = entrevistaViewModel.RangoSalarialesyDisponibilidades.DisponibilidadViajes;
                    entrevista.Candidatura.IncorporacionId = entrevistaViewModel.RangoSalarialesyDisponibilidades.IncorporacionId;
                    entrevista.Candidatura.SalarioActual = entrevistaViewModel.RangoSalarialesyDisponibilidades.SalarioActual;
                    entrevista.Candidatura.SalarioDeseado = entrevistaViewModel.RangoSalarialesyDisponibilidades.SalarioDeseado;
                    entrevista.Candidatura.SalarioPropuesto = entrevistaViewModel.RangoSalarialesyDisponibilidades.SalarioPropuesto;
                }
               
            }
           

            //de resultadoprimeraentrevista
            if(entrevistaViewModel.ResultadoPrimeraEntrevista != null)
            {
                entrevista.MotivoId = entrevistaViewModel.ResultadoPrimeraEntrevista.MotivoId;
                entrevista.ResultadoTest = entrevistaViewModel.ResultadoPrimeraEntrevista.ResultadoTest;
                if(entrevistaViewModel.ResultadoPrimeraEntrevista.NombreTS != null)
                {
                    entrevista.NombreTS = entrevistaViewModel.ResultadoPrimeraEntrevista.NombreTS;
                    entrevista.TS = entrevistaViewModel.ResultadoPrimeraEntrevista.TS;              
                }
            }
            

            entrevista.IsActivo = true;
        }

        public static void UpdateCandidaturaSegunaEntrevista(this Entrevista entrevista, SegundaEntrevistaViewModel entrevistaViewModel)
        {

            entrevista.ModifiedBy = ModifiableEntityHelper.GetCurrentUser();
            entrevista.Modified = ModifiableEntityHelper.GetCurrentDate();

            //de AgendarPrimeraEntrevista
            if (entrevistaViewModel.AgendarSegundaEntrevista.AgendarSegundaEntrevista.EntrevistadorId > 0)
            {
                entrevista.EntrevistadorId = entrevistaViewModel.AgendarSegundaEntrevista.AgendarSegundaEntrevista.EntrevistadorId;
            }
            entrevista.FechaEntrevista = (DateTime)entrevistaViewModel.AgendarSegundaEntrevista.AgendarSegundaEntrevista.FechaEntrevista;
            entrevista.Presencial = entrevistaViewModel.AgendarSegundaEntrevista.AgendarSegundaEntrevista.Presencial;
            entrevista.AvisarAlCandidato = entrevistaViewModel.AgendarSegundaEntrevista.AgendarSegundaEntrevista.AvisarAlCandidato;
            entrevista.TipoEntrevistaId = (int)TipoEntrevistaEnum.SegundaEntrevista;

            //de RangoSalarialesyDisponibilidades
            /*if (entrevistaViewModel.RangoSalarialesyDisponibilidades != null)
            {
                entrevista.Observaciones = entrevistaViewModel.RangoSalarialesyDisponibilidades.ObservacionesEntrevista;

                if (entrevistaViewModel.RangoSalarialesyDisponibilidades.CategoriaId != 0)
                {
                    entrevista.Candidatura.CategoriaId = entrevistaViewModel.RangoSalarialesyDisponibilidades.CategoriaId;
                    entrevista.Candidatura.CambioResidencia = entrevistaViewModel.RangoSalarialesyDisponibilidades.CambioResidencia;
                    entrevista.Candidatura.DisponibilidadViajes = entrevistaViewModel.RangoSalarialesyDisponibilidades.DisponibilidadViajes;
                    entrevista.Candidatura.IncorporacionId = entrevistaViewModel.RangoSalarialesyDisponibilidades.IncorporacionId;
                    entrevista.Candidatura.SalarioActual = entrevistaViewModel.RangoSalarialesyDisponibilidades.SalarioActual;
                    entrevista.Candidatura.SalarioDeseado = entrevistaViewModel.RangoSalarialesyDisponibilidades.SalarioDeseado;
                    entrevista.Candidatura.SalarioPropuesto = entrevistaViewModel.RangoSalarialesyDisponibilidades.SalarioPropuesto;
                }
            }*/

            //de resultadoSegundaentrevista
            if (entrevistaViewModel.ResultadoSegundaEntrevista != null)
            {
                entrevista.MotivoId = entrevistaViewModel.ResultadoSegundaEntrevista.MotivoId;   
                
            }

            entrevista.IsActivo = true;
        }

        public static void UpdateCandidaturaCartaOferta(this CartaOferta cartaOferta, CompletarCartaOfertaViewModel cartaOfertaViewModel)
        {

            cartaOferta.ModifiedBy = ModifiableEntityHelper.GetCurrentUser();
            cartaOferta.Modified = ModifiableEntityHelper.GetCurrentDate();

            //de EntregaCartaOfertaViewModel.AgendarCartaOfertaViewModel.AgendarCartaOferta
            if (cartaOfertaViewModel.EntregaCartaOfertaViewModel.AgendarCartaOfertaViewModel.AgendarCartaOferta.EntrevistadorId > 0)
            {
                cartaOferta.EntrevistadorId = (int)cartaOfertaViewModel.EntregaCartaOfertaViewModel.AgendarCartaOfertaViewModel.AgendarCartaOferta.EntrevistadorId;
            }
            //de EntregaCartaOfertaViewModel.AgendarCartaOfertaViewModel.AgendarCartaOferta 
            cartaOferta.FechaCartaOferta = (DateTime)cartaOfertaViewModel.EntregaCartaOfertaViewModel.AgendarCartaOfertaViewModel.AgendarCartaOferta.FechaAgendarCarta;
            cartaOferta.OficinaId = cartaOfertaViewModel.EntregaCartaOfertaViewModel.AgendarCartaOfertaViewModel.AgendarCartaOferta.OficinaId;

            //de EntregaCartaOfertaViewModel.EntregaCartaOferta
            if(cartaOfertaViewModel.EntregaCartaOfertaViewModel.EntregaCartaOferta != null)
            {
                cartaOferta.Observaciones = cartaOfertaViewModel.EntregaCartaOfertaViewModel.EntregaCartaOferta.ObservacionesCartaOferta;
                cartaOferta.Candidatura.SalarioActual = cartaOfertaViewModel.EntregaCartaOfertaViewModel.EntregaCartaOferta.SalarioActual;
                cartaOferta.Candidatura.SalarioDeseado = cartaOfertaViewModel.EntregaCartaOfertaViewModel.EntregaCartaOferta.SalarioDeseado;
                cartaOferta.Candidatura.SalarioPropuesto = cartaOfertaViewModel.EntregaCartaOfertaViewModel.EntregaCartaOferta.SalarioPropuesto;
            }
       
            //de cartaOfertaViewModel.CompletarCartaOferta
            if (cartaOfertaViewModel.CompletarCartaOferta != null)
            {
                cartaOferta.FechaIncorporacion = (cartaOfertaViewModel.CompletarCartaOferta.FechaIncorporacion != null) ? cartaOfertaViewModel.CompletarCartaOferta.FechaIncorporacion : cartaOferta.FechaIncorporacion;
                cartaOferta.MotivoRechazoId = (cartaOfertaViewModel.CompletarCartaOferta.MotivoRechazoId != null) ? cartaOfertaViewModel.CompletarCartaOferta.MotivoRechazoId : cartaOferta.MotivoRechazoId;
                cartaOferta.NecesidadId = (cartaOfertaViewModel.CompletarCartaOferta.NecesidadId != null) ? cartaOfertaViewModel.CompletarCartaOferta.NecesidadId : cartaOferta.NecesidadId;
            }
        }
    }
}
