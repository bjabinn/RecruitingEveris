namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCamposProyecto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Proyecto", "Persona", c => c.String());
            AddColumn("dbo.Proyecto", "CuentaCargo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Proyecto", "CuentaCargo");
            DropColumn("dbo.Proyecto", "Persona");
        }
    }
}
