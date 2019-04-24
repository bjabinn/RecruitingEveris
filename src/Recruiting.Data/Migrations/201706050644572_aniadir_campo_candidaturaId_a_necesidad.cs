namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aniadir_campo_candidaturaId_a_necesidad : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Necesidad", "CandidaturaId", c => c.Int());
            CreateIndex("dbo.Necesidad", "CandidaturaId");
            AddForeignKey("dbo.Necesidad", "CandidaturaId", "dbo.Candidatura", "CandidaturaId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Necesidad", "CandidaturaId", "dbo.Candidatura");
            DropIndex("dbo.Necesidad", new[] { "CandidaturaId" });
            DropColumn("dbo.Necesidad", "CandidaturaId");
        }
    }
}
