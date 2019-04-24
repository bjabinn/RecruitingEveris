namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Aniadir_CampoUbicacion_Candidaturas : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Candidatura", "UbicacionCandidato", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Candidatura", "UbicacionCandidato");
        }
    }
}
