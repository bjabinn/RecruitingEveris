namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_modifiableEntity_data_to_GrupoNecesidad : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GrupoNecesidad", "UsuarioCreacionId", c => c.Int(nullable: false));
            AddColumn("dbo.GrupoNecesidad", "UsuarioModificacionId", c => c.Int());
            AddColumn("dbo.GrupoNecesidad", "FechaCreacion", c => c.DateTime(nullable: false));
            AddColumn("dbo.GrupoNecesidad", "FechaModificacion", c => c.DateTime());
            CreateIndex("dbo.GrupoNecesidad", "UsuarioCreacionId");
            CreateIndex("dbo.GrupoNecesidad", "UsuarioModificacionId");
            AddForeignKey("dbo.GrupoNecesidad", "UsuarioCreacionId", "dbo.Usuario", "UsuarioId", cascadeDelete: true);
            AddForeignKey("dbo.GrupoNecesidad", "UsuarioModificacionId", "dbo.Usuario", "UsuarioId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GrupoNecesidad", "UsuarioModificacionId", "dbo.Usuario");
            DropForeignKey("dbo.GrupoNecesidad", "UsuarioCreacionId", "dbo.Usuario");
            DropIndex("dbo.GrupoNecesidad", new[] { "UsuarioModificacionId" });
            DropIndex("dbo.GrupoNecesidad", new[] { "UsuarioCreacionId" });
            DropColumn("dbo.GrupoNecesidad", "FechaModificacion");
            DropColumn("dbo.GrupoNecesidad", "FechaCreacion");
            DropColumn("dbo.GrupoNecesidad", "UsuarioModificacionId");
            DropColumn("dbo.GrupoNecesidad", "UsuarioCreacionId");
        }
    }
}
