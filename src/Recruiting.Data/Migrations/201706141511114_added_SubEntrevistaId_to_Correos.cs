namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_SubEntrevistaId_to_Correos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Correo", "SubEntrevistaId", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Correo", "SubEntrevistaId");
        }
    }
}
