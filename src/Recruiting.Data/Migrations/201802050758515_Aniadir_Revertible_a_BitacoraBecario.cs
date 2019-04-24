namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Aniadir_Revertible_a_BitacoraBecario : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BitacoraBecario", "Revertible", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.BitacoraBecario", "Revertible");
        }
    }
}
