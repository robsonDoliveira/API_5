namespace API_5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsercaoNovosCampos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Livros", "EmailAutor", c => c.String());
            AlterColumn("dbo.Livros", "Nome", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Livros", "Editora", c => c.String(nullable: false));
            DropColumn("dbo.Livros", "Email");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Livros", "Email", c => c.String());
            AlterColumn("dbo.Livros", "Editora", c => c.String());
            AlterColumn("dbo.Livros", "Nome", c => c.String());
            DropColumn("dbo.Livros", "EmailAutor");
        }
    }
}
