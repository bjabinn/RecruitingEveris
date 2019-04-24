namespace Recruiting.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddEstadoOrigenNullableRelacionVistEtapa : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RelacionVistaEtapa", "EstadoId", c => c.Int());
            CreateIndex("dbo.RelacionVistaEtapa", "EstadoId");
            AddForeignKey("dbo.RelacionVistaEtapa", "EstadoId", "dbo.TipoEstadoCandidatura", "TipoEstadoCandidaturaId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RelacionVistaEtapa", "EstadoId", "dbo.TipoEstadoCandidatura");
            DropIndex("dbo.RelacionVistaEtapa", new[] { "EstadoId" });
            DropColumn("dbo.RelacionVistaEtapa", "EstadoId");
        }
    }
}
