namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModificacionBitacora : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bitacora", "TipoBitacora", c => c.Int());
            AddColumn("dbo.Bitacora", "EstadoAnteriorId", c => c.Int());
            AddColumn("dbo.Bitacora", "EstadoNuevoId", c => c.Int());
            AddColumn("dbo.Bitacora", "EtapaAnteriorId", c => c.Int());
            AddColumn("dbo.Bitacora", "EtapaNuevaId", c => c.Int());
            CreateIndex("dbo.Bitacora", "EstadoAnteriorId");
            CreateIndex("dbo.Bitacora", "EstadoNuevoId");
            CreateIndex("dbo.Bitacora", "EtapaAnteriorId");
            CreateIndex("dbo.Bitacora", "EtapaNuevaId");
            AddForeignKey("dbo.Bitacora", "EstadoAnteriorId", "dbo.TipoEstadoCandidatura", "TipoEstadoCandidaturaId");
            AddForeignKey("dbo.Bitacora", "EstadoNuevoId", "dbo.TipoEstadoCandidatura", "TipoEstadoCandidaturaId");
            AddForeignKey("dbo.Bitacora", "EtapaAnteriorId", "dbo.TipoEtapaCandidatura", "TipoEtapaCandidaturaId");
            AddForeignKey("dbo.Bitacora", "EtapaNuevaId", "dbo.TipoEtapaCandidatura", "TipoEtapaCandidaturaId");
            DropColumn("dbo.Bitacora", "TipoCambio");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Bitacora", "TipoCambio", c => c.String());
            DropForeignKey("dbo.Bitacora", "EtapaNuevaId", "dbo.TipoEtapaCandidatura");
            DropForeignKey("dbo.Bitacora", "EtapaAnteriorId", "dbo.TipoEtapaCandidatura");
            DropForeignKey("dbo.Bitacora", "EstadoNuevoId", "dbo.TipoEstadoCandidatura");
            DropForeignKey("dbo.Bitacora", "EstadoAnteriorId", "dbo.TipoEstadoCandidatura");
            DropIndex("dbo.Bitacora", new[] { "EtapaNuevaId" });
            DropIndex("dbo.Bitacora", new[] { "EtapaAnteriorId" });
            DropIndex("dbo.Bitacora", new[] { "EstadoNuevoId" });
            DropIndex("dbo.Bitacora", new[] { "EstadoAnteriorId" });
            DropColumn("dbo.Bitacora", "EtapaNuevaId");
            DropColumn("dbo.Bitacora", "EtapaAnteriorId");
            DropColumn("dbo.Bitacora", "EstadoNuevoId");
            DropColumn("dbo.Bitacora", "EstadoAnteriorId");
            DropColumn("dbo.Bitacora", "TipoBitacora");
        }
    }
}
