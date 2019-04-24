namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Aniadir_tabla_BlackListSala : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BlackListSala",
                c => new
                    {
                        BlackListSalaId = c.Int(nullable: false, identity: true),
                        Salas = c.String(),
                        CentroId = c.Int(nullable: false),
                        OficinaId = c.Int(),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.BlackListSalaId)
                .ForeignKey("dbo.Centro", t => t.CentroId, cascadeDelete: true)
                .ForeignKey("dbo.Oficina", t => t.OficinaId)
                .Index(t => t.CentroId)
                .Index(t => t.OficinaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BlackListSala", "OficinaId", "dbo.Oficina");
            DropForeignKey("dbo.BlackListSala", "CentroId", "dbo.Centro");
            DropIndex("dbo.BlackListSala", new[] { "OficinaId" });
            DropIndex("dbo.BlackListSala", new[] { "CentroId" });
            DropTable("dbo.BlackListSala");
        }
    }
}
