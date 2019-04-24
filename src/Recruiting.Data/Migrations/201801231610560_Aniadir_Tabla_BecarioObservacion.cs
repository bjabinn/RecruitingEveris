namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Aniadir_Tabla_BecarioObservacion : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BecarioObservacion",
                c => new
                    {
                        BecarioObservacionId = c.Int(nullable: false, identity: true),
                        BecarioId = c.Int(nullable: false),
                        TipoPruebaId = c.Int(nullable: false),
                        TipoResultadoId = c.Int(),
                        FechaConvocatoria = c.DateTime(),
                        PersonaConvocatoriaId = c.Int(),
                        ResponsableId = c.Int(),
                        Observaciones = c.String(),
                        UsuarioCreacionId = c.Int(nullable: false),
                        UsuarioModificacionId = c.Int(),
                        FechaCreacion = c.DateTime(nullable: false),
                        FechaModificacion = c.DateTime(),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.BecarioObservacionId)
                .ForeignKey("dbo.Becario", t => t.BecarioId, cascadeDelete: true)
                .ForeignKey("dbo.Usuario", t => t.PersonaConvocatoriaId)
                .ForeignKey("dbo.Usuario", t => t.ResponsableId)
                .ForeignKey("dbo.Maestro", t => t.TipoPruebaId, cascadeDelete: true)
                .ForeignKey("dbo.Maestro", t => t.TipoResultadoId)
                .ForeignKey("dbo.Usuario", t => t.UsuarioCreacionId, cascadeDelete: true)
                .ForeignKey("dbo.Usuario", t => t.UsuarioModificacionId)
                .Index(t => t.BecarioId)
                .Index(t => t.TipoPruebaId)
                .Index(t => t.TipoResultadoId)
                .Index(t => t.PersonaConvocatoriaId)
                .Index(t => t.ResponsableId)
                .Index(t => t.UsuarioCreacionId)
                .Index(t => t.UsuarioModificacionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BecarioObservacion", "UsuarioModificacionId", "dbo.Usuario");
            DropForeignKey("dbo.BecarioObservacion", "UsuarioCreacionId", "dbo.Usuario");
            DropForeignKey("dbo.BecarioObservacion", "TipoResultadoId", "dbo.Maestro");
            DropForeignKey("dbo.BecarioObservacion", "TipoPruebaId", "dbo.Maestro");
            DropForeignKey("dbo.BecarioObservacion", "ResponsableId", "dbo.Usuario");
            DropForeignKey("dbo.BecarioObservacion", "PersonaConvocatoriaId", "dbo.Usuario");
            DropForeignKey("dbo.BecarioObservacion", "BecarioId", "dbo.Becario");
            DropIndex("dbo.BecarioObservacion", new[] { "UsuarioModificacionId" });
            DropIndex("dbo.BecarioObservacion", new[] { "UsuarioCreacionId" });
            DropIndex("dbo.BecarioObservacion", new[] { "ResponsableId" });
            DropIndex("dbo.BecarioObservacion", new[] { "PersonaConvocatoriaId" });
            DropIndex("dbo.BecarioObservacion", new[] { "TipoResultadoId" });
            DropIndex("dbo.BecarioObservacion", new[] { "TipoPruebaId" });
            DropIndex("dbo.BecarioObservacion", new[] { "BecarioId" });
            DropTable("dbo.BecarioObservacion");
        }
    }
}
