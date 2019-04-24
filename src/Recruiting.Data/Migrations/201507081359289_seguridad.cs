namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seguridad : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UsuarioRol",
                c => new
                    {
                        UsuarioId = c.Int(nullable: false),
                        RolId = c.Int(nullable: false),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.UsuarioId, t.RolId })
                .ForeignKey("dbo.Rol", t => t.RolId, cascadeDelete: true)
                .ForeignKey("dbo.Usuario", t => t.UsuarioId, cascadeDelete: true)
                .Index(t => t.UsuarioId)
                .Index(t => t.RolId);
            
            CreateTable(
                "dbo.Rol",
                c => new
                    {
                        RolId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 100),
                        Descripcion = c.String(maxLength: 500),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.RolId);
            
            CreateTable(
                "dbo.PermisoRol",
                c => new
                    {
                        PermisoId = c.Int(nullable: false),
                        RolId = c.Int(nullable: false),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.PermisoId, t.RolId })
                .ForeignKey("dbo.Permiso", t => t.PermisoId, cascadeDelete: true)
                .ForeignKey("dbo.Rol", t => t.RolId, cascadeDelete: true)
                .Index(t => t.PermisoId)
                .Index(t => t.RolId);
            
            CreateTable(
                "dbo.Permiso",
                c => new
                    {
                        PermisoId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 100),
                        Descripcion = c.String(maxLength: 500),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PermisoId);
            
            AddColumn("dbo.Usuario", "Email", c => c.String(maxLength: 100));
            AddColumn("dbo.Usuario", "Aplicacion", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UsuarioRol", "UsuarioId", "dbo.Usuario");
            DropForeignKey("dbo.UsuarioRol", "RolId", "dbo.Rol");
            DropForeignKey("dbo.PermisoRol", "RolId", "dbo.Rol");
            DropForeignKey("dbo.PermisoRol", "PermisoId", "dbo.Permiso");
            DropIndex("dbo.PermisoRol", new[] { "RolId" });
            DropIndex("dbo.PermisoRol", new[] { "PermisoId" });
            DropIndex("dbo.UsuarioRol", new[] { "RolId" });
            DropIndex("dbo.UsuarioRol", new[] { "UsuarioId" });
            DropColumn("dbo.Usuario", "Aplicacion");
            DropColumn("dbo.Usuario", "Email");
            DropTable("dbo.Permiso");
            DropTable("dbo.PermisoRol");
            DropTable("dbo.Rol");
            DropTable("dbo.UsuarioRol");
        }
    }
}
