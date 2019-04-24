namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Aniadir_Tabla_BitacoraBecario : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BitacoraBecario",
                c => new
                    {
                        BitacoraId = c.Int(nullable: false, identity: true),
                        NecesidadId = c.Int(nullable: false),
                        TipoBitacora = c.Int(),
                        MensajeSistema = c.String(),
                        EstadoAnteriorId = c.Int(),
                        EstadoNuevoId = c.Int(),
                        UsuarioCreacionId = c.Int(nullable: false),
                        UsuarioModificacionId = c.Int(),
                        FechaCreacion = c.DateTime(nullable: false),
                        FechaModificacion = c.DateTime(),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.BitacoraId)
                .ForeignKey("dbo.Becario", t => t.NecesidadId, cascadeDelete: true)
                .ForeignKey("dbo.Maestro", t => t.EstadoAnteriorId)
                .ForeignKey("dbo.Maestro", t => t.EstadoNuevoId)
                .ForeignKey("dbo.Usuario", t => t.UsuarioCreacionId, cascadeDelete: true)
                .ForeignKey("dbo.Usuario", t => t.UsuarioModificacionId)
                .Index(t => t.NecesidadId)
                .Index(t => t.EstadoAnteriorId)
                .Index(t => t.EstadoNuevoId)
                .Index(t => t.UsuarioCreacionId)
                .Index(t => t.UsuarioModificacionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BitacoraBecario", "UsuarioModificacionId", "dbo.Usuario");
            DropForeignKey("dbo.BitacoraBecario", "UsuarioCreacionId", "dbo.Usuario");
            DropForeignKey("dbo.BitacoraBecario", "EstadoNuevoId", "dbo.Maestro");
            DropForeignKey("dbo.BitacoraBecario", "EstadoAnteriorId", "dbo.Maestro");
            DropForeignKey("dbo.BitacoraBecario", "NecesidadId", "dbo.Becario");
            DropIndex("dbo.BitacoraBecario", new[] { "UsuarioModificacionId" });
            DropIndex("dbo.BitacoraBecario", new[] { "UsuarioCreacionId" });
            DropIndex("dbo.BitacoraBecario", new[] { "EstadoNuevoId" });
            DropIndex("dbo.BitacoraBecario", new[] { "EstadoAnteriorId" });
            DropIndex("dbo.BitacoraBecario", new[] { "NecesidadId" });
            DropTable("dbo.BitacoraBecario");
        }
    }
}
