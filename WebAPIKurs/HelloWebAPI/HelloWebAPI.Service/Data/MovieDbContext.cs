using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HelloWebAPI.Shared.Entities;

namespace HelloWebAPI.Service.Data
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext (DbContextOptions<MovieDbContext> options)
            : base(options)
        {
        }

        public DbSet<HelloWebAPI.Shared.Entities.Movie> Movie { get; set; }
    }
}
