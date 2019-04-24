namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aniadida_tabla_GrupoNecesidad : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GrupoNecesidad",
                c => new
                    {
                        GrupoNecesidadId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(maxLength: 250),
                        Descripcion = c.String(maxLength: 250),
                        GrupoCerrado = c.Boolean(nullable: false),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.GrupoNecesidadId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.GrupoNecesidad");
        }
    }
}
