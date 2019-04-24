namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Incluir_Persona_Cuenta_Proyecto_en_Necesidad : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Necesidad", "PersonaProyecto", c => c.String());
            AddColumn("dbo.Necesidad", "CuentaProyecto", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Necesidad", "CuentaProyecto");
            DropColumn("dbo.Necesidad", "PersonaProyecto");
        }
    }
}
