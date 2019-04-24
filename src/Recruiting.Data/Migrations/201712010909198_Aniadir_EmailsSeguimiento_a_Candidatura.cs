namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Aniadir_EmailsSeguimiento_a_Candidatura : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Candidatura", "EmailsSeguimiento", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Candidatura", "EmailsSeguimiento");
        }
    }
}
