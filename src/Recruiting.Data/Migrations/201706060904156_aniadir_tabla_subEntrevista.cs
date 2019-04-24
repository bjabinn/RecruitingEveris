namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aniadir_tabla_subEntrevista : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SubEntrevista",
                c => new
                    {
                        SubEntrevistaId = c.Int(nullable: false, identity: true),
                        EntrevistadorId = c.Int(nullable: false),
                        FechaEntrevista = c.DateTime(nullable: false),
                        Completada = c.Boolean(nullable: false, defaultValue: false),
                        EntrevistaId = c.Int(nullable: false),
                        Observaciones = c.String(),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.SubEntrevistaId)
                .ForeignKey("dbo.Entrevista", t => t.EntrevistaId, cascadeDelete: true)
                .ForeignKey("dbo.Usuario", t => t.EntrevistadorId, cascadeDelete: false)
                .Index(t => t.EntrevistadorId)
                .Index(t => t.EntrevistaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubEntrevista", "EntrevistadorId", "dbo.Usuario");
            DropForeignKey("dbo.SubEntrevista", "EntrevistaId", "dbo.Entrevista");
            DropIndex("dbo.SubEntrevista", new[] { "EntrevistaId" });
            DropIndex("dbo.SubEntrevista", new[] { "EntrevistadorId" });
            DropTable("dbo.SubEntrevista");
        }
    }
}
