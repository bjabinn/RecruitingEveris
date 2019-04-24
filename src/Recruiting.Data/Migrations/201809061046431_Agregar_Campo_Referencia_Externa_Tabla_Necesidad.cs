namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Agregar_Campo_Referencia_Externa_Tabla_Necesidad : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Necesidad", "ReferenciaExterna", c => c.String(maxLength: 250));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Necesidad", "ReferenciaExterna");
        }
    }
}
