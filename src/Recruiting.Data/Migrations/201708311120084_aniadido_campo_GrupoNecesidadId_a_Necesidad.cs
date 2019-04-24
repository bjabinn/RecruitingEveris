namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aniadido_campo_GrupoNecesidadId_a_Necesidad : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Necesidad", "GrupoNecesidadId", c => c.Int());
            CreateIndex("dbo.Necesidad", "GrupoNecesidadId");
            AddForeignKey("dbo.Necesidad", "GrupoNecesidadId", "dbo.GrupoNecesidad", "GrupoNecesidadId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Necesidad", "GrupoNecesidadId", "dbo.GrupoNecesidad");
            DropIndex("dbo.Necesidad", new[] { "GrupoNecesidadId" });
            DropColumn("dbo.Necesidad", "GrupoNecesidadId");
        }
    }
}
