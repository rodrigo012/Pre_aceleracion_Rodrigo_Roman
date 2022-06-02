using Pre_aceleracion_Rodrigo_Roman.Models;
using Pre_aceleracion_Rodrigo_Roman.ViewModels.MovieSeries;
namespace Pre_aceleracion_Rodrigo_Roman.ViewModels.Characters
{
    public class DetallesResponseViewModel
    {   
        public string Image { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public float Weight { get; set; }
        public string Lore { get; set; }
        public List<int> MovieSeriesID { get; set; }
    }
}