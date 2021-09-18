using SerieFlix.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SerieFlix.Domain.Contracts.RepositoryServices
{
    public interface IRepository<TEntity> where TEntity : EntityBase 
    {
        Task<TEntity> Adicionar(TEntity entity);
        Task<TEntity> Atualizar(TEntity entity);
        Task<bool> Excluir(int id);
        Task<TEntity> Consultar(int id);
        IQueryable<TEntity> Consultar(Expression<Func<TEntity, bool>> expression);
        Task<IList<TEntity>> Consultar();
    }
}
