using Pre_aceleracion_Rodrigo_Roman.Models;
namespace Pre_aceleracion_Rodrigo_Roman.Interfaces
{
    public interface ICharactersRepository
    {
        List<Characters> GetAllEntities();

        Characters GetEntity(int id);

        Characters Add(Characters entity);

        void Delete(int id);

        Characters Update(Characters entity);
    }
}