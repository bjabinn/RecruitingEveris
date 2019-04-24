namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class claveajenademotivorenunciaconmaestro : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Candidatura", "MotivoRenunciaId");
            AddForeignKey("dbo.Candidatura", "MotivoRenunciaId", "dbo.Maestro", "MaestroId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Candidatura", "MotivoRenunciaId", "dbo.Maestro");
            DropIndex("dbo.Candidatura", new[] { "MotivoRenunciaId" });
        }
    }
}
