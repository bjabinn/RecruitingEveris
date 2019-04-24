namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Eliminar_campo_SalarioDeseado_de_tabla_dbo_candidato : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Candidato", "SalarioDeseado");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Candidato", "SalarioDeseado", c => c.Decimal(precision: 18, scale: 2));
        }
    }
}
