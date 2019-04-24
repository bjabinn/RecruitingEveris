namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Aniadir_ComentariosRenunciaDescarte_a_Becario : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Becario", "ComentariosRenunciaDescarte", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Becario", "ComentariosRenunciaDescarte");
        }
    }
}
