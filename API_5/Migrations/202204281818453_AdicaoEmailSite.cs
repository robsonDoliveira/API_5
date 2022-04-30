namespace API_5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicaoEmailSite : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Livros", "SiteLivro", c => c.String());
            AddColumn("dbo.Livros", "EmailAutor", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Livros", "EmailAutor");
            DropColumn("dbo.Livros", "SiteLivro");
        }
    }
}
