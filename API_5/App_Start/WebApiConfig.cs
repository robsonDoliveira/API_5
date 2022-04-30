using System.Web.Http;

namespace API_5
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}


// FOI EXECUTADO NO TERMINAL
// Enable-Migrations
// Add-Migration PrimeiraMigracao
// Update-Database
// Update-Database -Force --> Para remover registros com dados, atualizar.
// Update-Database -TargetMigration 202204281742031_AutomaticMigration -Force  --> Para voltar uma Migração anterior
