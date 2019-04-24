namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aniadida_tabla_Centro : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Centro",
                c => new
                    {
                        CentroId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 250),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CentroId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Centro");
        }
    }
}
