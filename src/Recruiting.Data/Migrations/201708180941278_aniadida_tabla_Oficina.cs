namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aniadida_tabla_Oficina : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Oficina",
                c => new
                    {
                        OficinaId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 250),
                        CentroId = c.Int(nullable: false),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.OficinaId)
                .ForeignKey("dbo.Centro", t => t.CentroId, cascadeDelete: true)
                .Index(t => t.CentroId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Oficina", "CentroId", "dbo.Centro");
            DropIndex("dbo.Oficina", new[] { "CentroId" });
            DropTable("dbo.Oficina");
        }
    }
}
