namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Cambio_Tabla_Aniosexp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Candidatura", "AniosExperiencia", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Candidatura", "AniosExperiencia");
        }
    }
}
