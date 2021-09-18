using SerieFlix.Domain.Entities;
using SerieFlix.Shared.Verbos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SerieFlix.Domain.Contracts.DomainServices
{
    public interface IDomainServices<TEntity> where TEntity : EntityBase
    {
        Task<Response<TEntity>> Adicionar(TEntity entity);
        Task<Response<TEntity>> Atualizar(TEntity entity);
        Task<Response<bool>> Excluir(int id);
        Task<IList<TEntity>> Consultar();
        Task<TEntity> Consultar(int id);
    }
}
