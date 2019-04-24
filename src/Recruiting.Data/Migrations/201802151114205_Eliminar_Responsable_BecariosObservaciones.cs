namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Eliminar_Responsable_BecariosObservaciones : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BecarioObservacion", "ResponsableId", "dbo.Usuario");
            DropIndex("dbo.BecarioObservacion", new[] { "ResponsableId" });
            DropColumn("dbo.BecarioObservacion", "ResponsableNombre");
            DropColumn("dbo.BecarioObservacion", "ResponsableId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BecarioObservacion", "ResponsableId", c => c.Int());
            AddColumn("dbo.BecarioObservacion", "ResponsableNombre", c => c.String());
            CreateIndex("dbo.BecarioObservacion", "ResponsableId");
            AddForeignKey("dbo.BecarioObservacion", "ResponsableId", "dbo.Usuario", "UsuarioId");
        }
    }
}
