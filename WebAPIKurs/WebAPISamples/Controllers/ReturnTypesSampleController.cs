using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using WebAPISamples.Data;
using WebAPISamples.Models;

namespace WebAPISamples.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReturnTypesSampleController : ControllerBase
    {
        private readonly ProductsRepository _repository;

        public ReturnTypesSampleController(ProductsRepository repository)
        {
            _repository = repository;
        }

        /*Die einfachste Aktion gibt einen primitiven oder komplexen Datentyp zurück(z.B. string oder einen benutzerdefinierten Objekttyp). 
         *Die folgende Aktion gibt eine Auflistung benutzerdefinierter Product-Objekte zurück:
        */

        //primitive Datentypen (int, string, float etc...)
        //komplexe Datentypen sind List<T> 
        [HttpGet]
        public List<Product> Get() => _repository.GetProducts(); //List -> JSON Seriliaisert

        [HttpGet("BadGetMethode/{id}")]
        public Product GetById(int id)
        {
            if (!_repository.TryGetProduct(id, out var product))
            {
                //return NotFound(); -> Native Datentypen können keine StatusCodes zurücksenden. 
            }

            return product;
        }

        [HttpGet("BetterGetMethode/{id}")]
        public ActionResult<Product> BetterGetById(int id)
        {
            if (!_repository.TryGetProduct(id, out var product))
            {
                return NotFound(); //Mithilfe von ActionResult können wir zusätzlich zum ERgebenis einen StatusCode zurück geben oder Fehler ausgeben 
            }

            return product;
        }

        [HttpGet ("/IActionResultSample")]
        public IActionResult GetCustomer()
        {
            Customer customer = CreateCustomer();

            return new ObjectResult(customer);
        }

        /* Achtung: Bug in früheren Version (ASP.NET Core 2.2)
         * Wenn eine Aktion in ASP.NET Core 2.2 und früher IEnumerable<T> zurückgibt, führt dies zu einer synchronen Sammlungsiteration durch das Serialisierungsprogramm. 
         * Das Ergebnis sind die Blockierung von Aufrufen und die potenzielle Außerkraftsetzung des Threadpools.
         */

        [HttpGet("syncsale")]
        public IEnumerable<Product> GetOnSaleProducts() //Client-BEispiel
        {
            var products = _repository.GetProducts();

            foreach (var product in products)
            {
                yield return product; //Gebe jedes Product einzelnd nach draußen 
            }
        }//Methode verlasse ich hier


        /*
         * Sie sollten den Rückgabetyp der Signatur der Aktion als IAsyncEnumerable<T> deklarieren, um die asynchrone Iteration sicherzustellen. 
         * Letztendlich basiert der Iterationsmodus auf dem zugrunde liegenden konkreten Typ, der zurückgegeben wird. 
         * MVC puffert automatisch jeden konkreten Typ, der IAsyncEnumerable<T> implementiert.
         */
        [HttpGet("asyncsale")]
        public async IAsyncEnumerable<Product> GetOnSaleProductsAsync()
        {
            var products = _repository.GetProductsAsync();

            await foreach (var product in products)
            {
                 yield return product;
            }
        }


        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)] //Diese Methode liefert nur JSON zurück
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Product>> CreateAsync(Product product)
        {
            if (product.Description.Contains("XYZ Widget"))
            {
                return BadRequest();
            }

            await _repository.AddProductAsync(product);

            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
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
