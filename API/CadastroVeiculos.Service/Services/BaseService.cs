using CadastroVeiculos.Domain.Entities;
using CadastroVeiculos.Domain.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CadastroVeiculos.Service.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : BaseEntity
    {
        private readonly IBaseRepository<TEntity> _baseRepository;

        public BaseService(IBaseRepository<TEntity> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public TEntity Add<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>
        {
            Validate(obj, Activator.CreateInstance<TValidator>());
            _baseRepository.Insert(obj);
            return obj;
        }

        public TEntity Update<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>
        {
            Validate(obj, Activator.CreateInstance<TValidator>());
            _baseRepository.Update(obj);
            return obj;
        }

        public void Delete(int id) => _baseRepository.Delete(id);

        public void Delete(string id) => _baseRepository.Delete(id);

        public void Delete(TEntity obj) => _baseRepository.Delete(obj);

        public IList<TEntity> Get() => _baseRepository.Select();

        public TEntity GetById(int id) => _baseRepository.Select(id);

        public TEntity GetById(string id) => _baseRepository.Select(id);

        public TEntity ObterPorCondicao(Expression<Func<TEntity, bool>> predicate)
        {
            return _baseRepository.ObterPorCondicao(predicate);
        }

        private void Validate(TEntity obj, AbstractValidator<TEntity> validator)
        {
            if (obj == null)
                throw new Exception("Registros não detectados!");

            validator.ValidateAndThrow(obj);
        }
    }
}
