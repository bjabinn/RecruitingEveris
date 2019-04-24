namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Campo_NotificacionDescarte_Becario : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Becario", "NotificarDescarte", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Becario", "NotificarDescarte");
        }
    }
}
