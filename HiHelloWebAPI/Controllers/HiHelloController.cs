using Microsoft.AspNetCore.Mvc;

namespace HiHelloWebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HiHelloController : ControllerBase
    {
        // GET hihello/
        [HttpGet]
        public string Get()
        {
            return "append \"hi\" or \"hello\" in the url to get response";
        }

        // GET hihello/{hi/hello}
        [HttpGet("{urlString}")]
        public string Get(string urlString)
        {
            if (urlString == "hi")
            {
                return "hello";
            }
            else if (urlString == "hello")
            {
                return "hi";
            }
            else
            {
                return "error";
            }
        }
    }
}
