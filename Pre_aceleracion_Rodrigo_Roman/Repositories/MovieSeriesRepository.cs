using Pre_aceleracion_Rodrigo_Roman.Context;
using Pre_aceleracion_Rodrigo_Roman.Interfaces;
using Pre_aceleracion_Rodrigo_Roman.Models;
using Microsoft.EntityFrameworkCore;

namespace Pre_aceleracion_Rodrigo_Roman.Repositories
{
    public class MovieSeriesRepository : BaseRepository<MovieSerie, DisneyContext>, IMovieSeriesRepository
    {
        public MovieSeriesRepository(DisneyContext context) : base(context)
        {

        }
    }
}
