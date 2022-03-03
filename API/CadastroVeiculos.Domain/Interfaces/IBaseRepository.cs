using CadastroVeiculos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CadastroVeiculos.Domain.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        void Insert(TEntity obj);

        void Update(TEntity obj);

        void Delete(int id);
        void Delete(string id);
        void Delete(TEntity obj);
        IList<TEntity> Select();

        TEntity Select(int id);
        TEntity Select(string id);

        TEntity ObterPorCondicao(Expression<Func<TEntity, bool>> predicate);
    }
}
