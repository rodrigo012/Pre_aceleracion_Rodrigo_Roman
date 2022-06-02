using System.ComponentModel.DataAnnotations;

namespace Pre_aceleracion_Rodrigo_Roman.ViewModels.Characters
{
    
    public class CharacterRequestDetailViewModel
    {
        [MaxLength(35)]
        [RegularExpression("^[A-Za-z ]+$")]
        public string? Name { get; set; }

        [RegularExpression("[0-9]")]
        public int? Age { get; set; }


        public List<int> MovieSeriesID { get; set; } = new List<int>();
    }
}
