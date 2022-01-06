#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPISamples.Data;
using WebAPISamples.Models;

namespace WebAPISamples.Controllers
{
    //Konventionen Überblick -> https://docs.microsoft.com/de-de/aspnet/core/web-api/advanced/conventions?view=aspnetcore-6.0


    [Route("api/[controller]")]
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))] //Wird komplett auf alle Actions-Methodem
    [Consumes(MediaTypeNames.Application.Json)] //Diese Methode liefert nur JSON zurück
    public class MovieController : ControllerBase
    {
        private readonly MovieDbContext _context;

        //Hier greifen wir auf unseren IOC Container zurück und holen uns eine Verbindung zur Datenbank (DbContext-Klasse) 
        public MovieController(MovieDbContext context) 
        {
            _context = context;
        }

        // GET: api/Movie
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovie()
        {

            //TPL 
            //Task<List<Movie>> task = _context.Movie.ToListAsync();
            //task.Wait(); // Wir warten auf den Callback aus der Asynchronen Methode
            //List<Movie> mymovies= task.Result; //Danach wird das Ergebnis in task.Result angeboten 

            //asyn/await Pattern 
            List<Movie> movies = await _context.Movie.ToListAsync(); //Select * FRom Movie -> wird richtung DB gesendet

            return movies;
        }

        // GET: api/Movie/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Movie), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Movie), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Movie), StatusCodes.Status405MethodNotAllowed)]
        [ProducesResponseType(typeof(Movie), StatusCodes.Status408RequestTimeout)]
        public async Task<ActionResult<Movie>> GetMovie(int? id)
        {

            if (!id.HasValue)
            {
                return NotFound(); //404
            }

            var movie = await _context.Movie.FindAsync(id);

            if (movie == null)
            {
                return NotFound();
            }

            return movie; //Wenn DAtensatz zurückgegeben wird -> HttpStatus-Code 200er 
        }

        // GET: api/Movie/5
        [HttpGet("GetVideo/{id}")]
        [ApiConventionMethod(typeof(DefaultApiConventions),  nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult<Movie>> GetMyMovie(int? id)
        {

            if (!id.HasValue)
            {
                return NotFound(); //404
            }

            var movie = await _context.Movie.FindAsync(id);

            if (movie == null)
            {
                return NotFound();
            }

            return movie; //Wenn DAtensatz zurückgegeben wird -> HttpStatus-Code 200er 
        }

        // PUT: api/Movie/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(int id, Movie movie)
        {
            if (id != movie.Id)
            {
                return BadRequest();
            }

            _context.Entry(movie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Movie
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(Movie movie)
        {
            _context.Movie.Add(movie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMovie", new { id = movie.Id }, movie);
        }

        // DELETE: api/Movie/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var movie = await _context.Movie.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            _context.Movie.Remove(movie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MovieExists(int id)
        {
            return _context.Movie.Any(e => e.Id == id);
        }
    }
}
