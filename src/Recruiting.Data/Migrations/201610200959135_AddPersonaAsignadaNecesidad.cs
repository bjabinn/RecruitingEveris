namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPersonaAsignadaNecesidad : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Necesidad", "PersonaAsignada", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Necesidad", "PersonaAsignada");
        }
    }
}
