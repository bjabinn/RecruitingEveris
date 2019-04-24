namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFuRecOrCVEmailRefToBecario : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Becario", "OrigenCvId", c => c.Int());
            AddColumn("dbo.Becario", "FuenteReclutamientoId", c => c.Int());
            AddColumn("dbo.Becario", "EmailsReferenciados", c => c.String());
            CreateIndex("dbo.Becario", "OrigenCvId");
            CreateIndex("dbo.Becario", "FuenteReclutamientoId");
            AddForeignKey("dbo.Becario", "FuenteReclutamientoId", "dbo.Maestro", "MaestroId");
            AddForeignKey("dbo.Becario", "OrigenCvId", "dbo.Maestro", "MaestroId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Becario", "OrigenCvId", "dbo.Maestro");
            DropForeignKey("dbo.Becario", "FuenteReclutamientoId", "dbo.Maestro");
            DropIndex("dbo.Becario", new[] { "FuenteReclutamientoId" });
            DropIndex("dbo.Becario", new[] { "OrigenCvId" });
            DropColumn("dbo.Becario", "EmailsReferenciados");
            DropColumn("dbo.Becario", "FuenteReclutamientoId");
            DropColumn("dbo.Becario", "OrigenCvId");
        }
    }
}
