namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Aniadir_tabla_CuentaToken : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CuentaToken",
                c => new
                    {
                        CuentaTokenId = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 100),
                        Token = c.String(nullable: false),
                        FechaCreacion = c.DateTime(nullable: false),
                        FechaExpiracion = c.DateTime(),
                        FechaCreacionToken = c.DateTime(),
                        FechaExpiracionToken = c.DateTime(),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CuentaTokenId);
            
            AddColumn("dbo.Centro", "CuentaToken_CuentaTokenId", c => c.Int());
            CreateIndex("dbo.Centro", "CuentaToken_CuentaTokenId");
            AddForeignKey("dbo.Centro", "CuentaToken_CuentaTokenId", "dbo.CuentaToken", "CuentaTokenId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Centro", "CuentaToken_CuentaTokenId", "dbo.CuentaToken");
            DropIndex("dbo.Centro", new[] { "CuentaToken_CuentaTokenId" });
            DropColumn("dbo.Centro", "CuentaToken_CuentaTokenId");
            DropTable("dbo.CuentaToken");
        }
    }
}
