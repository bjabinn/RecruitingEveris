namespace Recruiting.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class EliminadocampoNombredeCandidatura : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Candidatura", "Nombre");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Candidatura", "Nombre", c => c.String(maxLength: 250));
        }
    }
}
