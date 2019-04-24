namespace Recruiting.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class ReviewCamposObligatorios : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RelacionEtapa", "EstadoFinId", "dbo.TipoEstadoCandidatura");
            DropForeignKey("dbo.RelacionEtapa", "EtapaFinId", "dbo.TipoEtapaCandidatura");
            DropForeignKey("dbo.RelacionEtapa", "TipoDecisionId", "dbo.TipoDecision");
            DropIndex("dbo.RelacionEtapa", new[] { "EtapaFinId" });
            DropIndex("dbo.RelacionEtapa", new[] { "TipoDecisionId" });
            DropIndex("dbo.RelacionEtapa", new[] { "EstadoFinId" });
            AlterColumn("dbo.CartaOferta", "Acepta", c => c.Boolean());
            AlterColumn("dbo.Oferta", "FechaPublicacion", c => c.DateTime());
            AlterColumn("dbo.RelacionEtapa", "EtapaFinId", c => c.Int());
            AlterColumn("dbo.RelacionEtapa", "TipoDecisionId", c => c.Int());
            AlterColumn("dbo.RelacionEtapa", "EstadoFinId", c => c.Int());
            CreateIndex("dbo.RelacionEtapa", "EtapaFinId");
            CreateIndex("dbo.RelacionEtapa", "TipoDecisionId");
            CreateIndex("dbo.RelacionEtapa", "EstadoFinId");
            AddForeignKey("dbo.RelacionEtapa", "EstadoFinId", "dbo.TipoEstadoCandidatura", "TipoEstadoCandidaturaId");
            AddForeignKey("dbo.RelacionEtapa", "EtapaFinId", "dbo.TipoEtapaCandidatura", "TipoEtapaCandidaturaId");
            AddForeignKey("dbo.RelacionEtapa", "TipoDecisionId", "dbo.TipoDecision", "TipoDecisionId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RelacionEtapa", "TipoDecisionId", "dbo.TipoDecision");
            DropForeignKey("dbo.RelacionEtapa", "EtapaFinId", "dbo.TipoEtapaCandidatura");
            DropForeignKey("dbo.RelacionEtapa", "EstadoFinId", "dbo.TipoEstadoCandidatura");
            DropIndex("dbo.RelacionEtapa", new[] { "EstadoFinId" });
            DropIndex("dbo.RelacionEtapa", new[] { "TipoDecisionId" });
            DropIndex("dbo.RelacionEtapa", new[] { "EtapaFinId" });
            AlterColumn("dbo.RelacionEtapa", "EstadoFinId", c => c.Int(nullable: false));
            AlterColumn("dbo.RelacionEtapa", "TipoDecisionId", c => c.Int(nullable: false));
            AlterColumn("dbo.RelacionEtapa", "EtapaFinId", c => c.Int(nullable: false));
            AlterColumn("dbo.Oferta", "FechaPublicacion", c => c.DateTime(nullable: false));
            AlterColumn("dbo.CartaOferta", "Acepta", c => c.Boolean(nullable: false));
            CreateIndex("dbo.RelacionEtapa", "EstadoFinId");
            CreateIndex("dbo.RelacionEtapa", "TipoDecisionId");
            CreateIndex("dbo.RelacionEtapa", "EtapaFinId");
            AddForeignKey("dbo.RelacionEtapa", "TipoDecisionId", "dbo.TipoDecision", "TipoDecisionId", cascadeDelete: true);
            AddForeignKey("dbo.RelacionEtapa", "EtapaFinId", "dbo.TipoEtapaCandidatura", "TipoEtapaCandidaturaId", cascadeDelete: true);
            AddForeignKey("dbo.RelacionEtapa", "EstadoFinId", "dbo.TipoEstadoCandidatura", "TipoEstadoCandidaturaId", cascadeDelete: true);
        }
    }
}
