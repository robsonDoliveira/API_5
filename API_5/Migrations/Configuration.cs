namespace API_5.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
using System.Data.Entity.SqlServer;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<API_5.Models.Context.BancoContext>
    {
        public Configuration()
        {
            // ABILITO COMO TRUE PARA PODER USAR O MIGRATION VÁRIAS VEZES, PARA NÃOI CRIAR MIGRAÇÃO PARA CADA ATUALIZAÇÃO
            AutomaticMigrationsEnabled = false;

            // CONFIGURAÇÃO DE MIGRAÇÃO
            SetSqlGenerator("System.Data.SqlClient", new SqlServerMigrationSqlGenerator());
        }

        protected override void Seed(API_5.Models.Context.BancoContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
