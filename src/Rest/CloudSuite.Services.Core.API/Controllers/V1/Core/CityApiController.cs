using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CloudSuite.Services.Core.Api.Controllers.V1.Core
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityApiController : ControllerBase
    {
        // GET: api/<CityApiController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CityApiController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CityApiController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CityApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CityApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
