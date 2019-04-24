namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aniadido_campo_OficinaId_a_CartaOferta : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CartaOferta", "Oficina", c => c.Int());
            CreateIndex("dbo.CartaOferta", "Oficina");
            AddForeignKey("dbo.CartaOferta", "Oficina", "dbo.Oficina", "OficinaId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CartaOferta", "Oficina", "dbo.Oficina");
            DropIndex("dbo.CartaOferta", new[] { "Oficina" });
            DropColumn("dbo.CartaOferta", "Oficina");
        }
    }
}
