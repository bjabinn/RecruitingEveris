namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCentroToClientes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cliente", "Centro", c => c.Int());
            CreateIndex("dbo.Cliente", "Centro");
            AddForeignKey("dbo.Cliente", "Centro", "dbo.Maestro", "MaestroId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cliente", "Centro", "dbo.Maestro");
            DropIndex("dbo.Cliente", new[] { "Centro" });
            DropColumn("dbo.Cliente", "Centro");
        }
    }
}
