using CadastroVeiculos.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CadastroVeiculos.Domain.Interfaces
{
    public interface IBaseService<TEntity> where TEntity : BaseEntity
    {
        TEntity Add<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>;
        TEntity Update<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>;

        void Delete(int id);
        void Delete(string id);

        void Delete(TEntity obj);

        IList<TEntity> Get();

        TEntity GetById(int id);

        TEntity GetById(string id);

        TEntity ObterPorCondicao(Expression<Func<TEntity, bool>> predicate);
    }
}
