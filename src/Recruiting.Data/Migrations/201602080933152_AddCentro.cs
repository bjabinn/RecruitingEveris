namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCentro : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuario", "Centro", c => c.Int());
            CreateIndex("dbo.Usuario", "Centro");
            AddForeignKey("dbo.Usuario", "Centro", "dbo.Maestro", "MaestroId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Usuario", "Centro", "dbo.Maestro");
            DropIndex("dbo.Usuario", new[] { "Centro" });
            DropColumn("dbo.Usuario", "Centro");
        }
    }
}
