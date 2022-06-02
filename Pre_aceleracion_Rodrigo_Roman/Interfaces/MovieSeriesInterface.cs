using Pre_aceleracion_Rodrigo_Roman.Models;

namespace Pre_aceleracion_Rodrigo_Roman.Interfaces
{
    public interface IMovieSeriesRepository
    {
        List<MovieSerie> GetAllEntities();

        MovieSerie GetEntity(int id);

        MovieSerie Add(MovieSerie entity);

        void Delete(int id);

        MovieSerie Update(MovieSerie entity);
    }
}