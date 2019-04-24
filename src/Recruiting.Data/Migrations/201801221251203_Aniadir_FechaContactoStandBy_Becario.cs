namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Aniadir_FechaContactoStandBy_Becario : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Becario", "FechaContactoStandBy", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Becario", "FechaContactoStandBy");
        }
    }
}
