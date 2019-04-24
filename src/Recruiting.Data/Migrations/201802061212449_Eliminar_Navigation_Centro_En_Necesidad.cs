namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Eliminar_Navigation_Centro_En_Necesidad : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Necesidad", "CentroId", "dbo.Maestro");
            DropIndex("dbo.Necesidad", new[] { "CentroId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Necesidad", "CentroId");
            AddForeignKey("dbo.Necesidad", "CentroId", "dbo.Maestro", "MaestroId", cascadeDelete: true);
        }
    }
}
