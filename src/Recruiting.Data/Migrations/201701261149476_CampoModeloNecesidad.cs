namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CampoModeloNecesidad : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Necesidad", "Modulo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Necesidad", "Modulo");
        }
    }
}
