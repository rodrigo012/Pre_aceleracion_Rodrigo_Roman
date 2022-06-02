namespace Pre_aceleracion_Rodrigo_Roman.ViewModels.MovieSeries
{
    public class MoviesGetRequestViewModel
    {
        public string? Title { get; set; }
        public List<int> GenresIDs { get; set; } = new List<int>();
    }
}
