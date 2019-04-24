namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Aniadir_NotificacionDescarte_a_Candidatura : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Candidatura", "NotificarDescarte", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Candidatura", "NotificarDescarte");
        }
    }
}
