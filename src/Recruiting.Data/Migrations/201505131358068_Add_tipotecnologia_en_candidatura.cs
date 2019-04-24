namespace Recruiting.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class Add_tipotecnologia_en_candidatura : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Candidatura", "TipoTecnologiaId", c => c.Int());
            CreateIndex("dbo.Candidatura", "TipoTecnologiaId");
            AddForeignKey("dbo.Candidatura", "TipoTecnologiaId", "dbo.Maestro", "MaestroId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Candidatura", "TipoTecnologiaId", "dbo.Maestro");
            DropIndex("dbo.Candidatura", new[] { "TipoTecnologiaId" });
            DropColumn("dbo.Candidatura", "TipoTecnologiaId");
        }
    }
}
