namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Modificacion_FK_PersonaLibre : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PersonaLibre", "NecesidadId", "dbo.Maestro");
            AddForeignKey("dbo.PersonaLibre", "NecesidadId", "dbo.Necesidad", "NecesidadId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PersonaLibre", "NecesidadId", "dbo.Necesidad");
            AddForeignKey("dbo.PersonaLibre", "NecesidadId", "dbo.Maestro", "NecesidadId");
        }
    }
}
