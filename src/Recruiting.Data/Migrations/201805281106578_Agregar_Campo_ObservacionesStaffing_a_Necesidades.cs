namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Agregar_Campo_ObservacionesStaffing_a_Necesidades : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Necesidad", "ObservacionesStaffing", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Necesidad", "ObservacionesStaffing");
        }
    }
}
