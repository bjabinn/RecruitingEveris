namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Eliminar_Centro_de_Clientes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cliente", "Centro", "dbo.Centro");
            DropIndex("dbo.Cliente", new[] { "Centro" });
            DropColumn("dbo.Cliente", "Centro");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cliente", "Centro", c => c.Int());
            CreateIndex("dbo.Cliente", "Centro");
            AddForeignKey("dbo.Cliente", "Centro", "dbo.Centro", "CentroId");
        }
    }
}
