namespace Recruiting.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddEstadoOrigenNullableRelacionEtapa : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RelacionEtapa", "EstadoOrigenId", "dbo.TipoEstadoCandidatura");
            DropIndex("dbo.RelacionEtapa", new[] { "EstadoOrigenId" });
            AddColumn("dbo.RelacionEtapa", "EstadoOrigenId", c => c.Int());
            CreateIndex("dbo.RelacionEtapa", "EstadoOrigenId");
            AddForeignKey("dbo.RelacionEtapa", "EstadoOrigenId", "dbo.TipoEstadoCandidatura", "TipoEstadoCandidaturaId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RelacionEtapa", "EstadoOrigenId", "dbo.TipoEstadoCandidatura");
            DropIndex("dbo.RelacionEtapa", new[] { "EstadoOrigenId" });
            AddColumn("dbo.RelacionEtapa", "EstadoOrigenId", c => c.Int(nullable: false));
            CreateIndex("dbo.RelacionEtapa", "EstadoOrigenId");
            AddForeignKey("dbo.RelacionEtapa", "EstadoOrigenId", "dbo.TipoEstadoCandidatura", "TipoEstadoCandidaturaId", cascadeDelete: true);
        }
    }
}
