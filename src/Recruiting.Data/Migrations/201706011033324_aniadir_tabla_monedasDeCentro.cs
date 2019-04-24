namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aniadir_tabla_monedasDeCentro : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MonedasDeCentro",
                c => new
                    {
                        MonedasDeCentroId = c.Int(nullable: false, identity: true),
                        Centro = c.Int(nullable: false),
                        Descripción = c.String(nullable: false, maxLength: 3),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MonedasDeCentroId)
                .ForeignKey("dbo.Maestro", t => t.Centro, cascadeDelete: true)
                .Index(t => t.Centro);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MonedasDeCentro", "Centro", "dbo.Maestro");
            DropIndex("dbo.MonedasDeCentro", new[] { "Centro" });
            DropTable("dbo.MonedasDeCentro");
        }
    }
}
