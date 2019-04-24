namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Agregar_Campo_Prioridad_a_Necesidad : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Necesidad", "Prioridad", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Necesidad", "Prioridad");
        }
    }
}
