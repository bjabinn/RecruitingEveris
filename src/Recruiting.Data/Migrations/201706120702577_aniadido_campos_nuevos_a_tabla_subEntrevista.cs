namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aniadido_campos_nuevos_a_tabla_subEntrevista : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SubEntrevista", "TipoSubEntrevistaId", c => c.Int(nullable: false));
            AddColumn("dbo.SubEntrevista", "SalarioPropuesto", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.SubEntrevista", "SalarioDeseado", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.SubEntrevista", "SalarioActual", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.SubEntrevista", "IncorporacionId", c => c.Int());
            AddColumn("dbo.SubEntrevista", "DisponibilidadViajes", c => c.Boolean(nullable: false, defaultValue: false));
            AddColumn("dbo.SubEntrevista", "CambioResidencia", c => c.Boolean(nullable: false, defaultValue: false));
            AddColumn("dbo.SubEntrevista", "CategoriaId", c => c.Int());
            AddColumn("dbo.SubEntrevista", "Presencial", c => c.Boolean(nullable: false));
            AddColumn("dbo.SubEntrevista", "SuperaEntrevista", c => c.Boolean(nullable: false, defaultValue: false));
            CreateIndex("dbo.SubEntrevista", "TipoSubEntrevistaId");
            CreateIndex("dbo.SubEntrevista", "IncorporacionId");
            CreateIndex("dbo.SubEntrevista", "CategoriaId");
            AddForeignKey("dbo.SubEntrevista", "CategoriaId", "dbo.Maestro", "MaestroId");
            AddForeignKey("dbo.SubEntrevista", "IncorporacionId", "dbo.Maestro", "MaestroId");
            AddForeignKey("dbo.SubEntrevista", "TipoSubEntrevistaId", "dbo.Maestro", "MaestroId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubEntrevista", "TipoSubEntrevistaId", "dbo.Maestro");
            DropForeignKey("dbo.SubEntrevista", "IncorporacionId", "dbo.Maestro");
            DropForeignKey("dbo.SubEntrevista", "CategoriaId", "dbo.Maestro");
            DropIndex("dbo.SubEntrevista", new[] { "CategoriaId" });
            DropIndex("dbo.SubEntrevista", new[] { "IncorporacionId" });
            DropIndex("dbo.SubEntrevista", new[] { "TipoSubEntrevistaId" });
            DropColumn("dbo.SubEntrevista", "SuperaEntrevista");
            DropColumn("dbo.SubEntrevista", "Presencial");
            DropColumn("dbo.SubEntrevista", "CategoriaId");
            DropColumn("dbo.SubEntrevista", "CambioResidencia");
            DropColumn("dbo.SubEntrevista", "DisponibilidadViajes");
            DropColumn("dbo.SubEntrevista", "IncorporacionId");
            DropColumn("dbo.SubEntrevista", "SalarioActual");
            DropColumn("dbo.SubEntrevista", "SalarioDeseado");
            DropColumn("dbo.SubEntrevista", "SalarioPropuesto");
            DropColumn("dbo.SubEntrevista", "TipoSubEntrevistaId");
        }
    }
}
