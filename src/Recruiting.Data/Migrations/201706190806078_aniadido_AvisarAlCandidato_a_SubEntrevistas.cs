namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aniadido_AvisarAlCandidato_a_SubEntrevistas : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SubEntrevista", "AvisarAlCandidato", c => c.Boolean(nullable: false, defaultValue: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SubEntrevista", "AvisarAlCandidato");
        }
    }
}
