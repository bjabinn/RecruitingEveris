namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnValorDefecto_toCorreoPlantillaVariable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CorreoPlantillaVariable", "ValorDefecto", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CorreoPlantillaVariable", "ValorDefecto");
        }
    }
}
