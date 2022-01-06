using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DefaultWebAPI_NET5.Models;

namespace DefaultWebAPI_NET5.Data
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext (DbContextOptions<MovieDbContext> options)
            : base(options)
        {
        }

        public DbSet<DefaultWebAPI_NET5.Models.Movie> Movie { get; set; }
    }
}
