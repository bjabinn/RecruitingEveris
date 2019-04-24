namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aniadir_avisarAlCAndidato_a_entrevistas : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Entrevista", "AvisarAlCandidato", c => c.Boolean(nullable: false, defaultValue: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Entrevista", "AvisarAlCandidato");
        }
    }
}
