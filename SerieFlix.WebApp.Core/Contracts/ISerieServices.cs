using SerieFlix.Shared.Verbos;
using SerieFlix.WebApp.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SerieFlix.WebApp.Core.Contracts
{
    public interface ISerieServices
    {
        Task<List<SerieViewModel>> Listar();
        Task<SerieViewModel> Consultar(int id);
        Task<Response<SerieViewModel>> Adicionar(SerieViewModel serie);
        Task<Response<SerieViewModel>> Editar(SerieViewModel serie);
        Task<Response<bool>> Excluir(int id);
    }
}
