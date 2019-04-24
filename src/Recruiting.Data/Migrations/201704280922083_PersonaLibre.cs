namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PersonaLibre : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PersonaLibre",
                c => new
                    {
                        PersonaLibreId = c.Int(nullable: false, identity: true),
                        NroEmpleado = c.Int(nullable: false),
                        Nombre = c.String(nullable: false, maxLength: 30),
                        Apellidos = c.String(nullable: false, maxLength: 50),
                        Categoria = c.String(nullable: false, maxLength: 255),
                        Linea = c.String(maxLength: 255),
                        Celda = c.String(maxLength: 255),
                        FechaLiberacion = c.DateTime(),
                        NecesidadId = c.Int(nullable: false),
                        Comentario = c.String(maxLength: 500),
                        EstadoPersonaLibreId = c.Int(),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PersonaLibreId)
                .ForeignKey("dbo.Maestro", t => t.NecesidadId, cascadeDelete: true)
                .Index(t => t.NecesidadId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PersonaLibre", "NecesidadId", "dbo.Maestro");
            DropIndex("dbo.PersonaLibre", new[] { "NecesidadId" });
            DropTable("dbo.PersonaLibre");
        }
    }
}
