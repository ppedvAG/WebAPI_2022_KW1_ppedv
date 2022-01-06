#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPISamples.Models;


namespace WebAPISamples.Data
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext (DbContextOptions<MovieDbContext> options)
            : base(options) //opertions beinhaltet den ConnectionString 
        {
        }

        public DbSet<Movie> Movie { get; set; } //Repräsentiert eine Tabelle 
        //z.b Movie.ToList() -> erhälst du alle Datensätze aus der Tabelle Movie 
    }
}
