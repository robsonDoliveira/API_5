namespace API_5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PrimeiraMigracao : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Livros",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Edicao = c.String(),
                        NumeroPagina = c.Int(nullable: false),
                        Preco = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Editora = c.String(),
                    })
                .PrimaryKey(t => t.Codigo);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Livros");
        }
    }
}

