using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SerieFlix.Domain.Contracts.DomainServices;
using SerieFlix.Domain.Contracts.RepositoryServices;
using SerieFlix.Domain.DomainServices;
using SerieFlix.Repositories.Repository;
using SerieFlix.Repository.Context;
using System;

namespace SerieFlix.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Configurando aplicação...");

            #region [Configuração da DI]
            
            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .AddDbContext<SerieFlixContext, SerieFlixContext>(op => op.UseInMemoryDatabase(databaseName: "serieflix"))
                .AddSingleton(typeof(IDomainServices<>), typeof(DomainServices<>))
                .AddSingleton(typeof(IRepository<>), typeof(RepositoryBase<>))
                .AddSingleton<ISerieDomainServices, SerieDomainServices>()
                .BuildServiceProvider();

            #endregion

            new Application(serviceProvider).Run();
        }
    }

    class Application
    {
        protected IServiceProvider _services;

        public Application(IServiceProvider services)
        {
            this._services = services;
        }

        public Application Run()
        {
            return this;
        }
    }
}
