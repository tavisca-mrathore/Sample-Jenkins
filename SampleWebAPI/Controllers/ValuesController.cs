using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace SampleWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        // GET api/values/{string}
        [HttpGet("{id}")]
        public string Get(string id)
        {
            if (id == "hi")
            {
                return "hello";
            }
            else if (id == "hello")
            {
                return "hi";
            }
            else
            {
                return "error";
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public int Get(int id)
        {
            return id;
        }

    }
}
