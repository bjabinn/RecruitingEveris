namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Agregado_Campo_Direccion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Candidato", "Direccion", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Candidato", "Direccion");
        }
    }
}
