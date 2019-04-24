namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Prueba3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Necesidad", "SalarioDeseado", c => c.Decimal(nullable: true));
        }
        
        public override void Down()
        {
        }
    }
}
