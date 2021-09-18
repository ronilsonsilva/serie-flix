using Microsoft.EntityFrameworkCore;
using SerieFlix.Domain.Contracts.DomainServices;
using SerieFlix.Domain.Contracts.RepositoryServices;
using SerieFlix.Domain.Entities;
using SerieFlix.Shared.Verbos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SerieFlix.Domain.DomainServices
{
    public class DomainServices<TEntity> : IDomainServices<TEntity> where TEntity : EntityBase
    {
        #region [Properties]

        protected readonly IRepository<TEntity> _repository;

        #endregion

        #region [Constructors]

        public DomainServices(IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        #endregion

        #region [Public Methods]

        public async Task<Response<TEntity>> Adicionar(TEntity entity)
        {
            if (entity.Invalid)
                return new Response<TEntity>(entity, entity.Validate());

            return new Response<TEntity>(await this._repository.Adicionar(entity));
        }

        public async Task<Response<TEntity>> Atualizar(TEntity entity)
        {
            if (entity.Invalid)
                return new Response<TEntity>(entity, entity.Validate());

            return new Response<TEntity>(await this._repository.Atualizar(entity));
        }

        public async Task<TEntity> Consultar(int id)
        {
            return await this._repository.Consultar(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IList<TEntity>> Consultar()
        {
            return await this._repository.Consultar();
        }

        public async Task<Response<bool>> Excluir(int id)
        {
            return new Response<bool>(await this._repository.Excluir(id));
        }

        #endregion
    }
}
