namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AniadirAnioExperiencia : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Candidatura", "AnioExperienciaCandidato", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Candidatura", "AnioExperienciaCandidato");
        }
    }
}
