namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPersonasLibresIdioma : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CandidatoIdioma", "IdiomaId", "dbo.Maestro");
            DropForeignKey("dbo.CandidatoIdioma", "NivelIdiomaId", "dbo.Maestro");
            CreateTable(
                "dbo.PersonaLibreIdioma",
                c => new
                    {
                        PersonaLibreIdiomasId = c.Int(nullable: false, identity: true),
                        PersonaLibreId = c.Int(nullable: false),
                        IdiomaId = c.Int(nullable: false),
                        NivelIdiomaId = c.Int(nullable: false),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PersonaLibreIdiomasId)
                .ForeignKey("dbo.Maestro", t => t.IdiomaId)
                .ForeignKey("dbo.Maestro", t => t.NivelIdiomaId)
                .ForeignKey("dbo.PersonaLibre", t => t.PersonaLibreId, cascadeDelete: true)
                .Index(t => t.PersonaLibreId)
                .Index(t => t.IdiomaId)
                .Index(t => t.NivelIdiomaId);
            
            AddForeignKey("dbo.CandidatoIdioma", "IdiomaId", "dbo.Maestro", "MaestroId");
            AddForeignKey("dbo.CandidatoIdioma", "NivelIdiomaId", "dbo.Maestro", "MaestroId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CandidatoIdioma", "NivelIdiomaId", "dbo.Maestro");
            DropForeignKey("dbo.CandidatoIdioma", "IdiomaId", "dbo.Maestro");
            DropForeignKey("dbo.PersonaLibreIdioma", "PersonaLibreId", "dbo.PersonaLibre");
            DropForeignKey("dbo.PersonaLibreIdioma", "NivelIdiomaId", "dbo.Maestro");
            DropForeignKey("dbo.PersonaLibreIdioma", "IdiomaId", "dbo.Maestro");
            DropIndex("dbo.PersonaLibreIdioma", new[] { "NivelIdiomaId" });
            DropIndex("dbo.PersonaLibreIdioma", new[] { "IdiomaId" });
            DropIndex("dbo.PersonaLibreIdioma", new[] { "PersonaLibreId" });
            DropTable("dbo.PersonaLibreIdioma");
            AddForeignKey("dbo.CandidatoIdioma", "NivelIdiomaId", "dbo.Maestro", "MaestroId", cascadeDelete: true);
            AddForeignKey("dbo.CandidatoIdioma", "IdiomaId", "dbo.Maestro", "MaestroId", cascadeDelete: true);
        }
    }
}
