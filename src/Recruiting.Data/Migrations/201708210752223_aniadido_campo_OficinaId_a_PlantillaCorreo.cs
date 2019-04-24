namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aniadido_campo_OficinaId_a_PlantillaCorreo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CorreoPlantilla", "Oficina", c => c.Int());
            CreateIndex("dbo.CorreoPlantilla", "Oficina");
            AddForeignKey("dbo.CorreoPlantilla", "Oficina", "dbo.Oficina", "OficinaId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CorreoPlantilla", "Oficina", "dbo.Oficina");
            DropIndex("dbo.CorreoPlantilla", new[] { "Oficina" });
            DropColumn("dbo.CorreoPlantilla", "Oficina");
        }
    }
}
