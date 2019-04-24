namespace Recruiting.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class CambiosTablas : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Candidatura", "NecesidadId", "dbo.Necesidad");
            DropForeignKey("dbo.Candidatura", "OfertaId", "dbo.Oferta");
            DropIndex("dbo.Candidatura", new[] { "NecesidadId" });
            DropIndex("dbo.Candidatura", new[] { "OfertaId" });
            CreateTable(
                "dbo.RelacionEtapa",
                c => new
                    {
                        RelacionEtapaId = c.Int(nullable: false, identity: true),
                        EtapaOrigenId = c.Int(nullable: false),
                        EtapaFinId = c.Int(nullable: false),
                        TipoDecisionId = c.Int(nullable: false),
                        EstadoFinId = c.Int(nullable: false),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.RelacionEtapaId)
                .ForeignKey("dbo.TipoEstadoCandidatura", t => t.EstadoFinId, cascadeDelete: false)
                .ForeignKey("dbo.TipoEtapaCandidatura", t => t.EtapaFinId, cascadeDelete: false)
                .ForeignKey("dbo.TipoEtapaCandidatura", t => t.EtapaOrigenId, cascadeDelete: false)
                .ForeignKey("dbo.TipoDecision", t => t.TipoDecisionId, cascadeDelete: false)
                .Index(t => t.EtapaOrigenId)
                .Index(t => t.EtapaFinId)
                .Index(t => t.TipoDecisionId)
                .Index(t => t.EstadoFinId);
            
            CreateTable(
                "dbo.TipoDecision",
                c => new
                    {
                        TipoDecisionId = c.Int(nullable: false, identity: true),
                        Decision = c.String(nullable: false, maxLength: 250),
                        TipoEtapaCandidaturaId = c.Int(nullable: false),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TipoDecisionId)
                .ForeignKey("dbo.TipoEtapaCandidatura", t => t.TipoEtapaCandidaturaId, cascadeDelete: true)
                .Index(t => t.TipoEtapaCandidaturaId);
            
            CreateTable(
                "dbo.RelacionVistaEtapa",
                c => new
                    {
                        RelacionVistaEtapaId = c.Int(nullable: false, identity: true),
                        EtapaId = c.Int(nullable: false),
                        VistaMostrar = c.String(),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.RelacionVistaEtapaId)
                .ForeignKey("dbo.TipoEtapaCandidatura", t => t.EtapaId, cascadeDelete: true)
                .Index(t => t.EtapaId);
            
            CreateTable(
                "dbo.TipoMotivoDecision",
                c => new
                    {
                        TipoMotivoDecisionId = c.Int(nullable: false, identity: true),
                        MotivoDecision = c.String(nullable: false),
                        TipoDecisionId = c.Int(nullable: false),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TipoMotivoDecisionId)
                .ForeignKey("dbo.TipoDecision", t => t.TipoDecisionId, cascadeDelete: true)
                .Index(t => t.TipoDecisionId);
            
            AlterColumn("dbo.Candidatura", "NecesidadId", c => c.Int());
            AlterColumn("dbo.Candidatura", "OfertaId", c => c.Int());
            CreateIndex("dbo.Candidatura", "NecesidadId");
            CreateIndex("dbo.Candidatura", "OfertaId");
            AddForeignKey("dbo.Candidatura", "NecesidadId", "dbo.Necesidad", "NecesidadId");
            AddForeignKey("dbo.Candidatura", "OfertaId", "dbo.Oferta", "OfertaId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Candidatura", "OfertaId", "dbo.Oferta");
            DropForeignKey("dbo.Candidatura", "NecesidadId", "dbo.Necesidad");
            DropForeignKey("dbo.TipoMotivoDecision", "TipoDecisionId", "dbo.TipoDecision");
            DropForeignKey("dbo.RelacionVistaEtapa", "EtapaId", "dbo.TipoEtapaCandidatura");
            DropForeignKey("dbo.RelacionEtapa", "TipoDecisionId", "dbo.TipoDecision");
            DropForeignKey("dbo.TipoDecision", "TipoEtapaCandidaturaId", "dbo.TipoEtapaCandidatura");
            DropForeignKey("dbo.RelacionEtapa", "EtapaOrigenId", "dbo.TipoEtapaCandidatura");
            DropForeignKey("dbo.RelacionEtapa", "EtapaFinId", "dbo.TipoEtapaCandidatura");
            DropForeignKey("dbo.RelacionEtapa", "EstadoFinId", "dbo.TipoEstadoCandidatura");
            DropIndex("dbo.TipoMotivoDecision", new[] { "TipoDecisionId" });
            DropIndex("dbo.RelacionVistaEtapa", new[] { "EtapaId" });
            DropIndex("dbo.TipoDecision", new[] { "TipoEtapaCandidaturaId" });
            DropIndex("dbo.RelacionEtapa", new[] { "EstadoFinId" });
            DropIndex("dbo.RelacionEtapa", new[] { "TipoDecisionId" });
            DropIndex("dbo.RelacionEtapa", new[] { "EtapaFinId" });
            DropIndex("dbo.RelacionEtapa", new[] { "EtapaOrigenId" });
            DropIndex("dbo.Candidatura", new[] { "OfertaId" });
            DropIndex("dbo.Candidatura", new[] { "NecesidadId" });
            AlterColumn("dbo.Candidatura", "OfertaId", c => c.Int(nullable: false));
            AlterColumn("dbo.Candidatura", "NecesidadId", c => c.Int(nullable: false));
            DropTable("dbo.TipoMotivoDecision");
            DropTable("dbo.RelacionVistaEtapa");
            DropTable("dbo.TipoDecision");
            DropTable("dbo.RelacionEtapa");
            CreateIndex("dbo.Candidatura", "OfertaId");
            CreateIndex("dbo.Candidatura", "NecesidadId");
            AddForeignKey("dbo.Candidatura", "OfertaId", "dbo.Oferta", "OfertaId", cascadeDelete: true);
            AddForeignKey("dbo.Candidatura", "NecesidadId", "dbo.Necesidad", "NecesidadId", cascadeDelete: true);
        }
    }
}
