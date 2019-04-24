namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class eliminar_entrevista_completada : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Entrevista", "Completada");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Entrevista", "Completada", c => c.Boolean(nullable: false));
        }
    }
}
