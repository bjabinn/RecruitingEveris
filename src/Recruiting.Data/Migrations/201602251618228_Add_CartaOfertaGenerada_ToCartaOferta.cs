namespace Recruiting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_CartaOfertaGenerada_ToCartaOferta : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CartaOferta", "CartaOfertaGenerada", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CartaOferta", "CartaOfertaGenerada");
        }
    }
}
