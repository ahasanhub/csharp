using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Owin.SelfHost
{
    public class ValuesController : ApiController
    {
        //GET api/values
        public IEnumerable<string> Get()
        {
            return  new string[] {"Value1","Value2"};
        }
        //GET api/values/5
        public string Get( int id)
        {
            return "Value";
        }
        //POST api/values
        public void Post([FromBody]string value)
        {

        }
        //PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {

        }
        //DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
