namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Cambio_en_personaLibre_NecesidadId_Nullable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PersonaLibre", "NecesidadId", "dbo.Necesidad");
            DropIndex("dbo.PersonaLibre", new[] { "NecesidadId" });
            AlterColumn("dbo.PersonaLibre", "NecesidadId", c => c.Int());
            CreateIndex("dbo.PersonaLibre", "NecesidadId");
            AddForeignKey("dbo.PersonaLibre", "NecesidadId", "dbo.Necesidad", "NecesidadId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PersonaLibre", "NecesidadId", "dbo.Necesidad");
            DropIndex("dbo.PersonaLibre", new[] { "NecesidadId" });
            AlterColumn("dbo.PersonaLibre", "NecesidadId", c => c.Int(nullable: false));
            CreateIndex("dbo.PersonaLibre", "NecesidadId");
            AddForeignKey("dbo.PersonaLibre", "NecesidadId", "dbo.Necesidad", "NecesidadId", cascadeDelete: true);
        }
    }
}
