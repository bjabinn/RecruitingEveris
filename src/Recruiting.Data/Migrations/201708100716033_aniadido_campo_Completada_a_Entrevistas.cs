namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aniadido_campo_Completada_a_Entrevistas : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Entrevista", "Completada", c => c.Boolean(nullable: false, defaultValue: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Entrevista", "Completada");
        }
    }
}
