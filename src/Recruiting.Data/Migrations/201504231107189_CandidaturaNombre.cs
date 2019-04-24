namespace Recruiting.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class CandidaturaNombre : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Candidatura", "Nombre", c => c.String(maxLength: 250));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Candidatura", "Nombre");
        }
    }
}
