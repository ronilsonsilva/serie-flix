using Newtonsoft.Json;
using SerieFlix.Shared.Verbos;
using SerieFlix.WebApp.Core.Contracts;
using SerieFlix.WebApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace SerieFlix.WebApp.Core.Services
{
    public class SerieServices : ISerieServices
    {
        #region [Properties]

        private string _urlBaseSerieFlix = "https://serieflixapi.azurewebsites.net/api";
        private readonly HttpClient _client;

        public SerieServices(HttpClient client)
        {
            _client = client;
        }

        #endregion


        public async Task<Response<SerieViewModel>> Adicionar(SerieViewModel serie)
        {
            //var client = new RestClient(_urlBaseSerieFlix+"/Series");
            //client.Timeout = -1;
            //var request = new RestRequest(Method.POST);
            //request.AddHeader("Content-Type", "application/json");
            //var body = JsonConvert.SerializeObject(serie);
            //request.AddParameter("application/json", body, ParameterType.RequestBody);
            //IRestResponse response = await client.ExecuteAsync(request);
            //return JsonConvert.DeserializeObject<Response<SerieViewModel>>(response.Content);
            throw new NotImplementedException();
        }

        public async Task<SerieViewModel> Consultar(int id)
        {
            //var client = new RestClient(_urlBaseSerieFlix + $"/Series/{id}");
            //client.Timeout = -1;
            //var request = new RestRequest(Method.GET);
            //IRestResponse response = await client.ExecuteAsync(request);
            //if (response.StatusCode == System.Net.HttpStatusCode.OK)
            //    return JsonConvert.DeserializeObject<SerieViewModel>(response.Content);
            //return null;
            throw new NotImplementedException();
        }

        public async Task<Response<SerieViewModel>> Editar(SerieViewModel serie)
        {
            //var client = new RestClient(_urlBaseSerieFlix+"/Series");
            //client.Timeout = -1;
            //var request = new RestRequest(Method.PUT);
            //request.AddHeader("Content-Type", "application/json");
            //var body = JsonConvert.SerializeObject(serie);
            //request.AddParameter("application/json", body, ParameterType.RequestBody);
            //IRestResponse response = await client.ExecuteAsync(request);
            //return JsonConvert.DeserializeObject<Response<SerieViewModel>>(response.Content);
            throw new NotImplementedException();
        }

        public async Task<Response<bool>> Excluir(int id)
        {
            //var client = new RestClient(_urlBaseSerieFlix+$"/Series/{id}");
            //client.Timeout = -1;
            //var request = new RestRequest(Method.DELETE);
            //IRestResponse response = await client.ExecuteAsync(request);
            //return JsonConvert.DeserializeObject<Response<bool>>(response.Content);
            throw new NotImplementedException();
        }
        
        public async Task<List<SerieViewModel>> Listar()
        {
            try
            {
                var response = await this._client.GetAsync(_urlBaseSerieFlix + "/Series");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    return JsonConvert.DeserializeObject<List<SerieViewModel>>(responseBody);
                return new List<SerieViewModel>();
            }
            catch (System.Exception e)
            {

                throw;
            }
            
        }
    }
}
