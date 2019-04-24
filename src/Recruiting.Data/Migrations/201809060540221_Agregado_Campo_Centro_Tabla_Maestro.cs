namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Agregado_Campo_Centro_Tabla_Maestro : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Maestro", "CentroId", c => c.Int());
            CreateIndex("dbo.Maestro", "CentroId");
            AddForeignKey("dbo.Maestro", "CentroId", "dbo.Centro", "CentroId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Maestro", "CentroId", "dbo.Centro");
            DropIndex("dbo.Maestro", new[] { "CentroId" });
            DropColumn("dbo.Maestro", "CentroId");
        }
    }
}
