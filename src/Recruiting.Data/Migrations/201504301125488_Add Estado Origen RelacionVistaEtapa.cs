namespace Recruiting.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddEstadoOrigenRelacionVistaEtapa : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RelacionVistaEtapa", "EstadoId", "dbo.TipoEstadoCandidatura");
            DropIndex("dbo.RelacionVistaEtapa", new[] { "EstadoId" });
            AlterColumn("dbo.RelacionVistaEtapa", "EstadoId", c => c.Int(nullable: false));
            CreateIndex("dbo.RelacionVistaEtapa", "EstadoId");
            AddForeignKey("dbo.RelacionVistaEtapa", "EstadoId", "dbo.TipoEstadoCandidatura", "TipoEstadoCandidaturaId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RelacionVistaEtapa", "EstadoId", "dbo.TipoEstadoCandidatura");
            DropIndex("dbo.RelacionVistaEtapa", new[] { "EstadoId" });
            AlterColumn("dbo.RelacionVistaEtapa", "EstadoId", c => c.Int());
            CreateIndex("dbo.RelacionVistaEtapa", "EstadoId");
            AddForeignKey("dbo.RelacionVistaEtapa", "EstadoId", "dbo.TipoEstadoCandidatura", "TipoEstadoCandidaturaId");
        }
    }
}
