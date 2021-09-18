using SerieFlix.Domain.Contracts.DomainServices;
using SerieFlix.Domain.Contracts.RepositoryServices;
using SerieFlix.Domain.Entities;
using System.Threading.Tasks;

namespace SerieFlix.Domain.DomainServices
{
    public class SerieDomainServices : DomainServices<Serie>, ISerieDomainServices
    {
        #region [Properties]

        #endregion

        #region [Constructors]

        public SerieDomainServices(IRepository<Serie> repository) : base(repository)
        {
        }

        #endregion

        #region [Publics Methods]

        public Task<Serie> Proximo(Serie serie)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}
