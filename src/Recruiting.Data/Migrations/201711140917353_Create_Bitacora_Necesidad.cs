namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_Bitacora_Necesidad : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BitacoraNecesidad",
                c => new
                    {
                        BitacoraId = c.Int(nullable: false, identity: true),
                        NecesidadId = c.Int(nullable: false),
                        TipoBitacora = c.Int(),
                        MensajeSistema = c.String(),
                        EstadoAnteriorId = c.Int(),
                        EstadoNuevoId = c.Int(),
                        PerfilAnteriorId = c.Int(),
                        PerfilNuevoId = c.Int(),
                        FechaSolicitudAnterior = c.DateTime(),
                        FechaSolicitudNueva = c.DateTime(),
                        FechaCompromisoAnterior = c.DateTime(),
                        FechaCompromisoNueva = c.DateTime(),
                        FechaCierreAnterior = c.DateTime(),
                        FechaCierreNueva = c.DateTime(),
                        UsuarioCreacionId = c.Int(nullable: false),
                        UsuarioModificacionId = c.Int(),
                        FechaCreacion = c.DateTime(nullable: false),
                        FechaModificacion = c.DateTime(),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.BitacoraId)
                .ForeignKey("dbo.Maestro", t => t.EstadoAnteriorId)
                .ForeignKey("dbo.Maestro", t => t.EstadoNuevoId)
                .ForeignKey("dbo.Necesidad", t => t.NecesidadId, cascadeDelete: true)
                .ForeignKey("dbo.Maestro", t => t.PerfilAnteriorId)
                .ForeignKey("dbo.Maestro", t => t.PerfilNuevoId)
                .ForeignKey("dbo.Usuario", t => t.UsuarioCreacionId, cascadeDelete: true)
                .ForeignKey("dbo.Usuario", t => t.UsuarioModificacionId)
                .Index(t => t.NecesidadId)
                .Index(t => t.EstadoAnteriorId)
                .Index(t => t.EstadoNuevoId)
                .Index(t => t.PerfilAnteriorId)
                .Index(t => t.PerfilNuevoId)
                .Index(t => t.UsuarioCreacionId)
                .Index(t => t.UsuarioModificacionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BitacoraNecesidad", "UsuarioModificacionId", "dbo.Usuario");
            DropForeignKey("dbo.BitacoraNecesidad", "UsuarioCreacionId", "dbo.Usuario");
            DropForeignKey("dbo.BitacoraNecesidad", "PerfilNuevoId", "dbo.Maestro");
            DropForeignKey("dbo.BitacoraNecesidad", "PerfilAnteriorId", "dbo.Maestro");
            DropForeignKey("dbo.BitacoraNecesidad", "NecesidadId", "dbo.Necesidad");
            DropForeignKey("dbo.BitacoraNecesidad", "EstadoNuevoId", "dbo.Maestro");
            DropForeignKey("dbo.BitacoraNecesidad", "EstadoAnteriorId", "dbo.Maestro");
            DropIndex("dbo.BitacoraNecesidad", new[] { "UsuarioModificacionId" });
            DropIndex("dbo.BitacoraNecesidad", new[] { "UsuarioCreacionId" });
            DropIndex("dbo.BitacoraNecesidad", new[] { "PerfilNuevoId" });
            DropIndex("dbo.BitacoraNecesidad", new[] { "PerfilAnteriorId" });
            DropIndex("dbo.BitacoraNecesidad", new[] { "EstadoNuevoId" });
            DropIndex("dbo.BitacoraNecesidad", new[] { "EstadoAnteriorId" });
            DropIndex("dbo.BitacoraNecesidad", new[] { "NecesidadId" });
            DropTable("dbo.BitacoraNecesidad");
        }
    }
}
