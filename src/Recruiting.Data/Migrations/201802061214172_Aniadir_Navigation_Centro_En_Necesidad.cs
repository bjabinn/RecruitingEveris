namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Aniadir_Navigation_Centro_En_Necesidad : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Necesidad", "CentroId");
            AddForeignKey("dbo.Necesidad", "CentroId", "dbo.Centro", "CentroId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Necesidad", "CentroId", "dbo.Centro");
            DropIndex("dbo.Necesidad", new[] { "CentroId" });
        }
    }
}
