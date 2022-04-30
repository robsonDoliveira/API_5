namespace API_5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CampoDataCadastroRemovido : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Livros", "DataCadastro");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Livros", "DataCadastro", c => c.DateTime(nullable: false));
        }
    }
}
