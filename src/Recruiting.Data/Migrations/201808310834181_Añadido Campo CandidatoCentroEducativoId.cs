namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AñadidoCampoCandidatoCentroEducativoId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Candidato", "CandidatoCentroEducativoId", c => c.Int());
            CreateIndex("dbo.Candidato", "CandidatoCentroEducativoId");
            AddForeignKey("dbo.Candidato", "CandidatoCentroEducativoId", "dbo.CandidatoCentroEducativo", "CandidatoCentroEducativoId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Candidato", "CandidatoCentroEducativoId", "dbo.CandidatoCentroEducativo");
            DropIndex("dbo.Candidato", new[] { "CandidatoCentroEducativoId" });
            DropColumn("dbo.Candidato", "CandidatoCentroEducativoId");
        }
    }
}
