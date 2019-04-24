namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Corregir_Nombre_Columna_BecarioId_de_TablaBitacoraBecario : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.BitacoraBecario", name: "NecesidadId", newName: "BecarioId");
            RenameIndex(table: "dbo.BitacoraBecario", name: "IX_NecesidadId", newName: "IX_BecarioId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.BitacoraBecario", name: "IX_BecarioId", newName: "IX_NecesidadId");
            RenameColumn(table: "dbo.BitacoraBecario", name: "BecarioId", newName: "NecesidadId");
        }
    }
}
