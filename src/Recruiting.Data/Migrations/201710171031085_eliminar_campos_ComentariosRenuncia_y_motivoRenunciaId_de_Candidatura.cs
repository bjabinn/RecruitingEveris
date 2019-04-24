namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class eliminar_campos_ComentariosRenuncia_y_motivoRenunciaId_de_Candidatura : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Candidatura", "MotivoRenunciaId", "dbo.Maestro");
            DropIndex("dbo.Candidatura", new[] { "MotivoRenunciaId" });
            DropColumn("dbo.Candidatura", "MotivoRenunciaId");
            DropColumn("dbo.Candidatura", "ComentariosRenuncia");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Candidatura", "ComentariosRenuncia", c => c.String());
            AddColumn("dbo.Candidatura", "MotivoRenunciaId", c => c.Int());
            CreateIndex("dbo.Candidatura", "MotivoRenunciaId");
            AddForeignKey("dbo.Candidatura", "MotivoRenunciaId", "dbo.Maestro", "MaestroId");
        }
    }
}
