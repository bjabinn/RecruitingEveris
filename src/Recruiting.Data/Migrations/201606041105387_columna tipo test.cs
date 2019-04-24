namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class columnatipotest : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Entrevista", "TS", c => c.Binary());
            AddColumn("dbo.Entrevista", "NombreTS", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Entrevista", "NombreTS");
            DropColumn("dbo.Entrevista", "TS");
        }
    }
}
