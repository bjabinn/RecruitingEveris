namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RTOOLS10_Anhadir_origenCV_FuenteReclutamiento : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Candidatura", "FuenteReclutamientoId", c => c.Int());
            AddColumn("dbo.Candidatura", "OrigenCvId", c => c.Int());
            CreateIndex("dbo.Candidatura", "FuenteReclutamientoId");
            CreateIndex("dbo.Candidatura", "OrigenCvId");
            AddForeignKey("dbo.Candidatura", "FuenteReclutamientoId", "dbo.Maestro", "MaestroId");
            AddForeignKey("dbo.Candidatura", "OrigenCvId", "dbo.Maestro", "MaestroId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Candidatura", "OrigenCvId", "dbo.Maestro");
            DropForeignKey("dbo.Candidatura", "FuenteReclutamientoId", "dbo.Maestro");
            DropIndex("dbo.Candidatura", new[] { "OrigenCvId" });
            DropIndex("dbo.Candidatura", new[] { "FuenteReclutamientoId" });
            DropColumn("dbo.Candidatura", "OrigenCvId");
            DropColumn("dbo.Candidatura", "FuenteReclutamientoId");
        }
    }
}
