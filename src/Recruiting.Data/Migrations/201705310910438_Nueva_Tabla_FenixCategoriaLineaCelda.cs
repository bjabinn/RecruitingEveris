namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Nueva_Tabla_FenixCategoriaLineaCelda : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FenixCategoriaLineaCelda",
                c => new
                    {
                        FenixCategoriaLineaCeldaId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 500),
                        Tipo = c.String(nullable: false, maxLength: 10),
                        UsuarioCreacionId = c.Int(nullable: false),
                        UsuarioModificacionId = c.Int(),
                        FechaCreacion = c.DateTime(nullable: false),
                        FechaModificacion = c.DateTime(),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.FenixCategoriaLineaCeldaId)
                .ForeignKey("dbo.Usuario", t => t.UsuarioCreacionId, cascadeDelete: true)
                .ForeignKey("dbo.Usuario", t => t.UsuarioModificacionId)
                .Index(t => t.UsuarioCreacionId)
                .Index(t => t.UsuarioModificacionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FenixCategoriaLineaCelda", "UsuarioModificacionId", "dbo.Usuario");
            DropForeignKey("dbo.FenixCategoriaLineaCelda", "UsuarioCreacionId", "dbo.Usuario");
            DropIndex("dbo.FenixCategoriaLineaCelda", new[] { "UsuarioModificacionId" });
            DropIndex("dbo.FenixCategoriaLineaCelda", new[] { "UsuarioCreacionId" });
            DropTable("dbo.FenixCategoriaLineaCelda");
        }
    }
}
