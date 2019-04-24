namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Aniadir_Centro_a_Proyectos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Proyecto", "Centro", c => c.Int());
            CreateIndex("dbo.Proyecto", "Centro");
            AddForeignKey("dbo.Proyecto", "Centro", "dbo.Centro", "CentroId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Proyecto", "Centro", "dbo.Centro");
            DropIndex("dbo.Proyecto", new[] { "Centro" });
            DropColumn("dbo.Proyecto", "Centro");
        }
    }
}
