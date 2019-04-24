namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Aniadir_Tabla_Becario : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Becario",
                c => new
                    {
                        BecarioId = c.Int(nullable: false, identity: true),
                        CandidatoId = c.Int(nullable: false),
                        TipoBecarioId = c.Int(nullable: false),
                        CV = c.Binary(),
                        NombreCV = c.String(),
                        UrlCV = c.String(),
                        TipoEstadoBecarioId = c.Int(nullable: false),
                        BecarioCentroProcedenciaId = c.Int(nullable: false),
                        UsuarioCreacionId = c.Int(nullable: false),
                        UsuarioModificacionId = c.Int(),
                        FechaCreacion = c.DateTime(nullable: false),
                        FechaModificacion = c.DateTime(),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.BecarioId)
                .ForeignKey("dbo.BecarioCentroProcedencia", t => t.BecarioCentroProcedenciaId, cascadeDelete: false)
                .ForeignKey("dbo.Candidato", t => t.CandidatoId, cascadeDelete: false)
                .ForeignKey("dbo.Maestro", t => t.TipoBecarioId, cascadeDelete: false)
                .ForeignKey("dbo.TipoEstadoBecario", t => t.TipoEstadoBecarioId, cascadeDelete: false)
                .ForeignKey("dbo.Usuario", t => t.UsuarioCreacionId, cascadeDelete: false)
                .ForeignKey("dbo.Usuario", t => t.UsuarioModificacionId)
                .Index(t => t.CandidatoId)
                .Index(t => t.TipoBecarioId)
                .Index(t => t.TipoEstadoBecarioId)
                .Index(t => t.BecarioCentroProcedenciaId)
                .Index(t => t.UsuarioCreacionId)
                .Index(t => t.UsuarioModificacionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Becario", "UsuarioModificacionId", "dbo.Usuario");
            DropForeignKey("dbo.Becario", "UsuarioCreacionId", "dbo.Usuario");
            DropForeignKey("dbo.Becario", "TipoEstadoBecarioId", "dbo.TipoEstadoBecario");
            DropForeignKey("dbo.Becario", "TipoBecarioId", "dbo.Maestro");
            DropForeignKey("dbo.Becario", "CandidatoId", "dbo.Candidato");
            DropForeignKey("dbo.Becario", "BecarioCentroProcedenciaId", "dbo.BecarioCentroProcedencia");
            DropIndex("dbo.Becario", new[] { "UsuarioModificacionId" });
            DropIndex("dbo.Becario", new[] { "UsuarioCreacionId" });
            DropIndex("dbo.Becario", new[] { "BecarioCentroProcedenciaId" });
            DropIndex("dbo.Becario", new[] { "TipoEstadoBecarioId" });
            DropIndex("dbo.Becario", new[] { "TipoBecarioId" });
            DropIndex("dbo.Becario", new[] { "CandidatoId" });
            DropTable("dbo.Becario");
        }
    }
}
