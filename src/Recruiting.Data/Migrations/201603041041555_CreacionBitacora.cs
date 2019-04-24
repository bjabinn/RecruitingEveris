namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreacionBitacora : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bitacora",
                c => new
                    {
                        BitacoraId = c.Int(nullable: false, identity: true),
                        CandidaturaId = c.Int(nullable: false),
                        TipoCambio = c.String(),
                        MensajeSistema = c.String(),
                        Observaciones = c.String(),
                        UsuarioCreacionId = c.Int(nullable: false),
                        UsuarioModificacionId = c.Int(),
                        FechaCreacion = c.DateTime(nullable: false),
                        FechaModificacion = c.DateTime(),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.BitacoraId)
                .ForeignKey("dbo.Candidatura", t => t.CandidaturaId, cascadeDelete: false)
                .ForeignKey("dbo.Usuario", t => t.UsuarioCreacionId, cascadeDelete: false)
                .ForeignKey("dbo.Usuario", t => t.UsuarioModificacionId)
                .Index(t => t.CandidaturaId)
                .Index(t => t.UsuarioCreacionId)
                .Index(t => t.UsuarioModificacionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bitacora", "UsuarioModificacionId", "dbo.Usuario");
            DropForeignKey("dbo.Bitacora", "UsuarioCreacionId", "dbo.Usuario");
            DropForeignKey("dbo.Bitacora", "CandidaturaId", "dbo.Candidatura");
            DropIndex("dbo.Bitacora", new[] { "UsuarioModificacionId" });
            DropIndex("dbo.Bitacora", new[] { "UsuarioCreacionId" });
            DropIndex("dbo.Bitacora", new[] { "CandidaturaId" });
            DropTable("dbo.Bitacora");
        }
    }
}
