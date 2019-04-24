namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aniadido_campo_TipoAviso_a_Correo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Correo", "TipoAviso", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Correo", "TipoAviso");
        }
    }
}
