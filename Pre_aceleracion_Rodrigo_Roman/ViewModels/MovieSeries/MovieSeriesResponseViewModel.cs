﻿namespace Pre_aceleracion_Rodrigo_Roman.ViewModels.MovieSeries
{
    public class MovieSeriesResponseViewModel
    {
        public string? Image { get; set; }
        public string? Title { get; set; }
        public DateTime Release_Year { get; set; }
        public int Ranking { get; set; }
        public List<string> Characters { get; set; } = new List<string>();
    }
}