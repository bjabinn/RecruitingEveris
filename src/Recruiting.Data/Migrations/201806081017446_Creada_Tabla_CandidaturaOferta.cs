namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Creada_Tabla_CandidaturaOferta : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CandidaturaOferta",
                c => new
                    {
                        CandidaturaOfertaId = c.Int(nullable: false, identity: true),
                        NombreOferta = c.String(),
                        CentroId = c.Int(),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CandidaturaOfertaId)
                .ForeignKey("dbo.Centro", t => t.CentroId)
                .Index(t => t.CentroId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CandidaturaOferta", "CentroId", "dbo.Centro");
            DropIndex("dbo.CandidaturaOferta", new[] { "CentroId" });
            DropTable("dbo.CandidaturaOferta");
        }
    }
}
