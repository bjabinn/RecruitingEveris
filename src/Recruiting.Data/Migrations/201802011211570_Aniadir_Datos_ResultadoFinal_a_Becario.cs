namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Aniadir_Datos_ResultadoFinal_a_Becario : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Becario", "TipoDecisionFinalId", c => c.Int());
            AddColumn("dbo.Becario", "ObservacionFinalPracticas", c => c.String());
            CreateIndex("dbo.Becario", "TipoDecisionFinalId");
            AddForeignKey("dbo.Becario", "TipoDecisionFinalId", "dbo.Maestro", "MaestroId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Becario", "TipoDecisionFinalId", "dbo.Maestro");
            DropIndex("dbo.Becario", new[] { "TipoDecisionFinalId" });
            DropColumn("dbo.Becario", "ObservacionFinalPracticas");
            DropColumn("dbo.Becario", "TipoDecisionFinalId");
        }
    }
}
