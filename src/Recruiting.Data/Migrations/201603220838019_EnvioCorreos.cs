namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EnvioCorreos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Correo",
                c => new
                    {
                        CorreoId = c.Int(nullable: false, identity: true),
                        PlantillaId = c.Int(nullable: false),
                        CandidaturaId = c.Int(),
                        Asunto = c.String(),
                        Destinatarios = c.String(),
                        Remitente = c.String(),
                        Enviado = c.Boolean(nullable: false),
                        FechaEnvio = c.DateTime(),
                        UsuarioCreacionId = c.Int(nullable: false),
                        UsuarioModificacionId = c.Int(),
                        FechaCreacion = c.DateTime(nullable: false),
                        FechaModificacion = c.DateTime(),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CorreoId)
                .ForeignKey("dbo.Candidatura", t => t.CandidaturaId)
                .ForeignKey("dbo.CorreoPlantilla", t => t.PlantillaId, cascadeDelete:false)
                .ForeignKey("dbo.Usuario", t => t.UsuarioCreacionId, cascadeDelete: false)
                .ForeignKey("dbo.Usuario", t => t.UsuarioModificacionId)
                .Index(t => t.PlantillaId)
                .Index(t => t.CandidaturaId)
                .Index(t => t.UsuarioCreacionId)
                .Index(t => t.UsuarioModificacionId);
            
            CreateTable(
                "dbo.CorreoAdjunto",
                c => new
                    {
                        FicheroAdjuntoId = c.Int(nullable: false, identity: true),
                        CorreoId = c.Int(nullable: false),
                        FicheroAdjunto = c.Binary(),
                        NombreFicheroAdjunto = c.String(),
                        UsuarioCreacionId = c.Int(nullable: false),
                        UsuarioModificacionId = c.Int(),
                        FechaCreacion = c.DateTime(nullable: false),
                        FechaModificacion = c.DateTime(),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.FicheroAdjuntoId)
                .ForeignKey("dbo.Correo", t => t.CorreoId, cascadeDelete: false)
                .ForeignKey("dbo.Usuario", t => t.UsuarioCreacionId, cascadeDelete: false)
                .ForeignKey("dbo.Usuario", t => t.UsuarioModificacionId)
                .Index(t => t.CorreoId)
                .Index(t => t.UsuarioCreacionId)
                .Index(t => t.UsuarioModificacionId);
            
            CreateTable(
                "dbo.CorreoPlantilla",
                c => new
                    {
                        PlantillaId = c.Int(nullable: false, identity: true),
                        TextoPlantilla = c.String(),
                        UsuarioCreacionId = c.Int(nullable: false),
                        UsuarioModificacionId = c.Int(),
                        FechaCreacion = c.DateTime(nullable: false),
                        FechaModificacion = c.DateTime(),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PlantillaId)
                .ForeignKey("dbo.Usuario", t => t.UsuarioCreacionId, cascadeDelete: false)
                .ForeignKey("dbo.Usuario", t => t.UsuarioModificacionId)
                .Index(t => t.UsuarioCreacionId)
                .Index(t => t.UsuarioModificacionId);
            
            CreateTable(
                "dbo.CorreoPlantillaVariable",
                c => new
                    {
                        VariableId = c.Int(nullable: false, identity: true),
                        PlantillaId = c.Int(nullable: false),
                        NombreVariable = c.String(),
                        UsuarioCreacionId = c.Int(nullable: false),
                        UsuarioModificacionId = c.Int(),
                        FechaCreacion = c.DateTime(nullable: false),
                        FechaModificacion = c.DateTime(),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.VariableId)
                .ForeignKey("dbo.CorreoPlantilla", t => t.PlantillaId, cascadeDelete: true)
                .ForeignKey("dbo.Usuario", t => t.UsuarioCreacionId, cascadeDelete: false)
                .ForeignKey("dbo.Usuario", t => t.UsuarioModificacionId)
                .Index(t => t.PlantillaId)
                .Index(t => t.UsuarioCreacionId)
                .Index(t => t.UsuarioModificacionId);
            
            CreateTable(
                "dbo.CorreoPlantillaVariableValor",
                c => new
                    {
                        ValorVariableId = c.Int(nullable: false, identity: true),
                        CorreoId = c.Int(nullable: false),
                        PlantillaId = c.Int(nullable: false),
                        VariableId = c.Int(nullable: false),
                        ValorVariable = c.String(nullable: false),
                        UsuarioCreacionId = c.Int(nullable: false),
                        UsuarioModificacionId = c.Int(),
                        FechaCreacion = c.DateTime(nullable: false),
                        FechaModificacion = c.DateTime(),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ValorVariableId)
                .ForeignKey("dbo.Correo", t => t.CorreoId, cascadeDelete: false)
                .ForeignKey("dbo.CorreoPlantilla", t => t.PlantillaId, cascadeDelete: false)
                .ForeignKey("dbo.CorreoPlantillaVariable", t => t.VariableId, cascadeDelete: false)
                .ForeignKey("dbo.Usuario", t => t.UsuarioCreacionId, cascadeDelete: false)
                .ForeignKey("dbo.Usuario", t => t.UsuarioModificacionId)
                .Index(t => t.CorreoId)
                .Index(t => t.PlantillaId)
                .Index(t => t.VariableId)
                .Index(t => t.UsuarioCreacionId)
                .Index(t => t.UsuarioModificacionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Correo", "UsuarioModificacionId", "dbo.Usuario");
            DropForeignKey("dbo.Correo", "UsuarioCreacionId", "dbo.Usuario");
            DropForeignKey("dbo.Correo", "PlantillaId", "dbo.CorreoPlantilla");
            DropForeignKey("dbo.CorreoPlantilla", "UsuarioModificacionId", "dbo.Usuario");
            DropForeignKey("dbo.CorreoPlantilla", "UsuarioCreacionId", "dbo.Usuario");
            DropForeignKey("dbo.CorreoPlantillaVariable", "UsuarioModificacionId", "dbo.Usuario");
            DropForeignKey("dbo.CorreoPlantillaVariable", "UsuarioCreacionId", "dbo.Usuario");
            DropForeignKey("dbo.CorreoPlantillaVariable", "PlantillaId", "dbo.CorreoPlantilla");
            DropForeignKey("dbo.CorreoPlantillaVariableValor", "UsuarioModificacionId", "dbo.Usuario");
            DropForeignKey("dbo.CorreoPlantillaVariableValor", "UsuarioCreacionId", "dbo.Usuario");
            DropForeignKey("dbo.CorreoPlantillaVariableValor", "VariableId", "dbo.CorreoPlantillaVariable");
            DropForeignKey("dbo.CorreoPlantillaVariableValor", "PlantillaId", "dbo.CorreoPlantilla");
            DropForeignKey("dbo.CorreoPlantillaVariableValor", "CorreoId", "dbo.Correo");
            DropForeignKey("dbo.CorreoAdjunto", "UsuarioModificacionId", "dbo.Usuario");
            DropForeignKey("dbo.CorreoAdjunto", "UsuarioCreacionId", "dbo.Usuario");
            DropForeignKey("dbo.CorreoAdjunto", "CorreoId", "dbo.Correo");
            DropForeignKey("dbo.Correo", "CandidaturaId", "dbo.Candidatura");
            DropIndex("dbo.CorreoPlantillaVariableValor", new[] { "UsuarioModificacionId" });
            DropIndex("dbo.CorreoPlantillaVariableValor", new[] { "UsuarioCreacionId" });
            DropIndex("dbo.CorreoPlantillaVariableValor", new[] { "VariableId" });
            DropIndex("dbo.CorreoPlantillaVariableValor", new[] { "PlantillaId" });
            DropIndex("dbo.CorreoPlantillaVariableValor", new[] { "CorreoId" });
            DropIndex("dbo.CorreoPlantillaVariable", new[] { "UsuarioModificacionId" });
            DropIndex("dbo.CorreoPlantillaVariable", new[] { "UsuarioCreacionId" });
            DropIndex("dbo.CorreoPlantillaVariable", new[] { "PlantillaId" });
            DropIndex("dbo.CorreoPlantilla", new[] { "UsuarioModificacionId" });
            DropIndex("dbo.CorreoPlantilla", new[] { "UsuarioCreacionId" });
            DropIndex("dbo.CorreoAdjunto", new[] { "UsuarioModificacionId" });
            DropIndex("dbo.CorreoAdjunto", new[] { "UsuarioCreacionId" });
            DropIndex("dbo.CorreoAdjunto", new[] { "CorreoId" });
            DropIndex("dbo.Correo", new[] { "UsuarioModificacionId" });
            DropIndex("dbo.Correo", new[] { "UsuarioCreacionId" });
            DropIndex("dbo.Correo", new[] { "CandidaturaId" });
            DropIndex("dbo.Correo", new[] { "PlantillaId" });
            DropTable("dbo.CorreoPlantillaVariableValor");
            DropTable("dbo.CorreoPlantillaVariable");
            DropTable("dbo.CorreoPlantilla");
            DropTable("dbo.CorreoAdjunto");
            DropTable("dbo.Correo");
        }
    }
}
