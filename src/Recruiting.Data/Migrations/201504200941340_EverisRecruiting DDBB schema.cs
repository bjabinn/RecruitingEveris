namespace Recruiting.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class EverisRecruitingDDBBschema : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Candidato",
                c => new
                    {
                        CandidatoId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 500),
                        Apellidos = c.String(nullable: false, maxLength: 500),
                        FechaNacimiento = c.DateTime(nullable: false),
                        TipoIdentificacionId = c.Int(nullable: false),
                        NumeroIdentificacion = c.String(nullable: false, maxLength: 10),
                        SalarioDeseado = c.Decimal(precision: 18, scale: 2),
                        DisponibilidadViaje = c.Boolean(nullable: false),
                        CambioResidencia = c.Boolean(nullable: false),
                        TitulacionId = c.Int(nullable: false),
                        DetalleTitulacion = c.String(maxLength: 500),
                        EstadoCandidatoId = c.Int(nullable: false),
                        UsuarioCreacionId = c.Int(nullable: false),
                        UsuarioModificacionId = c.Int(),
                        FechaCreacion = c.DateTime(nullable: false),
                        FechaModificacion = c.DateTime(),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CandidatoId)
                .ForeignKey("dbo.Maestro", t => t.EstadoCandidatoId, cascadeDelete: true)
                .ForeignKey("dbo.Maestro", t => t.TipoIdentificacionId, cascadeDelete: false)
                .ForeignKey("dbo.Maestro", t => t.TitulacionId, cascadeDelete: false)
                .ForeignKey("dbo.Usuario", t => t.UsuarioCreacionId, cascadeDelete: true)
                .ForeignKey("dbo.Usuario", t => t.UsuarioModificacionId)
                .Index(t => t.TipoIdentificacionId)
                .Index(t => t.TitulacionId)
                .Index(t => t.EstadoCandidatoId)
                .Index(t => t.UsuarioCreacionId)
                .Index(t => t.UsuarioModificacionId);
            
            CreateTable(
                "dbo.CandidatoContacto",
                c => new
                    {
                        CandidatoContactoId = c.Int(nullable: false, identity: true),
                        CandidatoId = c.Int(nullable: false),
                        TipoMedioContactoId = c.Int(nullable: false),
                        Contacto = c.String(nullable: false, maxLength: 500),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CandidatoContactoId)
                .ForeignKey("dbo.Candidato", t => t.CandidatoId, cascadeDelete: true)
                .ForeignKey("dbo.Maestro", t => t.TipoMedioContactoId, cascadeDelete: false)
                .Index(t => t.CandidatoId)
                .Index(t => t.TipoMedioContactoId);
            
            CreateTable(
                "dbo.Maestro",
                c => new
                    {
                        MaestroId = c.Int(nullable: false, identity: true),
                        TipoMaestroId = c.Int(nullable: false),
                        Maestro = c.String(nullable: false, maxLength: 250),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MaestroId)
                .ForeignKey("dbo.TipoMaestro", t => t.TipoMaestroId, cascadeDelete: true)
                .Index(t => t.TipoMaestroId);
            
            CreateTable(
                "dbo.TipoMaestro",
                c => new
                    {
                        TipoMaestroId = c.Int(nullable: false, identity: true),
                        TipoMaestro = c.String(nullable: false, maxLength: 100),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TipoMaestroId);
            
            CreateTable(
                "dbo.CandidatoExperiencia",
                c => new
                    {
                        CandidatoExperienciaId = c.Int(nullable: false, identity: true),
                        CandidatoId = c.Int(nullable: false),
                        TipoTecnologiaId = c.Int(nullable: false),
                        NivelTecnologiaId = c.Int(nullable: false),
                        Experiencia = c.Int(nullable: false),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CandidatoExperienciaId)
                .ForeignKey("dbo.Candidato", t => t.CandidatoId, cascadeDelete: true)
                .ForeignKey("dbo.Maestro", t => t.NivelTecnologiaId, cascadeDelete: false)
                .ForeignKey("dbo.Maestro", t => t.TipoTecnologiaId, cascadeDelete: false)
                .Index(t => t.CandidatoId)
                .Index(t => t.TipoTecnologiaId)
                .Index(t => t.NivelTecnologiaId);
            
            CreateTable(
                "dbo.CandidatoIdioma",
                c => new
                    {
                        CandidatoIdiomasId = c.Int(nullable: false, identity: true),
                        CandidatoId = c.Int(nullable: false),
                        IdiomaId = c.Int(nullable: false),
                        NivelIdiomaId = c.Int(nullable: false),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CandidatoIdiomasId)
                .ForeignKey("dbo.Candidato", t => t.CandidatoId, cascadeDelete: true)
                .ForeignKey("dbo.Maestro", t => t.IdiomaId, cascadeDelete: false)
                .ForeignKey("dbo.Maestro", t => t.NivelIdiomaId, cascadeDelete: false)
                .Index(t => t.CandidatoId)
                .Index(t => t.IdiomaId)
                .Index(t => t.NivelIdiomaId);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        UsuarioId = c.Int(nullable: false, identity: true),
                        Usuario = c.String(nullable: false, maxLength: 100),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UsuarioId);
            
            CreateTable(
                "dbo.Candidatura",
                c => new
                    {
                        CandidaturaId = c.Int(nullable: false, identity: true),
                        NecesidadId = c.Int(nullable: false),
                        OfertaId = c.Int(nullable: false),
                        CandidatoId = c.Int(nullable: false),
                        EtapaCandidaturaId = c.Int(nullable: false),
                        EstadoCandidaturaId = c.Int(nullable: false),
                        TipoPerfilDeseadoId = c.Int(),
                        TipoPerfilId = c.Int(),
                        IncorporacionId = c.Int(),
                        CategoriaId = c.Int(),
                        SalarioPropuesto = c.Decimal(precision: 18, scale: 2),
                        Observaciones = c.String(),
                        DatosCurriculo = c.String(),
                        CV = c.Binary(),
                        NombreCV = c.String(),
                        SalarioDeseado = c.Decimal(precision: 18, scale: 2),
                        FiltradoCV = c.Boolean(nullable: false),
                        DescartarFuturasCandidaturas = c.Boolean(nullable: false),
                        SalarioActual = c.Decimal(precision: 18, scale: 2),
                        DisponibilidadViajes = c.Boolean(nullable: false),
                        CambioResidencia = c.Boolean(nullable: false),
                        UsuarioCreacionId = c.Int(nullable: false),
                        UsuarioModificacionId = c.Int(),
                        FechaCreacion = c.DateTime(nullable: false),
                        FechaModificacion = c.DateTime(),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CandidaturaId)
                .ForeignKey("dbo.Candidato", t => t.CandidatoId, cascadeDelete: true)
                .ForeignKey("dbo.Maestro", t => t.CategoriaId)
                .ForeignKey("dbo.TipoEstadoCandidatura", t => t.EstadoCandidaturaId, cascadeDelete: true)
                .ForeignKey("dbo.TipoEtapaCandidatura", t => t.EtapaCandidaturaId, cascadeDelete: true)
                .ForeignKey("dbo.Maestro", t => t.IncorporacionId)
                .ForeignKey("dbo.Necesidad", t => t.NecesidadId, cascadeDelete: true)
                .ForeignKey("dbo.Oferta", t => t.OfertaId, cascadeDelete: true)
                .ForeignKey("dbo.Maestro", t => t.TipoPerfilId)
                .ForeignKey("dbo.Maestro", t => t.TipoPerfilDeseadoId)
                .ForeignKey("dbo.Usuario", t => t.UsuarioCreacionId, cascadeDelete: false)
                .ForeignKey("dbo.Usuario", t => t.UsuarioModificacionId)
                .Index(t => t.NecesidadId)
                .Index(t => t.OfertaId)
                .Index(t => t.CandidatoId)
                .Index(t => t.EtapaCandidaturaId)
                .Index(t => t.EstadoCandidaturaId)
                .Index(t => t.TipoPerfilDeseadoId)
                .Index(t => t.TipoPerfilId)
                .Index(t => t.IncorporacionId)
                .Index(t => t.CategoriaId)
                .Index(t => t.UsuarioCreacionId)
                .Index(t => t.UsuarioModificacionId);
            
            CreateTable(
                "dbo.CartaOferta",
                c => new
                    {
                        CartaOfertaId = c.Int(nullable: false, identity: true),
                        CandidaturaId = c.Int(nullable: false),
                        EntrevistadorId = c.Int(nullable: false),
                        FechaCartaOferta = c.DateTime(nullable: false),
                        Observaciones = c.String(),
                        Acepta = c.Boolean(nullable: false),
                        MotivoRechazoId = c.Int(),
                        FechaIncorporacion = c.DateTime(),
                        NecesidadId = c.Int(nullable: false),
                        UsuarioCreacionId = c.Int(nullable: false),
                        UsuarioModificacionId = c.Int(),
                        FechaCreacion = c.DateTime(nullable: false),
                        FechaModificacion = c.DateTime(),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CartaOfertaId)
                .ForeignKey("dbo.Candidatura", t => t.CandidaturaId, cascadeDelete: true)
                .ForeignKey("dbo.Usuario", t => t.EntrevistadorId, cascadeDelete: false)
                .ForeignKey("dbo.Maestro", t => t.MotivoRechazoId)
                .ForeignKey("dbo.Necesidad", t => t.NecesidadId, cascadeDelete: false)
                .ForeignKey("dbo.Usuario", t => t.UsuarioCreacionId, cascadeDelete: false)
                .ForeignKey("dbo.Usuario", t => t.UsuarioModificacionId)
                .Index(t => t.CandidaturaId)
                .Index(t => t.EntrevistadorId)
                .Index(t => t.MotivoRechazoId)
                .Index(t => t.NecesidadId)
                .Index(t => t.UsuarioCreacionId)
                .Index(t => t.UsuarioModificacionId);
            
            CreateTable(
                "dbo.Necesidad",
                c => new
                    {
                        NecesidadId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(maxLength: 250),
                        OficinaId = c.Int(nullable: false),
                        CentroId = c.Int(nullable: false),
                        SectorId = c.Int(nullable: false),
                        ProyectoId = c.Int(nullable: false),
                        TipoServicioId = c.Int(nullable: false),
                        TipoPerfilId = c.Int(nullable: false),
                        TipoTecnologiaId = c.Int(nullable: false),
                        TipoContratacionId = c.Int(nullable: false),
                        SalarioDeseado = c.Decimal(precision: 18, scale: 2),
                        DisponibilidadViaje = c.Boolean(),
                        CambioResidencia = c.Boolean(),
                        TipoPrevisionId = c.Int(nullable: false),
                        MesesAsignacionId = c.Int(nullable: false),
                        EstadoNecesidadId = c.Int(nullable: false),
                        Observaciones = c.String(),
                        FechaSolicitud = c.DateTime(nullable: false),
                        FechaCompromiso = c.DateTime(),
                        FechaCierre = c.DateTime(),
                        UsuarioCreacionId = c.Int(nullable: false),
                        UsuarioModificacionId = c.Int(),
                        FechaCreacion = c.DateTime(nullable: false),
                        FechaModificacion = c.DateTime(),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.NecesidadId)
                .ForeignKey("dbo.Maestro", t => t.CentroId, cascadeDelete: false)
                .ForeignKey("dbo.Maestro", t => t.EstadoNecesidadId, cascadeDelete: false)
                .ForeignKey("dbo.Maestro", t => t.MesesAsignacionId, cascadeDelete: false)
                .ForeignKey("dbo.Maestro", t => t.OficinaId, cascadeDelete: false)
                .ForeignKey("dbo.Proyecto", t => t.ProyectoId, cascadeDelete: true)
                .ForeignKey("dbo.Maestro", t => t.SectorId, cascadeDelete: false)
                .ForeignKey("dbo.Maestro", t => t.TipoContratacionId, cascadeDelete: false)
                .ForeignKey("dbo.Maestro", t => t.TipoPerfilId, cascadeDelete: false)
                .ForeignKey("dbo.Maestro", t => t.TipoPrevisionId, cascadeDelete: false)
                .ForeignKey("dbo.Maestro", t => t.TipoServicioId, cascadeDelete: false)
                .ForeignKey("dbo.Maestro", t => t.TipoTecnologiaId, cascadeDelete: false)
                .ForeignKey("dbo.Usuario", t => t.UsuarioCreacionId, cascadeDelete: false)
                .ForeignKey("dbo.Usuario", t => t.UsuarioModificacionId)
                .Index(t => t.OficinaId)
                .Index(t => t.CentroId)
                .Index(t => t.SectorId)
                .Index(t => t.ProyectoId)
                .Index(t => t.TipoServicioId)
                .Index(t => t.TipoPerfilId)
                .Index(t => t.TipoTecnologiaId)
                .Index(t => t.TipoContratacionId)
                .Index(t => t.TipoPrevisionId)
                .Index(t => t.MesesAsignacionId)
                .Index(t => t.EstadoNecesidadId)
                .Index(t => t.UsuarioCreacionId)
                .Index(t => t.UsuarioModificacionId);
            
            CreateTable(
                "dbo.Proyecto",
                c => new
                    {
                        ProyectoId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 100),
                        ClienteId = c.Int(nullable: false),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ProyectoId)
                .ForeignKey("dbo.Cliente", t => t.ClienteId, cascadeDelete: true)
                .Index(t => t.ClienteId);
            
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        ClienteId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 100),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ClienteId);
            
            CreateTable(
                "dbo.Entrevista",
                c => new
                    {
                        EntrevistaId = c.Int(nullable: false, identity: true),
                        EntrevistadorId = c.Int(nullable: false),
                        FechaEntrevista = c.DateTime(nullable: false),
                        Presencial = c.Boolean(nullable: false),
                        SuperaEntrevista = c.Boolean(nullable: false),
                        MotivoId = c.Int(),
                        ResultadoTest = c.Int(),
                        TipoEntrevistaId = c.Int(nullable: false),
                        Observaciones = c.String(),
                        CandidaturaId = c.Int(nullable: false),
                        UsuarioCreacionId = c.Int(nullable: false),
                        UsuarioModificacionId = c.Int(),
                        FechaCreacion = c.DateTime(nullable: false),
                        FechaModificacion = c.DateTime(),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.EntrevistaId)
                .ForeignKey("dbo.Candidatura", t => t.CandidaturaId, cascadeDelete: true)
                .ForeignKey("dbo.Usuario", t => t.EntrevistadorId, cascadeDelete: false)
                .ForeignKey("dbo.Maestro", t => t.MotivoId)
                .ForeignKey("dbo.TipoEntrevista", t => t.TipoEntrevistaId, cascadeDelete: true)
                .ForeignKey("dbo.Usuario", t => t.UsuarioCreacionId, cascadeDelete: false)
                .ForeignKey("dbo.Usuario", t => t.UsuarioModificacionId)
                .Index(t => t.EntrevistadorId)
                .Index(t => t.MotivoId)
                .Index(t => t.TipoEntrevistaId)
                .Index(t => t.CandidaturaId)
                .Index(t => t.UsuarioCreacionId)
                .Index(t => t.UsuarioModificacionId);
            
            CreateTable(
                "dbo.TipoEntrevista",
                c => new
                    {
                        TipoEntrevistaId = c.Int(nullable: false, identity: true),
                        TipoEntrevista = c.String(nullable: false, maxLength: 100),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TipoEntrevistaId);
            
            CreateTable(
                "dbo.TipoEstadoCandidatura",
                c => new
                    {
                        TipoEstadoCandidaturaId = c.Int(nullable: false, identity: true),
                        EstadoCandidatura = c.String(),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TipoEstadoCandidaturaId);
            
            CreateTable(
                "dbo.TipoEtapaCandidatura",
                c => new
                    {
                        TipoEtapaCandidaturaId = c.Int(nullable: false, identity: true),
                        EtapaCandidatura = c.String(),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TipoEtapaCandidaturaId);
            
            CreateTable(
                "dbo.Oferta",
                c => new
                    {
                        OfertaId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 100),
                        EstadoOfertaId = c.Int(nullable: false),
                        FechaPublicacion = c.DateTime(nullable: false),
                        Descripcion = c.String(maxLength: 500),
                        UsuarioCreacionId = c.Int(nullable: false),
                        UsuarioModificacionId = c.Int(),
                        FechaCreacion = c.DateTime(nullable: false),
                        FechaModificacion = c.DateTime(),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.OfertaId)
                .ForeignKey("dbo.Maestro", t => t.EstadoOfertaId, cascadeDelete: false)
                .ForeignKey("dbo.Usuario", t => t.UsuarioCreacionId, cascadeDelete: false)
                .ForeignKey("dbo.Usuario", t => t.UsuarioModificacionId)
                .Index(t => t.EstadoOfertaId)
                .Index(t => t.UsuarioCreacionId)
                .Index(t => t.UsuarioModificacionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Candidatura", "UsuarioModificacionId", "dbo.Usuario");
            DropForeignKey("dbo.Candidatura", "UsuarioCreacionId", "dbo.Usuario");
            DropForeignKey("dbo.Candidatura", "TipoPerfilDeseadoId", "dbo.Maestro");
            DropForeignKey("dbo.Candidatura", "TipoPerfilId", "dbo.Maestro");
            DropForeignKey("dbo.Candidatura", "OfertaId", "dbo.Oferta");
            DropForeignKey("dbo.Oferta", "UsuarioModificacionId", "dbo.Usuario");
            DropForeignKey("dbo.Oferta", "UsuarioCreacionId", "dbo.Usuario");
            DropForeignKey("dbo.Oferta", "EstadoOfertaId", "dbo.Maestro");
            DropForeignKey("dbo.Candidatura", "NecesidadId", "dbo.Necesidad");
            DropForeignKey("dbo.Candidatura", "IncorporacionId", "dbo.Maestro");
            DropForeignKey("dbo.Candidatura", "EtapaCandidaturaId", "dbo.TipoEtapaCandidatura");
            DropForeignKey("dbo.Candidatura", "EstadoCandidaturaId", "dbo.TipoEstadoCandidatura");
            DropForeignKey("dbo.Entrevista", "UsuarioModificacionId", "dbo.Usuario");
            DropForeignKey("dbo.Entrevista", "UsuarioCreacionId", "dbo.Usuario");
            DropForeignKey("dbo.Entrevista", "TipoEntrevistaId", "dbo.TipoEntrevista");
            DropForeignKey("dbo.Entrevista", "MotivoId", "dbo.Maestro");
            DropForeignKey("dbo.Entrevista", "EntrevistadorId", "dbo.Usuario");
            DropForeignKey("dbo.Entrevista", "CandidaturaId", "dbo.Candidatura");
            DropForeignKey("dbo.Candidatura", "CategoriaId", "dbo.Maestro");
            DropForeignKey("dbo.CartaOferta", "UsuarioModificacionId", "dbo.Usuario");
            DropForeignKey("dbo.CartaOferta", "UsuarioCreacionId", "dbo.Usuario");
            DropForeignKey("dbo.CartaOferta", "NecesidadId", "dbo.Necesidad");
            DropForeignKey("dbo.Necesidad", "UsuarioModificacionId", "dbo.Usuario");
            DropForeignKey("dbo.Necesidad", "UsuarioCreacionId", "dbo.Usuario");
            DropForeignKey("dbo.Necesidad", "TipoTecnologiaId", "dbo.Maestro");
            DropForeignKey("dbo.Necesidad", "TipoServicioId", "dbo.Maestro");
            DropForeignKey("dbo.Necesidad", "TipoPrevisionId", "dbo.Maestro");
            DropForeignKey("dbo.Necesidad", "TipoPerfilId", "dbo.Maestro");
            DropForeignKey("dbo.Necesidad", "TipoContratacionId", "dbo.Maestro");
            DropForeignKey("dbo.Necesidad", "SectorId", "dbo.Maestro");
            DropForeignKey("dbo.Necesidad", "ProyectoId", "dbo.Proyecto");
            DropForeignKey("dbo.Proyecto", "ClienteId", "dbo.Cliente");
            DropForeignKey("dbo.Necesidad", "OficinaId", "dbo.Maestro");
            DropForeignKey("dbo.Necesidad", "MesesAsignacionId", "dbo.Maestro");
            DropForeignKey("dbo.Necesidad", "EstadoNecesidadId", "dbo.Maestro");
            DropForeignKey("dbo.Necesidad", "CentroId", "dbo.Maestro");
            DropForeignKey("dbo.CartaOferta", "MotivoRechazoId", "dbo.Maestro");
            DropForeignKey("dbo.CartaOferta", "EntrevistadorId", "dbo.Usuario");
            DropForeignKey("dbo.CartaOferta", "CandidaturaId", "dbo.Candidatura");
            DropForeignKey("dbo.Candidatura", "CandidatoId", "dbo.Candidato");
            DropForeignKey("dbo.Candidato", "UsuarioModificacionId", "dbo.Usuario");
            DropForeignKey("dbo.Candidato", "UsuarioCreacionId", "dbo.Usuario");
            DropForeignKey("dbo.Candidato", "TitulacionId", "dbo.Maestro");
            DropForeignKey("dbo.Candidato", "TipoIdentificacionId", "dbo.Maestro");
            DropForeignKey("dbo.Candidato", "EstadoCandidatoId", "dbo.Maestro");
            DropForeignKey("dbo.CandidatoIdioma", "NivelIdiomaId", "dbo.Maestro");
            DropForeignKey("dbo.CandidatoIdioma", "IdiomaId", "dbo.Maestro");
            DropForeignKey("dbo.CandidatoIdioma", "CandidatoId", "dbo.Candidato");
            DropForeignKey("dbo.CandidatoExperiencia", "TipoTecnologiaId", "dbo.Maestro");
            DropForeignKey("dbo.CandidatoExperiencia", "NivelTecnologiaId", "dbo.Maestro");
            DropForeignKey("dbo.CandidatoExperiencia", "CandidatoId", "dbo.Candidato");
            DropForeignKey("dbo.CandidatoContacto", "TipoMedioContactoId", "dbo.Maestro");
            DropForeignKey("dbo.Maestro", "TipoMaestroId", "dbo.TipoMaestro");
            DropForeignKey("dbo.CandidatoContacto", "CandidatoId", "dbo.Candidato");
            DropIndex("dbo.Oferta", new[] { "UsuarioModificacionId" });
            DropIndex("dbo.Oferta", new[] { "UsuarioCreacionId" });
            DropIndex("dbo.Oferta", new[] { "EstadoOfertaId" });
            DropIndex("dbo.Entrevista", new[] { "UsuarioModificacionId" });
            DropIndex("dbo.Entrevista", new[] { "UsuarioCreacionId" });
            DropIndex("dbo.Entrevista", new[] { "CandidaturaId" });
            DropIndex("dbo.Entrevista", new[] { "TipoEntrevistaId" });
            DropIndex("dbo.Entrevista", new[] { "MotivoId" });
            DropIndex("dbo.Entrevista", new[] { "EntrevistadorId" });
            DropIndex("dbo.Proyecto", new[] { "ClienteId" });
            DropIndex("dbo.Necesidad", new[] { "UsuarioModificacionId" });
            DropIndex("dbo.Necesidad", new[] { "UsuarioCreacionId" });
            DropIndex("dbo.Necesidad", new[] { "EstadoNecesidadId" });
            DropIndex("dbo.Necesidad", new[] { "MesesAsignacionId" });
            DropIndex("dbo.Necesidad", new[] { "TipoPrevisionId" });
            DropIndex("dbo.Necesidad", new[] { "TipoContratacionId" });
            DropIndex("dbo.Necesidad", new[] { "TipoTecnologiaId" });
            DropIndex("dbo.Necesidad", new[] { "TipoPerfilId" });
            DropIndex("dbo.Necesidad", new[] { "TipoServicioId" });
            DropIndex("dbo.Necesidad", new[] { "ProyectoId" });
            DropIndex("dbo.Necesidad", new[] { "SectorId" });
            DropIndex("dbo.Necesidad", new[] { "CentroId" });
            DropIndex("dbo.Necesidad", new[] { "OficinaId" });
            DropIndex("dbo.CartaOferta", new[] { "UsuarioModificacionId" });
            DropIndex("dbo.CartaOferta", new[] { "UsuarioCreacionId" });
            DropIndex("dbo.CartaOferta", new[] { "NecesidadId" });
            DropIndex("dbo.CartaOferta", new[] { "MotivoRechazoId" });
            DropIndex("dbo.CartaOferta", new[] { "EntrevistadorId" });
            DropIndex("dbo.CartaOferta", new[] { "CandidaturaId" });
            DropIndex("dbo.Candidatura", new[] { "UsuarioModificacionId" });
            DropIndex("dbo.Candidatura", new[] { "UsuarioCreacionId" });
            DropIndex("dbo.Candidatura", new[] { "CategoriaId" });
            DropIndex("dbo.Candidatura", new[] { "IncorporacionId" });
            DropIndex("dbo.Candidatura", new[] { "TipoPerfilId" });
            DropIndex("dbo.Candidatura", new[] { "TipoPerfilDeseadoId" });
            DropIndex("dbo.Candidatura", new[] { "EstadoCandidaturaId" });
            DropIndex("dbo.Candidatura", new[] { "EtapaCandidaturaId" });
            DropIndex("dbo.Candidatura", new[] { "CandidatoId" });
            DropIndex("dbo.Candidatura", new[] { "OfertaId" });
            DropIndex("dbo.Candidatura", new[] { "NecesidadId" });
            DropIndex("dbo.CandidatoIdioma", new[] { "NivelIdiomaId" });
            DropIndex("dbo.CandidatoIdioma", new[] { "IdiomaId" });
            DropIndex("dbo.CandidatoIdioma", new[] { "CandidatoId" });
            DropIndex("dbo.CandidatoExperiencia", new[] { "NivelTecnologiaId" });
            DropIndex("dbo.CandidatoExperiencia", new[] { "TipoTecnologiaId" });
            DropIndex("dbo.CandidatoExperiencia", new[] { "CandidatoId" });
            DropIndex("dbo.Maestro", new[] { "TipoMaestroId" });
            DropIndex("dbo.CandidatoContacto", new[] { "TipoMedioContactoId" });
            DropIndex("dbo.CandidatoContacto", new[] { "CandidatoId" });
            DropIndex("dbo.Candidato", new[] { "UsuarioModificacionId" });
            DropIndex("dbo.Candidato", new[] { "UsuarioCreacionId" });
            DropIndex("dbo.Candidato", new[] { "EstadoCandidatoId" });
            DropIndex("dbo.Candidato", new[] { "TitulacionId" });
            DropIndex("dbo.Candidato", new[] { "TipoIdentificacionId" });
            DropTable("dbo.Oferta");
            DropTable("dbo.TipoEtapaCandidatura");
            DropTable("dbo.TipoEstadoCandidatura");
            DropTable("dbo.TipoEntrevista");
            DropTable("dbo.Entrevista");
            DropTable("dbo.Cliente");
            DropTable("dbo.Proyecto");
            DropTable("dbo.Necesidad");
            DropTable("dbo.CartaOferta");
            DropTable("dbo.Candidatura");
            DropTable("dbo.Usuario");
            DropTable("dbo.CandidatoIdioma");
            DropTable("dbo.CandidatoExperiencia");
            DropTable("dbo.TipoMaestro");
            DropTable("dbo.Maestro");
            DropTable("dbo.CandidatoContacto");
            DropTable("dbo.Candidato");
        }
    }
}
