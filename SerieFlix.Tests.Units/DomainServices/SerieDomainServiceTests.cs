using Moq;
using SerieFlix.Domain.Contracts.DomainServices;
using SerieFlix.Domain.Contracts.RepositoryServices;
using SerieFlix.Domain.DomainServices;
using SerieFlix.Domain.Entities;
using SerieFlix.Repositories.Repository;
using SerieFlix.Repository.Context;
using SerieFlix.Tests.MockData;
using SerieFlix.Tests.MockData.Repository;
using Xunit;

namespace SerieFlix.Tests.Units.DomainServices
{
    public class SerieDomainServiceTests
    {
        #region [Properties]

        protected readonly SerieFlixContext _serieFlixDbContext;
        protected readonly IRepository<Serie> _serieRepository;
        protected readonly ISerieDomainServices _serieDomainServices;

        #endregion

        public SerieDomainServiceTests()
        {
            this._serieFlixDbContext = DbContextMock.GetContext();
            this._serieRepository = new RepositoryBase<Serie>(this._serieFlixDbContext);
            this._serieDomainServices = new SerieDomainServices(this._serieRepository);
        }


        #region [Adicionar]

        [Theory(DisplayName = "Séries com títulos inválidos: valor null ou vazio, maior que 512 caracteres.")]
        [Trait(name: "Category", value: "Adicionar")]
        [ClassData(typeof(SerieComTituloInvalidoMock))]
        public async void Adicionar_ComtituloInvalido_DevePararNaValidacao(Serie serieMoq)
        {
            //Arrange
            

            //Act
            var domainResponse = await this._serieDomainServices.Adicionar(serieMoq);

            //Assert
            Assert.False(domainResponse.Ok);
        }

        [Theory(DisplayName = "Séries com anos inválido, não deve passar pela camada de validação de domínio.")]
        [Trait(name: "Category", value: "Adicionar")]
        [ClassData(typeof(SerieComAnoInvalidosMock))]
        public async void Adicionar_ComAnoInvalido_DeveRetornarInvalido(Serie serieMoq)
        {
            //Arrange

            //Act
            var domainResponse = await this._serieDomainServices.Adicionar(serieMoq);

            //Assert
            Assert.False(domainResponse.Ok);
        }

        [Theory(DisplayName = "Séries que deve ser aceito pelo domínio")]
        [Trait(name: "Category", value: "Adicionar")]
        [ClassData(typeof(SerieObjetoValidoMock))]
        public async void Adicionar_ObjetoCompleto_DeveRetornarValido(Serie serieMoq)
        {
            //Arrange

            //Act
            var domainResponse = await this._serieDomainServices.Adicionar(serieMoq);

            //Assert
            Assert.True(domainResponse.Ok);
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
            var domainResponse = await this._serieDomainServices.Adicionar(serieMoq);

            //Assert
            Assert.False(domainResponse.Ok);
        }

        [Theory(DisplayName = "Séries com anos inválido, não deve passar pela camada de validação de domínio.")]
        [Trait(name: "Category", value: "Editar")]
        [ClassData(typeof(SerieComAnoInvalidosMock))]
        public async void Editar_ComAnoInvalido_DeveRetornarInvalido(Serie serieMoq)
        {
            //Arrange
            
            //Act
            var domainResponse = await this._serieDomainServices.Adicionar(serieMoq);

            //Assert
            Assert.False(domainResponse.Ok);
        }

        [Theory(DisplayName = "Séries que deve ser aceito pelo domínio")]
        [Trait(name: "Category", value: "Editar")]
        [ClassData(typeof(SerieObjetoValidoMock))]
        public async void Editar_ObjetoCompleto_DeveRetornarValido(Serie serieMoq)
        {
            //Arrange
            
            //Act
            var domainResponse = await this._serieDomainServices.Adicionar(serieMoq);

            //Assert
            Assert.True(domainResponse.Ok);
        }

        #endregion


    }
}
