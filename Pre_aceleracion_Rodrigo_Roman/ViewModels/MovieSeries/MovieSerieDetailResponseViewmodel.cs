using Pre_aceleracion_Rodrigo_Roman.Models;

namespace Pre_aceleracion_Rodrigo_Roman.ViewModels.MovieSeries
{
    public class MovieSerieDetailResponseViewmodel
    {
        public string? Image { get; set; }
        public string? Title { get; set; }
        public DateTime? Release_Year { get; set; }
        public int? Ranking { get; set; }
        public Genres? Genre { get; set; }
    }
}
