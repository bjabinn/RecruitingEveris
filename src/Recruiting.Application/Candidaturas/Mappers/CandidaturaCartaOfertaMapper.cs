using Recruiting.Application.Candidaturas.ViewModel;
using Recruiting.Application.Helpers;
using Recruiting.Application.Maestros.Enums;
using Recruiting.Business.Entities;
using Recruiting.Application.Candidaturas.Enums;

using System;
using System.Linq;
using System.Web;

namespace Recruiting.Application.Candidaturas.Mappers
{   
    public static class CandidaturaCartaOfertaMapper
    {
        #region Mapper

        public const string RutaImagenes = "~/Content/images/";

        public static CompletarCartaOfertaViewModel ConvertToCompletarCartaOfertaViewModel(this Candidatura candidatura)
        {
            if (candidatura.CartaOfertas != null && candidatura.CartaOfertas.Count > 0)
            {

                var completarCartaOfertaViewModel = new CompletarCartaOfertaViewModel()
                {
                    EntregaCartaOfertaViewModel = candidatura.ConvertToEntregaCartaOfertaViewModel(),
                    CompletarCartaOferta = new CompletarCartaOferta()
                    {
                        SuperaCartaOferta = candidatura.CartaOfertas.ElementAt(0).Acepta == null ? (int)TipoDecisionEnum.SIN_DECISION_CARTAOFERTA : candidatura.CartaOfertas.ElementAt(0).Acepta.Value ? (int)TipoDecisionEnum.ACEPTA_CARTA_OFERTA : (int)TipoDecisionEnum.NO_ACEPTA_CARTA_OFERTA,
                        MotivoRechazoId = candidatura.CartaOfertas.ElementAt(0).MotivoRechazoId,
                        MotivoRechazoNombre = candidatura.CartaOfertas.ElementAt(0).MotivoRechazo?.Nombre,
                        NecesidadId = candidatura.CartaOfertas.ElementAt(0).NecesidadId,
                        FechaIncorporacion = candidatura.CartaOfertas.ElementAt(0).FechaIncorporacion,
                        AsignadaCorrectamente = (candidatura.CartaOfertas.ElementAt(0).Necesidad != null) ? candidatura.CartaOfertas.ElementAt(0).Necesidad.AsignadaCorrectamente : true,
                        NecesidadNombre = candidatura.CartaOfertas.ElementAt(0).Necesidad?.Nombre
                    }
                };
                if (candidatura.CartaOfertas.ElementAt(0).Necesidad!=null) {

                    completarCartaOfertaViewModel.CompletarCartaOferta.NecesidadNombre = candidatura.CartaOfertas.ElementAt(0).Necesidad.Nombre;
                    completarCartaOfertaViewModel.CompletarCartaOferta.AsignadaCorrectamente = candidatura.CartaOfertas.ElementAt(0).Necesidad.AsignadaCorrectamente;
                }
                return completarCartaOfertaViewModel;
            }

            var completarCartaOferta = new CompletarCartaOfertaViewModel();
            completarCartaOferta.CompletarCartaOferta = new CompletarCartaOferta();
            completarCartaOferta.EntregaCartaOfertaViewModel = new EntregaCartaOfertaViewModel();
            completarCartaOferta.EntregaCartaOfertaViewModel.AgendarCartaOfertaViewModel = new AgendarCartaOfertaViewModel();
            completarCartaOferta.EntregaCartaOfertaViewModel.AgendarCartaOfertaViewModel.AgendarCartaOferta = new AgendarCartaOferta();
            completarCartaOferta.EntregaCartaOfertaViewModel.EntregaCartaOferta = new EntregaCartaOferta();
            return completarCartaOferta;
        }

        public static void UpdateCartaOferta(this CartaOferta cartaOferta, AgendarCartaOfertaViewModel agendarCartaOfertaViewModel, int? cartaOfertaId)
        {
            if (cartaOfertaId != null)
            {
                cartaOferta.CartaOfertaId = (int)cartaOfertaId;

                cartaOferta.ModifiedBy = ModifiableEntityHelper.GetCurrentUser();
                cartaOferta.Modified = ModifiableEntityHelper.GetCurrentDate();
            }
            else
            {
                cartaOferta.CreatedBy = ModifiableEntityHelper.GetCurrentUser();
                cartaOferta.Created = ModifiableEntityHelper.GetCurrentDate();
            }

            if (agendarCartaOfertaViewModel.AgendarCartaOferta.EntrevistadorId > 0) {
                cartaOferta.EntrevistadorId = (int)agendarCartaOfertaViewModel.AgendarCartaOferta.EntrevistadorId;
            }
            cartaOferta.FechaCartaOferta = (DateTime)agendarCartaOfertaViewModel.AgendarCartaOferta.FechaAgendarCarta;
            cartaOferta.CandidaturaId = agendarCartaOfertaViewModel.AgendarCartaOferta.CandidaturaId;
            cartaOferta.OficinaId = agendarCartaOfertaViewModel.AgendarCartaOferta.OficinaId;
        }

        public static void UpdateCartaOferta(this CartaOferta cartaOferta, EntregaCartaOfertaViewModel entregaCartaOfertaViewModel, int? cartaOfertaId)
        {
            if (cartaOfertaId != null)
            {
                cartaOferta.CartaOfertaId = (int)cartaOfertaId;

                cartaOferta.ModifiedBy = ModifiableEntityHelper.GetCurrentUser();
                cartaOferta.Modified = ModifiableEntityHelper.GetCurrentDate();
            }
            else
            {
                cartaOferta.CreatedBy = ModifiableEntityHelper.GetCurrentUser();
                cartaOferta.Created = ModifiableEntityHelper.GetCurrentDate();
            }

            cartaOferta.Observaciones = entregaCartaOfertaViewModel.EntregaCartaOferta.ObservacionesCartaOferta;
        }

        public static void UpdateCartaOferta(this CartaOferta cartaOferta, CompletarCartaOfertaViewModel completarCartaOfertaViewModel, int? cartaOfertaId, Necesidad necesidadOriginal, Necesidad necesidadNueva)
        {
            if (cartaOfertaId != null)
            {
                cartaOferta.CartaOfertaId = (int)cartaOfertaId;
                cartaOferta.ModifiedBy = ModifiableEntityHelper.GetCurrentUser();
                cartaOferta.Modified = ModifiableEntityHelper.GetCurrentDate();
            }
            else
            {
                cartaOferta.CreatedBy = ModifiableEntityHelper.GetCurrentUser();
                cartaOferta.Created = ModifiableEntityHelper.GetCurrentDate();
            }

            if(completarCartaOfertaViewModel.CompletarCartaOferta.SuperaCartaOferta == (int)TipoDecisionEnum.SIN_DECISION_CARTAOFERTA)
                cartaOferta.Acepta = null;
            else
                cartaOferta.Acepta = completarCartaOfertaViewModel.CompletarCartaOferta.SuperaCartaOferta == (int)TipoDecisionEnum.ACEPTA_CARTA_OFERTA;

            cartaOferta.FechaIncorporacion = completarCartaOfertaViewModel.CompletarCartaOferta.FechaIncorporacion;
            cartaOferta.MotivoRechazoId = completarCartaOfertaViewModel.CompletarCartaOferta.MotivoRechazoId;

            cartaOferta.NecesidadId = completarCartaOfertaViewModel.CompletarCartaOferta.NecesidadId;

            if ((necesidadOriginal != null) && (necesidadOriginal.NecesidadId != completarCartaOfertaViewModel.CompletarCartaOferta.NecesidadId))
            {
                necesidadOriginal.EstadoNecesidadId = (int)EstadoNecesidadEnum.Abierta;
            }

            if (necesidadNueva != null)
            {
                necesidadNueva.EstadoNecesidadId = (int)EstadoNecesidadEnum.Cerrada;
            }


            cartaOferta.Observaciones = completarCartaOfertaViewModel.EntregaCartaOfertaViewModel.EntregaCartaOferta.ObservacionesCartaOferta;
            cartaOferta.FechaCartaOferta = Convert.ToDateTime(completarCartaOfertaViewModel.EntregaCartaOfertaViewModel.AgendarCartaOfertaViewModel.AgendarCartaOferta.FechaAgendarCarta);
        }

        #endregion

        #region Private Methods

        private static EntregaCartaOfertaViewModel ConvertToEntregaCartaOfertaViewModel(this Candidatura candidatura)
        {
            if (candidatura.SalarioActual == null)
            {
                candidatura.SalarioActual = 0;
            }
            //
            var entregaCartaOfertaViewModel = new EntregaCartaOfertaViewModel()
            {
                AgendarCartaOfertaViewModel = candidatura.CartaOfertas.ElementAt(0).ConvertToAgendarCartaOfertaViewModel(),
                EntregaCartaOferta = new EntregaCartaOferta()
                {
                    SalarioPropuesto = (candidatura.SalarioPropuesto != null) ? (decimal)candidatura.SalarioPropuesto : 0,
                    SalarioActual = (candidatura.SalarioActual != null) ? (decimal)candidatura.SalarioActual : 0,
                    SalarioDeseado = (candidatura.SalarioDeseado != null) ? (decimal)candidatura.SalarioDeseado : 0,
                    ObservacionesCartaOferta = candidatura.CartaOfertas.ElementAt(0).Observaciones ?? "",
                    Moneda = candidatura.Moneda                
                                      
                    
                }
            };

            return entregaCartaOfertaViewModel;
        }

        private static AgendarCartaOfertaViewModel ConvertToAgendarCartaOfertaViewModel(this CartaOferta cartaOferta)
        {
            var agendarCartaOfertaViewModel = new AgendarCartaOfertaViewModel()
            {
                AgendarCartaOferta = new AgendarCartaOferta()
                {
                    CandidaturaId = cartaOferta.CandidaturaId,
                    EntrevistadorId = cartaOferta.EntrevistadorId,
                    FechaAgendarCarta = cartaOferta.FechaCartaOferta,
                    EntrevistadorName = cartaOferta.Entrevistador == null ? string.Empty : cartaOferta.Entrevistador.Nombre,
                    OficinaId = cartaOferta.OficinaId,
                    PlantillaCorreoNombre = cartaOferta.OficinaId == null ? "Genérica" : cartaOferta.Oficina?.Nombre
                }
            };

            return agendarCartaOfertaViewModel;
        }
   

        public static CartaOfertaPdfViewModel ConvertToCartaOfertaPdfViewModel (this Candidatura candidatura, 
            string nombreEntregaCarta,string cargoEntregaCarta, string telefono, string telefonoContratacion, string mailTo, string atencionTelefonica, string ayudaComedor,string fax) {

            var cartaOfertaViewModel = new CartaOfertaPdfViewModel()
            {
                CandidaturaId = candidatura.CandidaturaId,
                Centro = candidatura.Usuario.Centro != null ? candidatura.Usuario.Centro.Nombre : string.Empty,
                CartaOfertaId = candidatura.CartaOfertas.SingleOrDefault(x => x.CandidaturaId == candidatura.CandidaturaId) != null ?
                      candidatura.CartaOfertas.SingleOrDefault(x => x.CandidaturaId == candidatura.CandidaturaId).CartaOfertaId : 0,
                fecha = candidatura.CartaOfertas.SingleOrDefault(x => x.CandidaturaId == candidatura.CandidaturaId).FechaCartaOferta.ToLongDateString(),
                //la fecha en que se agendo la carta oferta
                NombreCandidato = string.Concat(candidatura.Candidato.Nombre != null ? candidatura.Candidato.Nombre.TrimEnd() : string.Empty, " ",
                                candidatura.Candidato.Apellidos != null ? candidatura.Candidato.Apellidos.TrimEnd() : string.Empty),
                Categoria = GetNombreCategoriaCOByCategoria(candidatura.Categoria.Nombre),
                SalarioBruto = (ayudaComedor != "" && candidatura.SalarioPropuesto.HasValue) ? String.Format("{0:0,0.00}", Convert.ToDouble(candidatura.SalarioPropuesto.Value) + Convert.ToDouble(ayudaComedor)) : String.Format("{0:0,0.00}", 0),
                NombreEntregaCarta = nombreEntregaCarta,
                CargoEntregaCarta = cargoEntregaCarta,
                Telefono = telefono,
                TelefonoContratacion = telefonoContratacion,
                MailTo = mailTo,
                Atencion = atencionTelefonica,
                AyudaComedor = ayudaComedor,
                SalarioNeto = String.Format("{0:0,0.00}", candidatura.SalarioPropuesto.Value),
                Fax = fax
            };   

            cartaOfertaViewModel.fecha = cartaOfertaViewModel.fecha.Substring(cartaOfertaViewModel.fecha.IndexOf(",") + 1);
            cartaOfertaViewModel.LogoCabecera =string.Concat(HttpContext.Current.Server.MapPath(RutaImagenes),"cabecera.png");
            cartaOfertaViewModel.imagenFirma= string.Concat(HttpContext.Current.Server.MapPath(RutaImagenes), "firma.png");
            return cartaOfertaViewModel;
        }

        public static CartaOfertaPdfViewModel ConvertToCartaOfertaPdfIndexViewModel(this Candidatura candidatura,
            string nombreEntregaCarta, string cargoEntregaCarta, string telefono, string mailTo, string atencionTelefonica, string ayudaComedor, string fax)
        {

            var cartaOfertaViewModel = new CartaOfertaPdfViewModel()
            {
                CandidaturaId = candidatura.CandidaturaId,
                Centro = candidatura.Usuario.Centro != null ? candidatura.Usuario.Centro.Nombre : string.Empty,
                CartaOfertaId = candidatura.CartaOfertas.SingleOrDefault(x => x.CandidaturaId == candidatura.CandidaturaId) != null ?
                      candidatura.CartaOfertas.SingleOrDefault(x => x.CandidaturaId == candidatura.CandidaturaId).CartaOfertaId : 0,
                //fecha = candidatura.CartaOfertas.SingleOrDefault(x => x.CandidaturaId == candidatura.CandidaturaId).FechaCartaOferta.ToLongDateString(),
                fecha = "",
                //la fecha en que se agendo la carta oferta
                NombreCandidato = string.Concat(candidatura.Candidato.Nombre != null ? candidatura.Candidato.Nombre.TrimEnd() : string.Empty, " ",
                                candidatura.Candidato.Apellidos != null ? candidatura.Candidato.Apellidos.TrimEnd() : string.Empty),
                Categoria = GetNombreCategoriaCOByCategoria(candidatura.Categoria.Nombre),
                SalarioBruto = (ayudaComedor != "" && candidatura.SalarioPropuesto.HasValue) ? String.Format("{0:0,0.00}", Convert.ToDouble(candidatura.SalarioPropuesto.Value) + Convert.ToDouble(ayudaComedor)) : String.Format("{0:0,0.00}", 0),
                NombreEntregaCarta = nombreEntregaCarta,
                CargoEntregaCarta = cargoEntregaCarta,
                Telefono = telefono,
                MailTo = mailTo,
                Atencion = atencionTelefonica,
                AyudaComedor = ayudaComedor,
                SalarioNeto = String.Format("{0:0,0.00}", candidatura.SalarioPropuesto.Value),
                Fax = fax
            };

            cartaOfertaViewModel.fecha = cartaOfertaViewModel.fecha.Substring(cartaOfertaViewModel.fecha.IndexOf(",") + 1);
            cartaOfertaViewModel.LogoCabecera = string.Concat(HttpContext.Current.Server.MapPath(RutaImagenes), "cabecera.png");
            cartaOfertaViewModel.imagenFirma = string.Concat(HttpContext.Current.Server.MapPath(RutaImagenes), "firma.png");
            return cartaOfertaViewModel;
        }

        #endregion

        private static string GetNombreCategoriaCOByCategoria(string Categoria)
        {
            string textoCategoriaCO = Categoria;
            if (Categoria.Contains("Technical")) { 
                textoCategoriaCO = Categoria.Replace("Technical ","");
            }
            else if (Categoria.Contains("Functional")) {
                textoCategoriaCO = Categoria.Replace("Functional ", "");
            }
            else if (Categoria.Contains("Testing")) {
                textoCategoriaCO = Categoria.Replace("Testing ", "");
            }
            textoCategoriaCO = "Centers " + textoCategoriaCO;
            return textoCategoriaCO;
        }
    }
}
