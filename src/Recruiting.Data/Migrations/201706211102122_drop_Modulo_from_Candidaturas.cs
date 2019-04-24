namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class drop_Modulo_from_Candidaturas : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Candidatura", "Modulo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Candidatura", "Modulo", c => c.String());
        }
    }
}
