namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Aumentar_capacidad_descripcion_GrupoNecesidades : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.GrupoNecesidad", "Descripcion", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.GrupoNecesidad", "Descripcion", c => c.String(maxLength: 250));
        }
    }
}
