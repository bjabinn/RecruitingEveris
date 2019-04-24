namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Aniadir_Orden_A_Etapa_Candidautra : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TipoEtapaCandidatura", "Orden", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TipoEtapaCandidatura", "Orden");
        }
    }
}
