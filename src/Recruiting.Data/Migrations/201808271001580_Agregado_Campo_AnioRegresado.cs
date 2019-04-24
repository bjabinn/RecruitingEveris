namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Agregado_Campo_AnioRegresado : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Candidato", "AnioRegresado", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Candidato", "AnioRegresado");
        }
    }
}
