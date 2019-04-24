namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aniadido_campo_Fecha_Contacto_Standby_a_Candidatura : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Candidatura", "FechaContactoStandBy", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Candidatura", "FechaContactoStandBy");
        }
    }
}
