namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Aniadir_FiltradorId_y_ForeingKey_en_Candidaturas : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Candidatura", "FiltradorId", c => c.Int());
            CreateIndex("dbo.Candidatura", "FiltradorId");
            AddForeignKey("dbo.Candidatura", "FiltradorId", "dbo.Usuario", "UsuarioId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Candidatura", "FiltradorId", "dbo.Usuario");
            DropIndex("dbo.Candidatura", new[] { "FiltradorId" });
            DropColumn("dbo.Candidatura", "FiltradorId");
        }
    }
}
