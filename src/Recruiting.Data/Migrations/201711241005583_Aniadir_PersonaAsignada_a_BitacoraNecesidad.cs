namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Aniadir_PersonaAsignada_a_BitacoraNecesidad : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BitacoraNecesidad", "PersonaAsignadaAnterior", c => c.String());
            AddColumn("dbo.BitacoraNecesidad", "PersonaAsignadaNueva", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.BitacoraNecesidad", "PersonaAsignadaNueva");
            DropColumn("dbo.BitacoraNecesidad", "PersonaAsignadaAnterior");
        }
    }
}
