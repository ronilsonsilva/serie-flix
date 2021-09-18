using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using SerieFlix.Domain.Entities;
using SerieFlix.ServicesApi;
using SerieFlix.Tests.MockData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace SerieFlix.Tests.Integrations
{
    public class SerieEndpointTests
    {
        #region [Arranges]

        private readonly TestServer _server;
        private readonly HttpClient _client;

        #endregion

        #region [Constructors]

        public SerieEndpointTests()
        {
            _server = new TestServer(
                new WebHostBuilder()
                .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        #endregion

        #region [Adicionar]

        [Theory(DisplayName = "Séries que deve ser aceito pelo domínio")]
        [Trait(name: "Category", value: "Editar")]
        [ClassData(typeof(SerieObjetoValidoMock))]
        public async void Adicionar_SerieValidas_DeveObterStatusCreated(Serie serie)
        {
            //Arrange
            var content = Utils.CreateHttpContent(serie);

            //Act
            var response = await _client.PostAsync("api/series", content);
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();

            //Assert
            Assert.Equal(HttpStatusCode.Created, (HttpStatusCode)response.StatusCode);
        }

        [Theory(DisplayName = "Séries com títulos inválidos: valor null ou vazio, maior que 512 caracteres.")]
        [Trait(name: "Category", value: "Adicionar")]
        [ClassData(typeof(SerieComTituloInvalidoMock))]
        public async void Adicionar_ComtituloInvalido_DeveRetornaBadRequest(Serie serieMoq)
        {
            //Arrange
            var content = Utils.CreateHttpContent(serieMoq);

            //Act
            var response = await _client.PostAsync("api/series", content);
            var responseString = await response.Content.ReadAsStringAsync();

            //Assert
            Assert.Equal(HttpStatusCode.BadRequest, (HttpStatusCode)response.StatusCode);
        }

        [Theory(DisplayName = "Séries com anos inválido, não deve passar pela camada de validação de domínio.")]
        [Trait(name: "Category", value: "Adicionar")]
        [ClassData(typeof(SerieComAnoInvalidosMock))]
        public async void Adicionar_ComAnoInvalido_DeveRetornaBadRequest(Serie serieMoq)
        {
            //Arrange
            var content = Utils.CreateHttpContent(serieMoq);

            //Act
            var response = await _client.PostAsync("api/series", content);
            var responseString = await response.Content.ReadAsStringAsync();

            //Assert
            Assert.Equal(HttpStatusCode.BadRequest, (HttpStatusCode)response.StatusCode);
        }

        #endregion


    }
         
}
