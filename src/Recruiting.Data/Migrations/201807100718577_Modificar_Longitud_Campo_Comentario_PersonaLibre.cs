namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Modificar_Longitud_Campo_Comentario_PersonaLibre : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PersonaLibre", "Comentario", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PersonaLibre", "Comentario", c => c.String(maxLength: 500));
        }
    }
}
