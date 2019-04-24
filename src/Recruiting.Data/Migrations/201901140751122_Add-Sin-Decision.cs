namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSinDecision : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Entrevista", "SinDecision", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Entrevista", "SinDecision");
        }
    }
}
