namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MaestroCampoOrden : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Maestro", "Orden", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Maestro", "Orden");
        }
    }
}
