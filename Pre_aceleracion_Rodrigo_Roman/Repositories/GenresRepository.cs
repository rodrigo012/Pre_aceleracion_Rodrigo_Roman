using Pre_aceleracion_Rodrigo_Roman.Context;
using Pre_aceleracion_Rodrigo_Roman.Interfaces;
using Pre_aceleracion_Rodrigo_Roman.Models;

namespace Pre_aceleracion_Rodrigo_Roman.Repositories
{
    public class GenresRepository : BaseRepository<Genres, DisneyContext>, IGenresRepository
    {
        public GenresRepository(DisneyContext context) : base(context)
        {

        }
    }
}
