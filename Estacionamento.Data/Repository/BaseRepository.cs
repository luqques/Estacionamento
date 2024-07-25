using Estacionamento.Data.Context;
using Estacionamento.Domain.Entities;
using Estacionamento.Domain.Interfaces;

namespace Estacionamento.Data.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly MySqlContext _context;

        public BaseRepository(MySqlContext context)
        {
            _context = context;
        }

        //TODO: Implementar interface quando tiver feita

        public void Insert(TEntity obj)
        {
            _context.Set<TEntity>().Add(obj);
            _context.SaveChanges();
        }

        //public void Update(TEntity obj)
        //{
        //    _context.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        //    _context.SaveChanges();
        //}

        //public void Delete(int id)
        //{
        //    _context.Set<TEntity>().Remove(Select(id));
        //    _context.SaveChanges();
        //}

        //public IList<TEntity> Select() =>
        //    _context.Set<TEntity>().ToList();

        //public TEntity Select(int id) =>
        //    _context.Set<TEntity>().Find(id);
    }
}
