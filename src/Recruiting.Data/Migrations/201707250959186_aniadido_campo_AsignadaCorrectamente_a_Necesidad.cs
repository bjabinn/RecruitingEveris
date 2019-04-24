namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aniadido_campo_AsignadaCorrectamente_a_Necesidad : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Necesidad", "AsignadaCorrectamente", c => c.Boolean(defaultValue: null));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Necesidad", "AsignadaCorrectamente");
        }
    }
}
