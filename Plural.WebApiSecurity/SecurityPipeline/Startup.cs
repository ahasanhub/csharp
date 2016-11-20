using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Owin;
using SecurityPipeline.Pipeline;

namespace SecurityPipeline
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config=new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            app.Use(typeof(TestMiddleware));
            app.UseWebApi(config);
        }
    }
}