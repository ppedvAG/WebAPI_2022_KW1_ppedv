using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWebAPI.Shared.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public Genre Genre { get; set; }
    }

    public enum Genre { Action=1, Comedy, Drama, Romance, Horror, Documentation}
}
