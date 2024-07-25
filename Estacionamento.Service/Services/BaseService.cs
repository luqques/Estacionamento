using Estacionamento.Domain.Entities;
using Estacionamento.Domain.Interfaces;
using FluentValidation;

namespace Estacionamento.Service.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : BaseEntity
    {
        private readonly IBaseRepository<TEntity> _baseRepository;

        public BaseService(IBaseRepository<TEntity> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        //TODO: Implementar service quando tiver com o contrato definido

        public TEntity Add<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>
        {
            Validate(obj, Activator.CreateInstance<TValidator>());
            //_baseRepository.Insert(obj);
            return obj;
        }

        //public void Delete(int id) => _baseRepository.Delete(id);

        //public IList<TEntity> Get() => _baseRepository.Select();

        //public TEntity GetById(int id) => _baseRepository.Select(id);

        public TEntity Update<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>
        {
            Validate(obj, Activator.CreateInstance<TValidator>());
            //_baseRepository.Update(obj);
            return obj;
        }

        private void Validate(TEntity obj, AbstractValidator<TEntity> validator)
        {
            if (obj == null)
                throw new Exception("Registros não econtrados!");

            validator.ValidateAndThrow(obj);
        }
    }
}
