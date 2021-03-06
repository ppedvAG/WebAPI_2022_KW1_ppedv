using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using WebAPISamples.Models;

namespace WebAPISamples.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatchSampleController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetCustomer()
        {
            Customer customer = CreateCustomer();

            return new ObjectResult(customer);
        }

        [HttpPatch]
        public IActionResult PatchCustomer([FromBody] JsonPatchDocument<Customer> patchDoc)
        {
            if (patchDoc != null)
            {
                Customer customer = CreateCustomer();

                patchDoc.ApplyTo(customer, ModelState); //DataAnnotations werden ausgelesen und ModelState weiß danach, ob valide oder nichtvalide

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                return new ObjectResult(customer);
            }
            else return BadRequest(ModelState);
        }


        private Customer CreateCustomer()
        {
            return new Customer
            {
                CustomerName = "John",
                Orders = new List<Order>()
                {
                    new Order
                    {
                        OrderName = "Order0"
                    },
                    new Order
                    {
                        OrderName = "Order1"
                    }
                }
            };
        }
    }
}
