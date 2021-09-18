using Microsoft.AspNetCore.Http;
using SerieFlix.Domain.Contracts.DomainServices;
using SerieFlix.Domain.Contracts.RepositoryServices;
using SerieFlix.Domain.DomainServices;
using SerieFlix.Domain.Entities;
using SerieFlix.Repositories.Repository;
using SerieFlix.Repository.Context;
using SerieFlix.ServicesApi.Controllers;
using SerieFlix.Tests.MockData;
using SerieFlix.Tests.MockData.Repository;
using System.Net;
using Xunit;

namespace SerieFlix.Tests.Units.Controllers
{
    public class SerieControllersTests
    {
        #region [Arrage]

        protected readonly SerieFlixContext _serieFlixDbContext;
        protected readonly IRepository<Serie> _serieRepository;
        protected readonly ISerieDomainServices _serieDomainServices;
        protected readonly SeriesController _seriesController;

        #endregion

        #region [Constructors]

        public SerieControllersTests()
        {
            this._serieFlixDbContext = DbContextMock.GetContext();
            this._serieRepository = new RepositoryBase<Serie>(this._serieFlixDbContext);
            this._serieDomainServices = new SerieDomainServices(this._serieRepository);
            
            this._seriesController = new SeriesController(this._serieDomainServices);
            this._seriesController.ControllerContext = new Microsoft.AspNetCore.Mvc.ControllerContext();
            this._seriesController.ControllerContext.HttpContext = new DefaultHttpContext();
        }

        #endregion

        #region [Adicionar]

        [Theory(DisplayName = "Séries que deve ser aceito pelo domínio")]
        [Trait(name: "Category", value: "Adicionar")]
        [ClassData(typeof(SerieObjetoValidoMock))]
        public async void Adicionar_ObjetoCompleto_DeveRetornarValido(Serie serieMoq)
        {
            //Arrange

            //Act
            var action = await this._seriesController.Post(serieMoq);

            //Assert
            var createdResult = Assert.IsType<Microsoft.AspNetCore.Mvc.CreatedResult>(action);
            Assert.Equal((int)HttpStatusCode.Created, createdResult.StatusCode);
            var domainResponse = Assert.IsType<SerieFlix.Shared.Verbos.Response<Serie>>(createdResult.Value);
            Assert.True(domainResponse.Ok);
        }

        [Theory(DisplayName = "Séries com títulos inválidos: valor null ou vazio, maior que 512 caracteres.")]
        [Trait(name: "Category", value: "Adicionar")]
        [ClassData(typeof(SerieComTituloInvalidoMock))]
        public async void Adicionar_ComtituloInvalido_DevePararNaValidacao(Serie serieMoq)
        {
            //Arrange

            //Act
            var action = await this._seriesController.Post(serieMoq);

            //Assert
            var badRequest = Assert.IsType<Microsoft.AspNetCore.Mvc.BadRequestObjectResult>(action);
            Assert.Equal((int)HttpStatusCode.BadRequest, badRequest.StatusCode);
            var domainResponse = Assert.IsType<SerieFlix.Shared.Verbos.Response<Serie>>(badRequest.Value);
            Assert.False(domainResponse.Ok);
        }

        [Theory(DisplayName = "Séries com anos inválido, não deve passar pela camada de validação de domínio.")]
        [Trait(name: "Category", value: "Adicionar")]
        [ClassData(typeof(SerieComAnoInvalidosMock))]
        public async void Adicionar_ComAnoInvalido_DeveRetornarInvalido(Serie serieMoq)
        {
            //Arrange

            //Act
            var action = await this._seriesController.Post(serieMoq);

            //Assert
            var badRequest = Assert.IsType<Microsoft.AspNetCore.Mvc.BadRequestObjectResult>(action);
            Assert.Equal((int)HttpStatusCode.BadRequest, badRequest.StatusCode);
            var domainResponse = Assert.IsType<SerieFlix.Shared.Verbos.Response<Serie>>(badRequest.Value);
            Assert.False(domainResponse.Ok);
        }

        #endregion

        #region [Editar]

        [Theory(DisplayName = "Séries com títulos inválidos: valor null ou vazio, maior que 512 caracteres.")]
        [Trait(name: "Category", value: "Editar")]
        [ClassData(typeof(SerieComTituloInvalidoMock))]
        public async void Editar_ComtituloInvalido_DevePararNaValidacao(Serie serieMoq)
        {
            //Arrange

            //Act
            var action = await this._seriesController.Put(serieMoq);

            //Assert
            var badRequest = Assert.IsType<Microsoft.AspNetCore.Mvc.BadRequestObjectResult>(action);
            Assert.Equal((int)HttpStatusCode.BadRequest, badRequest.StatusCode);
            var domainResponse = Assert.IsType<SerieFlix.Shared.Verbos.Response<Serie>>(badRequest.Value);
            Assert.False(domainResponse.Ok);
        }

        [Theory(DisplayName = "Séries com ano inválido, não deve passar pela camada de validação de domínio.")]
        [Trait(name: "Category", value: "Editar")]
        [ClassData(typeof(SerieComAnoInvalidosMock))]
        public async void Editar_ComAnoInvalido_DeveRetornarInvalido(Serie serieMoq)
        {
            //Arrange

            //Act
            var action = await this._seriesController.Put(serieMoq);

            //Assert
            var badRequest = Assert.IsType<Microsoft.AspNetCore.Mvc.BadRequestObjectResult>(action);
            Assert.Equal((int)HttpStatusCode.BadRequest, badRequest.StatusCode);
            var domainResponse = Assert.IsType<SerieFlix.Shared.Verbos.Response<Serie>>(badRequest.Value);
            Assert.False(domainResponse.Ok);
        }

        [Theory(DisplayName = "Séries que deve ser aceito pelo domínio")]
        [Trait(name: "Category", value: "Editar")]
        [ClassData(typeof(SerieObjetoValidoMock))]
        public async void Editar_ObjetoCompleto_DeveRetornarValido(Serie serieMoq)
        {
            //Arrange
            serieMoq.Id = 1;
            //Act
            var action = await this._seriesController.Put(serieMoq);

            //Assert
            var okResult = Assert.IsType<Microsoft.AspNetCore.Mvc.OkObjectResult>(action);
            Assert.Equal((int)HttpStatusCode.OK, okResult.StatusCode);
            var domainResponse = Assert.IsType<SerieFlix.Shared.Verbos.Response<Serie>>(okResult.Value);
            Assert.True(domainResponse.Ok);
        }

        #endregion
    }
}
