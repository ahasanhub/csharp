using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.Api.Controllers
{
    public class CitiesController : Controller
    {
        public JsonResult GetCities()
        {
            return new JsonResult(new List<object>()
            {
                new {Id=1,Name="Dhaka"},
                new {Id=2,Name="Rajshahi"}
            });
        }
    }
}
