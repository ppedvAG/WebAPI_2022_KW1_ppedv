using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPISamples.Services;

namespace WebAPISamples.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DISampleController : ControllerBase
    {

        private readonly ITimeService _service; 

        //serviceProvider.GetService<ITimeService>(); 
        public DISampleController(ITimeService service) //Zugriff auf IOC Container
        {
            _service = service;
        }


        public string GetTime([FromServices] ITimeService service) //FromService -> gilt nur für diese Methode
        {
            //Alternativ -> _service = service;
            
            return service.GetCurrentTime();
        }
    }
}
