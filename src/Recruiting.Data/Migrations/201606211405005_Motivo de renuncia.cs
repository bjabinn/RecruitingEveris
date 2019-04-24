namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Motivoderenuncia : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Candidatura", "MotivoRenunciaId", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Candidatura", "MotivoRenunciaId");
        }
    }
}
