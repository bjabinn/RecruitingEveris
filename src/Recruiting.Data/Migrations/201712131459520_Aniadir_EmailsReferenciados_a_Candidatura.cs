namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Aniadir_EmailsReferenciados_a_Candidatura : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Candidatura", "EmailsReferenciados", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Candidatura", "EmailsReferenciados");
        }
    }
}
