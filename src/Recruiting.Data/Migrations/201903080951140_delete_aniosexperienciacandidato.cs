namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class delete_aniosexperienciacandidato : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Candidatura", "AnioExperienciaCandidato");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Candidatura", "AnioExperienciaCandidato", c => c.Int());
        }
    }
}
