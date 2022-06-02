using System.ComponentModel.DataAnnotations;
namespace Pre_aceleracion_Rodrigo_Roman.Models
{
    public class Genres
    {

        public int ID { get; set; }
        [Required]
        [Display(Name = "Nombre")]
        [MaxLength(35)]
        public string Name { get; set; }

        [Required]
        public string Image { get; set; }

        [Required]
        public string Asociated_Movie_Serie { get; set; }

        public ICollection<MovieSerie> Movies { get; set; }
    }
}
