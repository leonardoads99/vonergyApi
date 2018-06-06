using System.Web.Http;
using WebActivatorEx;
using vonergyWS;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace vonergyWS
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

                        GlobalConfiguration.Configuration
                            .EnableSwagger(c =>
                            {
                                c.SingleApiVersion("v1", "Swagger Sample");
                                c.IncludeXmlComments(GetXmlCommentsPath());
                            })
                            .EnableSwaggerUi(c =>
                            {

                            });
                    }


        protected static string GetXmlCommentsPath()
        {
            return System.String.Format(@"bin\vonergyWS.xml", System.AppDomain.CurrentDomain.BaseDirectory);
         //   return System.String.Format(@"{0}\bin\Swagger.XML", System.AppDomain.CurrentDomain.BaseDirectory);

        }
    }
}
