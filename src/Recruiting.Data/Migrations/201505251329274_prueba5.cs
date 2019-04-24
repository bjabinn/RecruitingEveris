namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class prueba5 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Necesidad", "SalarioDeseado");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Necesidad", "SalarioDeseado", c => c.Decimal(precision: 18, scale: 2));
        }
    }
}
