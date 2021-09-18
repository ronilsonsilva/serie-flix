﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SerieFlix.Repository.Context;
using Microsoft.EntityFrameworkCore;
using SerieFlix.Domain.DomainServices;
using SerieFlix.Domain.Contracts.DomainServices;
using SerieFlix.Domain.Contracts.RepositoryServices;
using SerieFlix.Repositories.Repository;

namespace SerieFlix.Infra.Ioc
{
    public  class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            #region [Configurations]

            services.AddDbContext<SerieFlixContext>
                (options =>
                    options.UseInMemoryDatabase(databaseName: "seriflix")
                );
            services.AddScoped<SerieFlixContext, SerieFlixContext>();

            #endregion

            #region [DI]

            services.AddScoped(typeof(IDomainServices<>), typeof(DomainServices<>));
            services.AddScoped(typeof(IRepository<>), typeof(RepositoryBase<>));

            services.AddScoped<ISerieDomainServices, SerieDomainServices>();

            #endregion
        }
    }
}
