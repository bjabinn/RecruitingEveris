namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserNametoUsuario : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuario", "Username", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Usuario", "Username");
        }
    }
}
