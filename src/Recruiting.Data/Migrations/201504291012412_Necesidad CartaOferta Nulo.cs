namespace Recruiting.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class NecesidadCartaOfertaNulo : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CartaOferta", "NecesidadId", "dbo.Necesidad");
            DropIndex("dbo.CartaOferta", new[] { "NecesidadId" });
            AlterColumn("dbo.CartaOferta", "NecesidadId", c => c.Int());
            CreateIndex("dbo.CartaOferta", "NecesidadId");
            AddForeignKey("dbo.CartaOferta", "NecesidadId", "dbo.Necesidad", "NecesidadId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CartaOferta", "NecesidadId", "dbo.Necesidad");
            DropIndex("dbo.CartaOferta", new[] { "NecesidadId" });
            AlterColumn("dbo.CartaOferta", "NecesidadId", c => c.Int(nullable: false));
            CreateIndex("dbo.CartaOferta", "NecesidadId");
            AddForeignKey("dbo.CartaOferta", "NecesidadId", "dbo.Necesidad", "NecesidadId", cascadeDelete: true);
        }
    }
}
