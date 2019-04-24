namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Aniadir_PersonaConvocatoriaId_y_ResponsableId_A_BecarioObservacion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BecarioObservacion", "PersonaConvocatoriaNombre", c => c.String());
            AddColumn("dbo.BecarioObservacion", "PersonaConvocatoriaId", c => c.Int());
            AddColumn("dbo.BecarioObservacion", "ResponsableNombre", c => c.String());
            AddColumn("dbo.BecarioObservacion", "ResponsableId", c => c.Int());
            CreateIndex("dbo.BecarioObservacion", "PersonaConvocatoriaId");
            CreateIndex("dbo.BecarioObservacion", "ResponsableId");
            AddForeignKey("dbo.BecarioObservacion", "PersonaConvocatoriaId", "dbo.Usuario", "UsuarioId");
            AddForeignKey("dbo.BecarioObservacion", "ResponsableId", "dbo.Usuario", "UsuarioId");
            DropColumn("dbo.BecarioObservacion", "PersonaConvocatoria");
            DropColumn("dbo.BecarioObservacion", "Responsable");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BecarioObservacion", "Responsable", c => c.String());
            AddColumn("dbo.BecarioObservacion", "PersonaConvocatoria", c => c.String());
            DropForeignKey("dbo.BecarioObservacion", "ResponsableId", "dbo.Usuario");
            DropForeignKey("dbo.BecarioObservacion", "PersonaConvocatoriaId", "dbo.Usuario");
            DropIndex("dbo.BecarioObservacion", new[] { "ResponsableId" });
            DropIndex("dbo.BecarioObservacion", new[] { "PersonaConvocatoriaId" });
            DropColumn("dbo.BecarioObservacion", "ResponsableId");
            DropColumn("dbo.BecarioObservacion", "ResponsableNombre");
            DropColumn("dbo.BecarioObservacion", "PersonaConvocatoriaId");
            DropColumn("dbo.BecarioObservacion", "PersonaConvocatoriaNombre");
        }
    }
}
