namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Cambiado_Tipo_Campos_BecarioObservacion : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BecarioObservacion", "PersonaConvocatoriaId", "dbo.Usuario");
            DropForeignKey("dbo.BecarioObservacion", "ResponsableId", "dbo.Usuario");
            DropIndex("dbo.BecarioObservacion", new[] { "PersonaConvocatoriaId" });
            DropIndex("dbo.BecarioObservacion", new[] { "ResponsableId" });
            AddColumn("dbo.BecarioObservacion", "PersonaConvocatoria", c => c.String());
            AddColumn("dbo.BecarioObservacion", "Responsable", c => c.String());
            DropColumn("dbo.BecarioObservacion", "PersonaConvocatoriaId");
            DropColumn("dbo.BecarioObservacion", "ResponsableId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BecarioObservacion", "ResponsableId", c => c.Int());
            AddColumn("dbo.BecarioObservacion", "PersonaConvocatoriaId", c => c.Int());
            DropColumn("dbo.BecarioObservacion", "Responsable");
            DropColumn("dbo.BecarioObservacion", "PersonaConvocatoria");
            CreateIndex("dbo.BecarioObservacion", "ResponsableId");
            CreateIndex("dbo.BecarioObservacion", "PersonaConvocatoriaId");
            AddForeignKey("dbo.BecarioObservacion", "ResponsableId", "dbo.Usuario", "UsuarioId");
            AddForeignKey("dbo.BecarioObservacion", "PersonaConvocatoriaId", "dbo.Usuario", "UsuarioId");
        }
    }
}
