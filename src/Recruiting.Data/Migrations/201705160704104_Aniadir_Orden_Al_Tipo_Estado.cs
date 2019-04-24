namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Aniadir_Orden_Al_Tipo_Estado : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TipoEstadoCandidatura", "Orden", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TipoEstadoCandidatura", "Orden");
        }
    }
}
