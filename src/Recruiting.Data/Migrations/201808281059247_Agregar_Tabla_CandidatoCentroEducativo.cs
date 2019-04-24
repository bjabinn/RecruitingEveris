namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Agregar_Tabla_CandidatoCentroEducativo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CandidatoCentroEducativo",
                c => new
                    {
                        CandidatoCentroEducativoId = c.Int(nullable: false, identity: true),
                        Centro = c.String(),
                        Ciudad = c.String(),
                        Pais = c.String(),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CandidatoCentroEducativoId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CandidatoCentroEducativo");
        }
    }
}
