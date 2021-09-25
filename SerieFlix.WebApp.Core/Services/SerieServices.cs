using SerieFlix.WebApp.Core.Contracts;
using SerieFlix.WebApp.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SerieFlix.WebApp.Core.Services
{
    public class SerieServices : ISerieServices
    {
        public async Task<List<SerieViewModel>> Listar()
        {
            var series = new List<SerieViewModel>();
            for (int i = 0; i < 30; i++)
            {
                series.Add(new SerieViewModel()
                {
                    Ano = 2000+i,
                    Id = i,
                    Descricao = $"Descrição Série {i}",
                    Genero = Genero.Acao,
                    Titulo = $"Série {i}"
                });
            }
            

            return series;
        }
    }
}
