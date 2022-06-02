using Microsoft.EntityFrameworkCore;
using Pre_aceleracion_Rodrigo_Roman.Models;

namespace Pre_aceleracion_Rodrigo_Roman.Context
{
    public class DisneyContext : DbContext
    {
        private const string Schema = "disney";
        public DisneyContext(DbContextOptions<DisneyContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Characters> Characters { get; set; } = null!;
        public DbSet<MovieSerie> MovieSeries { get; set; } = null!;
        public DbSet<Genres> Genres { get; set; } = null!;
    }

}