namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Tabla_CorreoBecario : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CorreoBecario",
                c => new
                    {
                        CorreoBecarioId = c.Int(nullable: false, identity: true),
                        PlantillaId = c.Int(nullable: false),
                        BecarioId = c.Int(),
                        Asunto = c.String(),
                        Destinatarios = c.String(),
                        Remitente = c.String(),
                        Enviado = c.Boolean(nullable: false),
                        FechaEnvio = c.DateTime(),
                        TipoAviso = c.String(),
                        UsuarioCreacionId = c.Int(nullable: false),
                        UsuarioModificacionId = c.Int(),
                        FechaCreacion = c.DateTime(nullable: false),
                        FechaModificacion = c.DateTime(),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CorreoBecarioId)
                .ForeignKey("dbo.Becario", t => t.BecarioId)
                .ForeignKey("dbo.CorreoPlantilla", t => t.PlantillaId)
                .ForeignKey("dbo.Usuario", t => t.UsuarioCreacionId, cascadeDelete: true)
                .ForeignKey("dbo.Usuario", t => t.UsuarioModificacionId)
                .Index(t => t.PlantillaId)
                .Index(t => t.BecarioId)
                .Index(t => t.UsuarioCreacionId)
                .Index(t => t.UsuarioModificacionId);
            
            AddColumn("dbo.CorreoAdjunto", "CorreoBecario_CorreoBecarioId", c => c.Int());
            AddColumn("dbo.CorreoPlantillaVariableValor", "CorreoBecario_CorreoBecarioId", c => c.Int());
            CreateIndex("dbo.CorreoAdjunto", "CorreoBecario_CorreoBecarioId");
            CreateIndex("dbo.CorreoPlantillaVariableValor", "CorreoBecario_CorreoBecarioId");
            AddForeignKey("dbo.CorreoAdjunto", "CorreoBecario_CorreoBecarioId", "dbo.CorreoBecario", "CorreoBecarioId");
            AddForeignKey("dbo.CorreoPlantillaVariableValor", "CorreoBecario_CorreoBecarioId", "dbo.CorreoBecario", "CorreoBecarioId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CorreoBecario", "UsuarioModificacionId", "dbo.Usuario");
            DropForeignKey("dbo.CorreoBecario", "UsuarioCreacionId", "dbo.Usuario");
            DropForeignKey("dbo.CorreoPlantillaVariableValor", "CorreoBecario_CorreoBecarioId", "dbo.CorreoBecario");
            DropForeignKey("dbo.CorreoBecario", "PlantillaId", "dbo.CorreoPlantilla");
            DropForeignKey("dbo.CorreoAdjunto", "CorreoBecario_CorreoBecarioId", "dbo.CorreoBecario");
            DropForeignKey("dbo.CorreoBecario", "BecarioId", "dbo.Becario");
            DropIndex("dbo.CorreoBecario", new[] { "UsuarioModificacionId" });
            DropIndex("dbo.CorreoBecario", new[] { "UsuarioCreacionId" });
            DropIndex("dbo.CorreoBecario", new[] { "BecarioId" });
            DropIndex("dbo.CorreoBecario", new[] { "PlantillaId" });
            DropIndex("dbo.CorreoPlantillaVariableValor", new[] { "CorreoBecario_CorreoBecarioId" });
            DropIndex("dbo.CorreoAdjunto", new[] { "CorreoBecario_CorreoBecarioId" });
            DropColumn("dbo.CorreoPlantillaVariableValor", "CorreoBecario_CorreoBecarioId");
            DropColumn("dbo.CorreoAdjunto", "CorreoBecario_CorreoBecarioId");
            DropTable("dbo.CorreoBecario");
        }
    }
}
