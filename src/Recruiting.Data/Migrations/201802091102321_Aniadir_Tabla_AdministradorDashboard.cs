namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Aniadir_Tabla_AdministradorDashboard : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdministradorDashboard",
                c => new
                    {
                        AdministradorDashboardId = c.Int(nullable: false, identity: true),
                        UsuarioId = c.Int(nullable: false),
                        NecesidadesCreadasModificadas = c.Boolean(nullable: false),
                        PrimeraEntrevista = c.Boolean(nullable: false),
                        SubEntrevistaPrimeraEntrevista = c.Boolean(nullable: false),
                        SegundaEntrevista = c.Boolean(nullable: false),
                        SubEntrevistaSegundaEntrevista = c.Boolean(nullable: false),
                        CartaOferta = c.Boolean(nullable: false),
                        CvPendienteFiltro = c.Boolean(nullable: false),
                        CandidaturaStandBy = c.Boolean(nullable: false),
                        BecarioStandBy = c.Boolean(nullable: false),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AdministradorDashboardId)
                .ForeignKey("dbo.Usuario", t => t.UsuarioId, cascadeDelete: true)
                .Index(t => t.UsuarioId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AdministradorDashboard", "UsuarioId", "dbo.Usuario");
            DropIndex("dbo.AdministradorDashboard", new[] { "UsuarioId" });
            DropTable("dbo.AdministradorDashboard");
        }
    }
}
