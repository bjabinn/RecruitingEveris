namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeCentroFK : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Usuario", "Centro", "dbo.Maestro");
            DropForeignKey("dbo.Cliente", "Centro", "dbo.Maestro");
            DropForeignKey("dbo.CorreoPlantilla", "Centro", "dbo.Maestro");
            DropForeignKey("dbo.MonedasDeCentro", "Centro", "dbo.Maestro");
            AddForeignKey("dbo.Usuario", "Centro", "dbo.Centro", "CentroId");
            AddForeignKey("dbo.Cliente", "Centro", "dbo.Centro", "CentroId");
            AddForeignKey("dbo.CorreoPlantilla", "Centro", "dbo.Centro", "CentroId");
            AddForeignKey("dbo.MonedasDeCentro", "Centro", "dbo.Centro", "CentroId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MonedasDeCentro", "Centro", "dbo.Centro");
            DropForeignKey("dbo.CorreoPlantilla", "Centro", "dbo.Centro");
            DropForeignKey("dbo.Cliente", "Centro", "dbo.Centro");
            DropForeignKey("dbo.Usuario", "Centro", "dbo.Centro");
            AddForeignKey("dbo.MonedasDeCentro", "Centro", "dbo.Maestro", "MaestroId", cascadeDelete: true);
            AddForeignKey("dbo.CorreoPlantilla", "Centro", "dbo.Maestro", "MaestroId");
            AddForeignKey("dbo.Cliente", "Centro", "dbo.Maestro", "MaestroId");
            AddForeignKey("dbo.Usuario", "Centro", "dbo.Maestro", "MaestroId");
        }
    }
}
