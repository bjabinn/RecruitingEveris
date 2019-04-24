namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aniadir_campo_moneda_a_candidatura : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Candidatura", "Moneda", c => c.String(maxLength: 3));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Candidatura", "Moneda");
        }
    }
}
