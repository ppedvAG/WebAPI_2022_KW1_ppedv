using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPISamples.Data;
using WebAPISamples.Models;

namespace WebAPISamples.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaggingSortingController : ControllerBase
    {
        private readonly MovieDbContext _dbContext;
        public PaggingSortingController(MovieDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("EasyPageingList")]
        public async Task<ActionResult<IEnumerable<Movie>>> EasyPagingList(int pageNumber=1, int pageSize=3)
        {
            return await _dbContext.Movie.OrderBy(o => o.Title)
                                         .Skip((pageNumber - 1) * pageSize)
                                         .Take(pageSize).ToListAsync();
        }

        [HttpGet("PagingListWithPageParametersObject")]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovies([FromQuery] PageParameters parameters)
        {
            return await _dbContext.Movie.OrderBy(o => o.Title)
                .Skip((parameters.PageNumber - 1) * parameters.PageSize)
                .Take(parameters.PageSize)
                .ToListAsync();
        }
    }



    public class PageParameters
    {
        const int maxPageSize = 3;

        public int PageNumber { get; set; } = 1;
        private int _pageSize = 3;

        public int PageSize
        {
            get
            {
                return _pageSize;
            }

            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }
    }
}
