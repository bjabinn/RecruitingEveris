namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aniadido_campo_OficinaId_a_Entrevista : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Entrevista", "Oficina", c => c.Int());
            CreateIndex("dbo.Entrevista", "Oficina");
            AddForeignKey("dbo.Entrevista", "Oficina", "dbo.Oficina", "OficinaId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Entrevista", "Oficina", "dbo.Oficina");
            DropIndex("dbo.Entrevista", new[] { "Oficina" });
            DropColumn("dbo.Entrevista", "Oficina");
        }
    }
}
