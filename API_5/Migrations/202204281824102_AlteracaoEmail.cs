namespace API_5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlteracaoEmail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Livros", "Email", c => c.String());

            // Linha para adicionar dados de uma tabela para outra
            Sql("UPDATE Livros SET Email = EmailAutor");

            DropColumn("dbo.Livros", "EmailAutor");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Livros", "EmailAutor", c => c.String());

            // Linha para adicionar dados de uma tabela para outra
            Sql("UPDATE Livros SET EmailAutor = Email");

            DropColumn("dbo.Livros", "Email");
        }
    }
}
