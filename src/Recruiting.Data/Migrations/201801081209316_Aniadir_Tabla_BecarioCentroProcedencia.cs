namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Aniadir_Tabla_BecarioCentroProcedencia : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BecarioCentroProcedencia",
                c => new
                    {
                        BecarioCentroProcedenciaId = c.Int(nullable: false, identity: true),
                        Centro = c.String(),
                        Ciudad = c.String(),
                        Pais = c.String(),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.BecarioCentroProcedenciaId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BecarioCentroProcedencia");
        }
    }
}
