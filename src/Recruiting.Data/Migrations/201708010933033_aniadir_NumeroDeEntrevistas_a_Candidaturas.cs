namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aniadir_NumeroDeEntrevistas_a_Candidaturas : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Candidatura", "NumeroDeEntrevistas", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Candidatura", "NumeroDeEntrevistas");
        }
    }
}
