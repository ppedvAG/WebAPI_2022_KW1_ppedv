using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPISamples.Models;

namespace WebAPISamples.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomFormatterController : ControllerBase
    {
        [HttpGet]
        public Contact GetContact() //Out Formatter 
        {
            Contact contact = new Contact();
            contact.Id = 1;
            contact.Firstname = "Otto";
            contact.Lastname = "Walkes";

            return contact;
        }


        [HttpPost]
        public IActionResult Insert(Contact contact) //Input Formatter 
        {
            return Ok();
        }
    }
}
