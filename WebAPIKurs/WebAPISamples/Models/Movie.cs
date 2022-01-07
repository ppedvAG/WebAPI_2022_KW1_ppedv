using System.ComponentModel.DataAnnotations;

namespace WebAPISamples.Models
{
    //DataAnnotations https://docs.microsoft.com/de-de/dotnet/api/system.componentmodel.dataannotations?view=net-6.0
    // [Required], [MinLength(10)] , [Range(0, 20)]  usw...
    public class Movie //Entities verwenden keine Interface -> Entities werden auch POCO Objects genannt 
    {
        public int Id { get; set; }

        [Required] 
        public string Title { get; set; } = default!;

        [MinLength(10)] 
        public string Description { get; set; } = default!;

        [Range(0, 20)] 
        public decimal Price { get; set; }

        public short IMDB_Rating { get; set; }

        [Required] 
        public GenreType Genre { get; set; } // wird in ein Integer-Wert herunter gebrochen
    }

    public enum GenreType { Action, Thriller, Drama, Romance, Comedy, Horror, Documentation }
}
