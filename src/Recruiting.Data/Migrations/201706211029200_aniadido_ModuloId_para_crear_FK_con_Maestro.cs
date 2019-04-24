namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aniadido_ModuloId_para_crear_FK_con_Maestro : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Candidatura", name: "TipoModulo_MaestroId", newName: "ModuloId");
            RenameIndex(table: "dbo.Candidatura", name: "IX_TipoModulo_MaestroId", newName: "IX_ModuloId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Candidatura", name: "IX_ModuloId", newName: "IX_TipoModulo_MaestroId");
            RenameColumn(table: "dbo.Candidatura", name: "ModuloId", newName: "TipoModulo_MaestroId");
        }
    }
}
