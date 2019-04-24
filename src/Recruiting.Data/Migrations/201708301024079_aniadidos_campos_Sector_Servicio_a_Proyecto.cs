namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aniadidos_campos_Sector_Servicio_a_Proyecto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Proyecto", "SectorId", c => c.Int());
            AddColumn("dbo.Proyecto", "ServicioId", c => c.Int());
            CreateIndex("dbo.Proyecto", "SectorId");
            CreateIndex("dbo.Proyecto", "ServicioId");
            AddForeignKey("dbo.Proyecto", "SectorId", "dbo.Maestro", "MaestroId");
            AddForeignKey("dbo.Proyecto", "ServicioId", "dbo.Maestro", "MaestroId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Proyecto", "ServicioId", "dbo.Maestro");
            DropForeignKey("dbo.Proyecto", "SectorId", "dbo.Maestro");
            DropIndex("dbo.Proyecto", new[] { "ServicioId" });
            DropIndex("dbo.Proyecto", new[] { "SectorId" });
            DropColumn("dbo.Proyecto", "ServicioId");
            DropColumn("dbo.Proyecto", "SectorId");
        }
    }
}
