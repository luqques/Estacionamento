using Estacionamento.Domain.Entities;
using FluentValidation;

namespace Estacionamento.Domain.Interfaces
{
    public interface IBaseService<TEntity> where TEntity : BaseEntity
    {
        //TODO: Definir métodos para o service

        TEntity Add<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>;

        //void Delete(int id);

        //IList<TEntity> Get();

        //TEntity GetById(int id);

        //TEntity Update<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>;
    }
}
