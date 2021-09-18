using SerieFlix.Domain.Contracts.RepositoryServices;
using SerieFlix.Domain.Entities;
using SerieFlix.Repositories.Repository;
using SerieFlix.Repository.Context;
using SerieFlix.Tests.MockData;
using SerieFlix.Tests.MockData.Repository;
using System.Linq;
using Xunit;

namespace SerieFlix.Tests.Units.Repositories
{
    public class SerieRepositoryTests
    {
        #region [Properties]

        protected readonly SerieFlixContext _serieFlixDbContext;
        protected readonly IRepository<Serie> _serieRepository;

        #endregion

        #region [Constructors]

        public SerieRepositoryTests()
        {
            this._serieFlixDbContext = DbContextMock.GetContext();
            this._serieRepository = new RepositoryBase<Serie>(this._serieFlixDbContext);
        }

        #endregion

        

        #region [Consultas]

        [Fact(DisplayName = "Consultar por Id, deve retornar uma único registro.")]
        [Trait("Cetegory", "Consultar")]
        public async void Consultar_porId_RetornaUnicoRegistro()
        {
            //Arrange
            

            //Act
            var serie = await this._serieRepository.Consultar(1);

            //Assert
            Assert.NotNull(serie);
        }

        [Fact(DisplayName = "Consultar todos objetos, deve retornar 20 registros.")]
        [Trait("Cetegory", "Consultar")]
        public async void Consultar_TodosObjetos_DeveRetornar20Registros()
        {
            //Arrange
            

            //Act
            var series = await this._serieRepository.Consultar();

            //Assert
            Assert.True(series.Count > 0);
        }

        #endregion

        #region [Adicionar]

        [Theory(DisplayName = "Adicionar nova série.")]
        [Trait("Cetegory", "Adicionar")]
        [ClassData(typeof(SerieObjetoValidoMock))]
        public async void Adicionar_Test(Serie serie)
        {
            //Arrange

            //Act
            await this._serieRepository.Adicionar(serie);

            var registroSalvo = (await this._serieRepository.Consultar()).Last();

            //Assert
            Assert.Equal(serie.Id, registroSalvo.Id);
        }


        #endregion

        #region [Editar]

        [Fact(DisplayName = "Editar série.")]
        [Trait("Cetegory", "Editar")]
        public async void Editar_Test()
        {
            //Arrange
            var serie = (await this._serieRepository.Consultar()).Last();
            string descricao = "Descricao de série alterado";
            serie.Descricao = descricao;

            //Act
            await this._serieRepository.Atualizar(serie);

            var registroSalvo = await this._serieRepository.Consultar(serie.Id);

            //Assert
            Assert.Equal(registroSalvo.Descricao, descricao);
        }

        #endregion

        #region [Excluir]

        [Fact(DisplayName = "Excluir série.")]
        [Trait("Cetegory", "Excluir")]
        public async void Excluir_Test()
        {
            //Arrange
            var serie = (await this._serieRepository.Consultar()).Last();

            //Act
            await this._serieRepository.Excluir(serie.Id);

            var registroRemovido = await this._serieRepository.Consultar(serie.Id);

            //Assert
            Assert.Null(registroRemovido);
        }
        
        [Fact(DisplayName = "Excluir série que não existe.")]
        [Trait("Cetegory", "Excluir")]
        public async void Excluir_SerieInexistente_DeveRetornarFalse()
        {
            //Arrange
            var serie = (await this._serieRepository.Consultar()).Last();

            //Act
            var retorno = await this._serieRepository.Excluir(serie.Id+1);

            //Assert
            Assert.False(retorno);
        }

        #endregion

    }
}
