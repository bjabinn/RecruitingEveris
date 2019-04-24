namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Aniadir_PersonaAsignadaNroEmpleado_a_Necesidad : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Necesidad", "PersonaAsignadaNroEmpleado", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Necesidad", "PersonaAsignadaNroEmpleado");
        }
    }
}
