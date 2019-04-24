namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModificacionBitacoraColumnaReversible : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bitacora", "Revertible", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bitacora", "Revertible");
        }
    }
}
