namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Eliminado_Ciudad_Pais_de_Convocatoria_Aniadido_CentroId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BecarioConvocatoria", "CentroId", c => c.Int());
            CreateIndex("dbo.BecarioConvocatoria", "CentroId");
            AddForeignKey("dbo.BecarioConvocatoria", "CentroId", "dbo.Centro", "CentroId");
            DropColumn("dbo.BecarioConvocatoria", "Ciudad");
            DropColumn("dbo.BecarioConvocatoria", "Pais");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BecarioConvocatoria", "Pais", c => c.String());
            AddColumn("dbo.BecarioConvocatoria", "Ciudad", c => c.String());
            DropForeignKey("dbo.BecarioConvocatoria", "CentroId", "dbo.Centro");
            DropIndex("dbo.BecarioConvocatoria", new[] { "CentroId" });
            DropColumn("dbo.BecarioConvocatoria", "CentroId");
        }
    }
}
