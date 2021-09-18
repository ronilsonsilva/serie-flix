using Microsoft.EntityFrameworkCore;
using SerieFlix.Domain.Contracts.RepositoryServices;
using SerieFlix.Domain.Entities;
using SerieFlix.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SerieFlix.Repositories.Repository
{
    public class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : EntityBase
    {
        protected readonly SerieFlixContext _context;

        public RepositoryBase(SerieFlixContext context)
        {
            _context = context;
        }

        public virtual async Task<TEntity> Adicionar(TEntity entity)
        {
            this._context.Set<TEntity>().Add(entity);
            await this._context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<TEntity> Atualizar(TEntity entity)
        {
            this._context.Entry(entity).State = EntityState.Detached;
            await this._context.SaveChangesAsync();
            return entity;
        }

        public virtual IQueryable<TEntity> Consultar(Expression<Func<TEntity, bool>> expression)
        {
            return this._context.Set<TEntity>().Where(expression).AsQueryable();
        }

        public virtual async Task<TEntity> Consultar(int id)
        {
            var entity = await this.Consultar(x => x.Id == id).FirstOrDefaultAsync();
            return entity;
        }

        public async Task<IList<TEntity>> Consultar()
        {
            return await this._context.Set<TEntity>().ToListAsync();
        }

        public virtual async Task<bool> Excluir(int id)
        {
            var entityRemover = await this.Consultar(id);
            if (entityRemover == null) return false;
            this._context.Set<TEntity>().Remove(entityRemover);
            return (await this._context.SaveChangesAsync()) > 0;
        }
    }
}
