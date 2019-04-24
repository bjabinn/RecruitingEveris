namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Aniadir_campo_CuentaTokenId_a_Centros : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Centro", name: "CuentaToken_CuentaTokenId", newName: "CuentaTokenId");
            RenameIndex(table: "dbo.Centro", name: "IX_CuentaToken_CuentaTokenId", newName: "IX_CuentaTokenId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Centro", name: "IX_CuentaTokenId", newName: "IX_CuentaToken_CuentaTokenId");
            RenameColumn(table: "dbo.Centro", name: "CuentaTokenId", newName: "CuentaToken_CuentaTokenId");
        }
    }
}
