namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Aniadir_Tabla_BecarioConvocatoria_y_Campo_ConvocatoriaId_a_Becario : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BecarioConvocatoria",
                c => new
                    {
                        BecarioConvocatoriaId = c.Int(nullable: false, identity: true),
                        NombreConvocatoria = c.String(),
                        Ciudad = c.String(),
                        Pais = c.String(),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.BecarioConvocatoriaId);
            
            AddColumn("dbo.Becario", "BecarioConvocatoriaId", c => c.Int());
            CreateIndex("dbo.Becario", "BecarioConvocatoriaId");
            AddForeignKey("dbo.Becario", "BecarioConvocatoriaId", "dbo.BecarioConvocatoria", "BecarioConvocatoriaId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Becario", "BecarioConvocatoriaId", "dbo.BecarioConvocatoria");
            DropIndex("dbo.Becario", new[] { "BecarioConvocatoriaId" });
            DropColumn("dbo.Becario", "BecarioConvocatoriaId");
            DropTable("dbo.BecarioConvocatoria");
        }
    }
}
