using SerieFlix.WebApp.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SerieFlix.WebApp.Core.Contracts
{
    public interface ISerieServices
    {
        Task<List<SerieViewModel>> Listar();
    }
}
