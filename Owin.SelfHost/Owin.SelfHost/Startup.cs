using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Owin.SelfHost
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            //Configure web api for self-host
            HttpConfiguration config=new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name:"DefaultApi",
                routeTemplate:"api/{controller}/{id}",
                defaults:new {id=RouteParameter.Optional}
                );
            appBuilder.Use(typeof(LoggingMiddleware));
            appBuilder.UseWebApi(config);
            
        }
    }
}
