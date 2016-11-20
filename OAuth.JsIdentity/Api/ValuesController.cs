using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Api
{
    public class ValuesController : ApiController
    {
        [Route("values")]
        public IHttpActionResult Get()
        {
            return Json(new {message="Hello",value="world"});
        }
    }
}