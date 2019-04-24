namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Aniadir_columna_UrlCV_a_candidatura : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Candidatura", "UrlCV", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Candidatura", "UrlCV");
        }
    }
}
