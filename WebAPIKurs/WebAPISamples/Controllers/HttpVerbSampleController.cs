using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPISamples.Services;

namespace WebAPISamples.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HttpVerbSampleController : ControllerBase
    {

        private readonly ITimeService _service; 

        //serviceProvider.GetService<ITimeService>(); 
        public HttpVerbSampleController(ITimeService service) //Zugriff auf IOC Container
        {
            _service = service;
        }

        [HttpGet]
        public string GetTime([FromServices] ITimeService service) //FromService -> gilt nur für diese Methode
        {
            //Alternativ -> _service = service;
            
            return service.GetCurrentTime();
        }

        //Kombinationen mit HttpPost und HttpPut sind auf den ersten Blick interessant. 
        //!!!   Allerdings: Weitere Konventionansangaben zu HttpPost oder HtppPut sind parallel nicht möglich
        //[HttpPost ("/InsertTime")]
        //[HttpPut ("/UpdateTime")]
        //public void InsertOrUpdateTime(string time)
        //{
        //    //Insert Or Update
        //}

        [HttpPost("DateTime/InsertTime")]
        public void InsertTime(string time)
        {
            //Hinzufügen einer Urhzeit
        }

        [HttpPut("DateTime/UpdateTime")]
        public void UpdateTime(string time)
        {
            //Hinzufügen einer Urhzeit
        }
    }
}
