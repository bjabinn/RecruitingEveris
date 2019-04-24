namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Aniadir_Campos_SinNecesidadAsignada_A_PersonaLibre_Y_PersonaAsignadaId_A_Necesidades : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Necesidad", "PersonaAsignadaId", c => c.Int());
            AddColumn("dbo.PersonaLibre", "SinNecesidadAsignada", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PersonaLibre", "SinNecesidadAsignada");
            DropColumn("dbo.Necesidad", "PersonaAsignadaId");
        }
    }
}
