using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPISamples.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParameterSampleController : ControllerBase
    {


        [HttpGet]
        public IEnumerable<string> Values()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{id}")]
        public string Value(int id)
        {
            return "value";
        }

        [HttpPost]
        public void SaveNewValue([FromBody] string value)
        {
        }

        [HttpPut]
        public void UpdateValue(int id, [FromBody] string value)
        {
        }

        [HttpDelete]
        public void RemoveValue(int id)
        {
        }
    }
}
