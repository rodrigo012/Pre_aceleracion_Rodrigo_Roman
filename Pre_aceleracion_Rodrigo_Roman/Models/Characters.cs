using System.ComponentModel.DataAnnotations;
namespace Pre_aceleracion_Rodrigo_Roman.Models
{
    public class Characters
    {
        public int ID { get; set; }
        [Required]
        public string Image { get; set; }

        [Required]
        [MaxLength(35)]
        [RegularExpression("^[A-Za-z ]+$")]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Edad")]
        public int Age { get; set; }

        [Required]
        public float Weight { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Lore { get; set; }

        public List<MovieSerie>? MovieSeries { get; set; }

    }
}
