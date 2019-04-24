namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Aniadir_Tabla_TipoEstadoBecario : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TipoEstadoBecario",
                c => new
                    {
                        TipoEstadoBecarioId = c.Int(nullable: false, identity: true),
                        EstadoBecario = c.String(),
                        Orden = c.Int(),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TipoEstadoBecarioId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TipoEstadoBecario");
        }
    }
}
