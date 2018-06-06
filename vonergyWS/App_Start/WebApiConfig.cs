using System.Web.Http;
using System.Web.Http.Cors;

namespace vonergyWS
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            
            // Web API configuration and services
          //  var corsAttr = new EnableCorsAttribute("http://example.com", methods: "GET, POST", headers: "*");

           // config.EnableCors(corsAttr);
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            //  SwaggerConfig.Register();

            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("application/json"));
        }
    }
}
