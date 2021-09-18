using NSubstitute;
using SerieFlix.Domain.Contracts.DomainServices;
using SerieFlix.Domain.Contracts.RepositoryServices;
using SerieFlix.Domain.Entities;
using SerieFlix.Repositories.Repository;
using System;
using Xunit;

namespace SerieFlix.Tests.NSubstitue
{
    public class UnitTest1
    {
        [Fact]
        public async void Test1()
        {
            var serieMoq = new Serie(genero: Genero.Comedia, titulo: string.Empty, descricao: "Comédia no sertão nordestino.", ano: 2004, excluido: false);
            var _baseRepository = Substitute.For<IRepository<Serie>>();
            var _serieServices = Substitute.For<ISerieDomainServices>();

            var response = await _serieServices.Adicionar(serieMoq);

            Assert.False(response.Ok);
        }
    }
}
