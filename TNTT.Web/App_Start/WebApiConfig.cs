using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;
using System.Web.Mvc;
using Newtonsoft.Json.Serialization;

namespace TNTT.Web
{
    public static class WebApiConfig
    {

        public static string ControllerOnly = "ApiControllerOnly";
        public static string ControllerAndId = "ApiControllerAndIntegerId";
        public static string ControllerAction = "ApiControllerAction";

        public static void Register(HttpConfiguration config)
        {
            Configure(config);
        }
        
        private static void Configure(HttpConfiguration config)
        {
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(Startup.OAuthOptions.AuthenticationType));
            config.MapHttpAttributeRoutes();

            // ex: api/users
            // ex: api/groups
            config.Routes.MapHttpRoute(
                name: ControllerOnly,
                routeTemplate: "api/{controller}"
            );
            //  ex: api/users/1
            //  ex: api/groups/1
            config.Routes.MapHttpRoute(
                name: ControllerAndId,
                routeTemplate: "api/{controller}/{id}",
                defaults: null //defaults: new { id = RouteParameter.Optional } //,
                //constraints: new { id = @"^\d+$" } // id must be all digits
            );

            // ex: api/lookups/all
            // ex: api/lookups/rooms
            config.Routes.MapHttpRoute(
                name: ControllerAction,
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: null
            );
        }
    }
}
