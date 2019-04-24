namespace Recruiting.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class Eliminado_tipotecnologia_en_candidatura : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Candidatura", "TipoTecnologiaId", "dbo.Maestro");
            DropIndex("dbo.Candidatura", new[] { "TipoTecnologiaId" });
            DropColumn("dbo.Candidatura", "TipoTecnologiaId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Candidatura", "TipoTecnologiaId", c => c.Int(nullable: false));
            CreateIndex("dbo.Candidatura", "TipoTecnologiaId");
            AddForeignKey("dbo.Candidatura", "TipoTecnologiaId", "dbo.Maestro", "MaestroId", cascadeDelete: true);
        }
    }
}
