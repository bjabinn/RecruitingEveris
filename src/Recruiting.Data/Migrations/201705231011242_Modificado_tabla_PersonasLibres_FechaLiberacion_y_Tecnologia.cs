namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Modificado_tabla_PersonasLibres_FechaLiberacion_y_Tecnologia : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PersonaLibre", "TipoTecnologiaId", c => c.Int());
            AddColumn("dbo.PersonaLibre", "UsuarioCreacionId", c => c.Int(nullable: false));
            AddColumn("dbo.PersonaLibre", "UsuarioModificacionId", c => c.Int());
            AddColumn("dbo.PersonaLibre", "FechaCreacion", c => c.DateTime(nullable: false));
            AddColumn("dbo.PersonaLibre", "FechaModificacion", c => c.DateTime());
            AlterColumn("dbo.PersonaLibre", "FechaLiberacion", c => c.DateTime(nullable: false));
            CreateIndex("dbo.PersonaLibre", "TipoTecnologiaId");
            CreateIndex("dbo.PersonaLibre", "UsuarioCreacionId");
            CreateIndex("dbo.PersonaLibre", "UsuarioModificacionId");
            AddForeignKey("dbo.PersonaLibre", "TipoTecnologiaId", "dbo.Maestro", "MaestroId");
            AddForeignKey("dbo.PersonaLibre", "UsuarioCreacionId", "dbo.Usuario", "UsuarioId", cascadeDelete: true);
            AddForeignKey("dbo.PersonaLibre", "UsuarioModificacionId", "dbo.Usuario", "UsuarioId");
            DropColumn("dbo.PersonaLibre", "EstadoPersonaLibreId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PersonaLibre", "EstadoPersonaLibreId", c => c.Int());
            DropForeignKey("dbo.PersonaLibre", "UsuarioModificacionId", "dbo.Usuario");
            DropForeignKey("dbo.PersonaLibre", "UsuarioCreacionId", "dbo.Usuario");
            DropForeignKey("dbo.PersonaLibre", "TipoTecnologiaId", "dbo.Maestro");
            DropIndex("dbo.PersonaLibre", new[] { "UsuarioModificacionId" });
            DropIndex("dbo.PersonaLibre", new[] { "UsuarioCreacionId" });
            DropIndex("dbo.PersonaLibre", new[] { "TipoTecnologiaId" });
            AlterColumn("dbo.PersonaLibre", "FechaLiberacion", c => c.DateTime());
            DropColumn("dbo.PersonaLibre", "FechaModificacion");
            DropColumn("dbo.PersonaLibre", "FechaCreacion");
            DropColumn("dbo.PersonaLibre", "UsuarioModificacionId");
            DropColumn("dbo.PersonaLibre", "UsuarioCreacionId");
            DropColumn("dbo.PersonaLibre", "TipoTecnologiaId");
        }
    }
}
