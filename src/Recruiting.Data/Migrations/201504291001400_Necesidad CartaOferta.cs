namespace Recruiting.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class NecesidadCartaOferta : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Candidatura", "NecesidadId", "dbo.Necesidad");
            DropIndex("dbo.Candidatura", new[] { "NecesidadId" });
            DropColumn("dbo.Candidatura", "NecesidadId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Candidatura", "NecesidadId", c => c.Int());
            CreateIndex("dbo.Candidatura", "NecesidadId");
            AddForeignKey("dbo.Candidatura", "NecesidadId", "dbo.Necesidad", "NecesidadId");
        }
    }
}
