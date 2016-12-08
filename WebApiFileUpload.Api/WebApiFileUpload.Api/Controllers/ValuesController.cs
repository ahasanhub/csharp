using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebApiFileUpload.Api.Controllers
{
    public class ValuesController : ApiController
    {
        [HttpGet,Route("api/values")]
        public IHttpActionResult Get()
        {
            return Json(new {Message = "I am Ahasan"});
        }
    }
}
