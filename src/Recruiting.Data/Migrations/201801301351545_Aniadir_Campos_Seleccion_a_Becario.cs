namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Aniadir_Campos_Seleccion_a_Becario : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Becario", "FechaBecaInicio", c => c.DateTime());
            AddColumn("dbo.Becario", "FechaBecaFin", c => c.DateTime());
            AddColumn("dbo.Becario", "FechaBecaFinReal", c => c.DateTime());
            AddColumn("dbo.Becario", "NumHoras", c => c.Int());
            AddColumn("dbo.Becario", "Anexo", c => c.Binary());
            AddColumn("dbo.Becario", "NombreAnexo", c => c.String());
            AddColumn("dbo.Becario", "UrlAnexo", c => c.String());
            AddColumn("dbo.Becario", "TutorId", c => c.Int());
            AddColumn("dbo.Becario", "TutorNombre", c => c.String());
            AddColumn("dbo.Becario", "ResponsableNombre", c => c.String());
            AddColumn("dbo.Becario", "ResponsableId", c => c.Int());
            AddColumn("dbo.Becario", "ClienteId", c => c.Int());
            AddColumn("dbo.Becario", "ProyectoId", c => c.Int());
            AddColumn("dbo.Becario", "CompletadoGestion", c => c.Boolean(nullable: false));
            AddColumn("dbo.Becario", "CompletadoAsignacion", c => c.Boolean(nullable: false));
            AddColumn("dbo.Becario", "TipoAsistenciaId", c => c.Int());
            CreateIndex("dbo.Becario", "TutorId");
            CreateIndex("dbo.Becario", "ResponsableId");
            CreateIndex("dbo.Becario", "ClienteId");
            CreateIndex("dbo.Becario", "ProyectoId");
            CreateIndex("dbo.Becario", "TipoAsistenciaId");
            AddForeignKey("dbo.Becario", "ClienteId", "dbo.Cliente", "ClienteId");
            AddForeignKey("dbo.Becario", "ProyectoId", "dbo.Proyecto", "ProyectoId");
            AddForeignKey("dbo.Becario", "ResponsableId", "dbo.Usuario", "UsuarioId");
            AddForeignKey("dbo.Becario", "TipoAsistenciaId", "dbo.Maestro", "MaestroId");
            AddForeignKey("dbo.Becario", "TutorId", "dbo.Usuario", "UsuarioId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Becario", "TutorId", "dbo.Usuario");
            DropForeignKey("dbo.Becario", "TipoAsistenciaId", "dbo.Maestro");
            DropForeignKey("dbo.Becario", "ResponsableId", "dbo.Usuario");
            DropForeignKey("dbo.Becario", "ProyectoId", "dbo.Proyecto");
            DropForeignKey("dbo.Becario", "ClienteId", "dbo.Cliente");
            DropIndex("dbo.Becario", new[] { "TipoAsistenciaId" });
            DropIndex("dbo.Becario", new[] { "ProyectoId" });
            DropIndex("dbo.Becario", new[] { "ClienteId" });
            DropIndex("dbo.Becario", new[] { "ResponsableId" });
            DropIndex("dbo.Becario", new[] { "TutorId" });
            DropColumn("dbo.Becario", "TipoAsistenciaId");
            DropColumn("dbo.Becario", "CompletadoAsignacion");
            DropColumn("dbo.Becario", "CompletadoGestion");
            DropColumn("dbo.Becario", "ProyectoId");
            DropColumn("dbo.Becario", "ClienteId");
            DropColumn("dbo.Becario", "ResponsableId");
            DropColumn("dbo.Becario", "ResponsableNombre");
            DropColumn("dbo.Becario", "TutorNombre");
            DropColumn("dbo.Becario", "TutorId");
            DropColumn("dbo.Becario", "UrlAnexo");
            DropColumn("dbo.Becario", "NombreAnexo");
            DropColumn("dbo.Becario", "Anexo");
            DropColumn("dbo.Becario", "NumHoras");
            DropColumn("dbo.Becario", "FechaBecaFinReal");
            DropColumn("dbo.Becario", "FechaBecaFin");
            DropColumn("dbo.Becario", "FechaBecaInicio");
        }
    }
}
