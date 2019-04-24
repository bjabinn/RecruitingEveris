namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CampoModuloCandidaturas : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Candidatura", "Modulo", c => c.String());
            AddColumn("dbo.Candidatura", "TipoModulo_MaestroId", c => c.Int());
            CreateIndex("dbo.Candidatura", "TipoModulo_MaestroId");
            AddForeignKey("dbo.Candidatura", "TipoModulo_MaestroId", "dbo.Maestro", "MaestroId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Candidatura", "TipoModulo_MaestroId", "dbo.Maestro");
            DropIndex("dbo.Candidatura", new[] { "TipoModulo_MaestroId" });
            DropColumn("dbo.Candidatura", "TipoModulo_MaestroId");
            DropColumn("dbo.Candidatura", "Modulo");
        }
    }
}
