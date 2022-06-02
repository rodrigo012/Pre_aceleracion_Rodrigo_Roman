using Pre_aceleracion_Rodrigo_Roman.Models; 
    namespace Pre_aceleracion_Rodrigo_Roman.ViewModels.Characters
{
    public class CharacterResponsetDetailViewModel
    {
        public string? Image { get; set; }
        public string? Name { get; set; }
        public int? Age { get; set; }
        public float? Weight { get; set; }
        public string? Lore { get; set; }
        public List<string> RelatedMovies { get; set; } = new List<string>();
    }
}
