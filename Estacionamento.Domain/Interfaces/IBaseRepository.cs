using Estacionamento.Domain.Entities;

namespace Estacionamento.Domain.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        //TODO: Definir métodos de persistencia no banco de dados

        void Insert(TEntity obj);

        //void Update(TEntity obj);

        //void Delete(int id);

        //IList<TEntity> Select();

        //TEntity Select(int id);
    }
}
