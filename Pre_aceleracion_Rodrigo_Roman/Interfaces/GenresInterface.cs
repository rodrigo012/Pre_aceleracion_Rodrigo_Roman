using Pre_aceleracion_Rodrigo_Roman.Models;

namespace Pre_aceleracion_Rodrigo_Roman.Interfaces
{
    public interface IGenresRepository
    {
        List<Genres> GetAllEntities();

        Genres GetEntity(int id);

        Genres Add(Genres entity);

        void Delete(int id);

        Genres Update(Genres entity);
    }
}
