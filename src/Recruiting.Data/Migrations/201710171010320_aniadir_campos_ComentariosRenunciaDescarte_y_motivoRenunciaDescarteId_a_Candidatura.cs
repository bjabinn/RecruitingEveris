namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aniadir_campos_ComentariosRenunciaDescarte_y_motivoRenunciaDescarteId_a_Candidatura : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Candidatura", "MotivoRenunciaDescarteId", c => c.Int());
            AddColumn("dbo.Candidatura", "ComentariosRenunciaDescarte", c => c.String());
            CreateIndex("dbo.Candidatura", "MotivoRenunciaDescarteId");
            AddForeignKey("dbo.Candidatura", "MotivoRenunciaDescarteId", "dbo.Maestro", "MaestroId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Candidatura", "MotivoRenunciaDescarteId", "dbo.Maestro");
            DropIndex("dbo.Candidatura", new[] { "MotivoRenunciaDescarteId" });
            DropColumn("dbo.Candidatura", "ComentariosRenunciaDescarte");
            DropColumn("dbo.Candidatura", "MotivoRenunciaDescarteId");
        }
    }
}
