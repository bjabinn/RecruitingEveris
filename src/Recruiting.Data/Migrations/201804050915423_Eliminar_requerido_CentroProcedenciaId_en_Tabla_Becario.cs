namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Eliminar_requerido_CentroProcedenciaId_en_Tabla_Becario : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Becario", "BecarioCentroProcedenciaId", "dbo.BecarioCentroProcedencia");
            DropIndex("dbo.Becario", new[] { "BecarioCentroProcedenciaId" });
            AlterColumn("dbo.Becario", "BecarioCentroProcedenciaId", c => c.Int());
            CreateIndex("dbo.Becario", "BecarioCentroProcedenciaId");
            AddForeignKey("dbo.Becario", "BecarioCentroProcedenciaId", "dbo.BecarioCentroProcedencia", "BecarioCentroProcedenciaId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Becario", "BecarioCentroProcedenciaId", "dbo.BecarioCentroProcedencia");
            DropIndex("dbo.Becario", new[] { "BecarioCentroProcedenciaId" });
            AlterColumn("dbo.Becario", "BecarioCentroProcedenciaId", c => c.Int(nullable: false));
            CreateIndex("dbo.Becario", "BecarioCentroProcedenciaId");
            AddForeignKey("dbo.Becario", "BecarioCentroProcedenciaId", "dbo.BecarioCentroProcedencia", "BecarioCentroProcedenciaId", cascadeDelete: true);
        }
    }
}
