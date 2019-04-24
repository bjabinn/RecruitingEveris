namespace Recruiting.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class Nuevo_Campo_TipoTecnologia_en_Candidatura : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Candidatura", "TipoTecnologiaId", c => c.Int(nullable: false));
            CreateIndex("dbo.Candidatura", "TipoTecnologiaId");
            AddForeignKey("dbo.Candidatura", "TipoTecnologiaId", "dbo.Maestro", "MaestroId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Candidatura", "TipoTecnologiaId", "dbo.Maestro");
            DropIndex("dbo.Candidatura", new[] { "TipoTecnologiaId" });
            DropColumn("dbo.Candidatura", "TipoTecnologiaId");
        }
    }
}
