namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Cambiar_Length_Descripcion_GrupoNecesidad : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.GrupoNecesidad", "Descripcion", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.GrupoNecesidad", "Descripcion", c => c.String(maxLength: 500));
        }
    }
}
