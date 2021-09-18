using SerieFlix.Domain.Entities;
using System.Threading.Tasks;

namespace SerieFlix.Domain.Contracts.DomainServices
{
    public interface ISerieDomainServices : IDomainServices<Serie>
    {
        Task<Serie> Proximo(Serie serie);
    }
}
