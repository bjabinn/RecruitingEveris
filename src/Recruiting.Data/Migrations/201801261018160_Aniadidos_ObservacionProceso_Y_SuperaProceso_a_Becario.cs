namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Aniadidos_ObservacionProceso_Y_SuperaProceso_a_Becario : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Becario", "ObservacionFinalProceso", c => c.String());
            AddColumn("dbo.Becario", "SuperaProceso", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Becario", "SuperaProceso");
            DropColumn("dbo.Becario", "ObservacionFinalProceso");
        }
    }
}
