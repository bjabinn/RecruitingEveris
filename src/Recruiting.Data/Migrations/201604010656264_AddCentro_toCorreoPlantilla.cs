namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCentro_toCorreoPlantilla : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CorreoPlantilla", "Centro", c => c.Int());
            CreateIndex("dbo.CorreoPlantilla", "Centro");
            AddForeignKey("dbo.CorreoPlantilla", "Centro", "dbo.Maestro", "MaestroId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CorreoPlantilla", "Centro", "dbo.Maestro");
            DropIndex("dbo.CorreoPlantilla", new[] { "Centro" });
            DropColumn("dbo.CorreoPlantilla", "Centro");
        }
    }
}
