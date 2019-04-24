using Recruiting.Business.Entities;
using System.Data.Entity;

namespace Recruiting.Data.EntityFramework
{
    public class RecruitingDbContext : DbContext
    {
        // Define an IDbSet for each Entity...
        public virtual IDbSet<Bitacora> Bitacora { get; set; }
        public virtual IDbSet<Candidato> Candidato { get; set; }
        public virtual IDbSet<CandidatoContacto> CandidatoContacto { get; set; }
        public virtual IDbSet<CandidatoExperiencia> CandidatoExperiencia { get; set; }
        public virtual IDbSet<CandidatoIdioma> CandidatoIdioma { get; set; }
        public virtual IDbSet<Candidatura> Candidatura { get; set; }
        public virtual IDbSet<CartaOferta> CartaOferta { get; set; }
        public virtual IDbSet<Cliente> Cliente { get; set; }
        public virtual IDbSet<Entrevista> Entrevista { get; set; }
        public virtual IDbSet<Maestro> Maestro { get; set; }
        public virtual IDbSet<Necesidad> Necesidad { get; set; }
        public virtual IDbSet<Oferta> Oferta { get; set; }
        public virtual IDbSet<Proyecto> Proyecto { get; set; }
        public virtual IDbSet<RelacionEtapa> RelacionEtapa { get; set; }
        public virtual IDbSet<RelacionVistaEtapa> RelacionVistaEtapa { get; set; }
        public virtual IDbSet<TipoDecision> TipoDecision { get; set; }
        public virtual IDbSet<TipoEntrevista> TipoEntrevista { get; set; }
        public virtual IDbSet<TipoEstadoCandidatura> TipoEstadoCandidatura { get; set; }
        public virtual IDbSet<TipoEtapaCandidatura> TipoEtapaCandidatura { get; set; }
        public virtual IDbSet<TipoMaestro> TipoMaestro { get; set; }
        public virtual IDbSet<TipoMotivoDecision> TipoMotivoDecision { get; set; }
        public virtual IDbSet<Usuario> Usuario { get; set; }        
       

        public virtual IDbSet<Correo> Correo { get; set; }
        public virtual IDbSet<CorreoAdjunto> CorreoAdjunto { get; set; }
        public virtual IDbSet<CorreoBecario> CorreoBecario { get; set; }
        public virtual IDbSet<CorreoPlantilla> CorreoPlantilla { get; set; }
        public virtual IDbSet<CorreoPlantillaVariable> CorreoPlantillaVariable { get; set; }
        public virtual IDbSet<CorreoPlantillaVariableValor> CorreoPlantillaVariableValor { get; set; }

        public virtual IDbSet<PersonaLibre> PersonaLibre { get; set; }
        public virtual IDbSet<PersonaLibreIdioma> PersonaLibreIdiomas { get; set; }
        public virtual IDbSet<FenixCategoriaLineaCelda> FenixCategoriaLineaCelda { get; set; }

        public virtual IDbSet<MonedasDeCentro> MonedasDeCentro { get; set; }

        public virtual IDbSet<SubEntrevista> SubEntrevista { get; set; }
        public virtual IDbSet<Centro> Centro { get; set; }
        public virtual IDbSet<Oficina> Oficina { get; set; }
        
        public virtual IDbSet<GrupoNecesidad> GrupoNecesidad { get; set; }

        public virtual IDbSet<BitacoraNecesidad> BitacoraNecesidad { get; set; }
        public virtual IDbSet<BitacoraBecario> BitacoraBecario { get; set; }

        public virtual IDbSet<BecarioCentroProcedencia> BecarioCentroProcedencia { get; set; }
        public virtual IDbSet<TipoEstadoBecario> TipoEstadoBecario { get; set; }
        public virtual IDbSet<Becario> Becario { get; set; }
        public virtual IDbSet<BecarioObservacion> BecarioObservacion { get; set; }
        public virtual IDbSet<AdministradorDashboard> AdministradorDashboard { get; set; }
        public virtual IDbSet<CuentaToken> CuentaToken { get; set; }
        public virtual IDbSet<BlackListSala> BlackListSala { get; set; }

        public virtual IDbSet<CandidaturaOferta> CandidaturaOferta { get; set; }

        public virtual IDbSet<CandidatoCentroEducativo> CandidatoCentroEducativo { get; set; }

        public RecruitingDbContext()
            : base("EverisRecruiting")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PersonaLibreIdioma>()
                .HasRequired<Maestro>(m => m.NivelIdioma)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PersonaLibreIdioma>()
                .HasRequired<Maestro>(m => m.Idioma)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CandidatoIdioma>()
                .HasRequired<Maestro>(m => m.NivelIdioma)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CandidatoIdioma>()
                .HasRequired<Maestro>(m => m.Idioma)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CorreoBecario>()
                .HasRequired<CorreoPlantilla>(m => m.CorreoPlantilla)
                .WithMany()
                .WillCascadeOnDelete(false);
        }
    }
}
