namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NecesidadIdiomaCRUD : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Candidatura", "NecesidadIdioma", c => c.Boolean(nullable: false));
            AddColumn("dbo.Necesidad", "NecesidadIdioma", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Necesidad", "NecesidadIdioma");
            DropColumn("dbo.Candidatura", "NecesidadIdioma");
        }
    }
}
