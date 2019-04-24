namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Agregado_Campo_CandidaturaOfertaId_A_Candidaturas : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Candidatura", "CandidaturaOfertaId", c => c.Int());
            CreateIndex("dbo.Candidatura", "CandidaturaOfertaId");
            AddForeignKey("dbo.Candidatura", "CandidaturaOfertaId", "dbo.CandidaturaOferta", "CandidaturaOfertaId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Candidatura", "CandidaturaOfertaId", "dbo.CandidaturaOferta");
            DropIndex("dbo.Candidatura", new[] { "CandidaturaOfertaId" });
            DropColumn("dbo.Candidatura", "CandidaturaOfertaId");
        }
    }
}
