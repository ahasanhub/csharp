using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SecurityPipeline.Pipeline
{
    [TestAuthenticationFilter]
    [TestAuthorizationFilter]
    public class TestController : ApiController
    {
        [Route("api/test")]
        public IHttpActionResult Get()
        {
            Helper.Write("Controller",User);
            return Json(new {message ="Ok"});
        }
    }
}