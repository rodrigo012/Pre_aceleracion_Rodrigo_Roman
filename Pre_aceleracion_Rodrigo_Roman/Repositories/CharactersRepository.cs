using Microsoft.EntityFrameworkCore;
using Pre_aceleracion_Rodrigo_Roman.Context;
using Pre_aceleracion_Rodrigo_Roman.Interfaces;
using Pre_aceleracion_Rodrigo_Roman.Models;

namespace Pre_aceleracion_Rodrigo_Roman.Repositories {

public class CharactersRepository : BaseRepository<Characters, DisneyContext>, ICharactersRepository
{
    public CharactersRepository(DisneyContext context) : base(context)
    {
    }

    public List<Characters> getCharactersMS()
    {
        return DbSet.Include(x => x.MovieSeries).ToList();
    }
}

}