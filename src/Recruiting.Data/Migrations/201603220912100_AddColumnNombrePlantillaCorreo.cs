namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnNombrePlantillaCorreo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CorreoPlantilla", "NombrePlantilla", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CorreoPlantilla", "NombrePlantilla");
        }
    }
}
