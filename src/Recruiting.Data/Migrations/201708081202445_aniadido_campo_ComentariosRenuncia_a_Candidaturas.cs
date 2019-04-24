namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aniadido_campo_ComentariosRenuncia_a_Candidaturas : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Candidatura", "ComentariosRenuncia", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Candidatura", "ComentariosRenuncia");
        }
    }
}
