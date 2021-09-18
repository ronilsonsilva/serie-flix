using Microsoft.EntityFrameworkCore;
using SerieFlix.Domain.Entities;
using SerieFlix.Repository.Context;
using System.Collections.Generic;

namespace SerieFlix.Tests.MockData.Repository
{
    public static class DbContextMock
    {
        public static SerieFlixContext GetContext()
        {
            var options = new DbContextOptionsBuilder<SerieFlixContext>()
                .UseInMemoryDatabase(databaseName: "serieflix")
                .Options;
            var dbContextMock = new SerieFlixContext(options);

            PopuleSeries(dbContextMock);

            return dbContextMock;
        }

        private static void PopuleSeries(SerieFlixContext dbContextMock)
        {
            var series = new List<Serie>();

            for (int i = 1; i <= 20; i++)
            {
                series.Add(new Serie(Genero.Acao, $"Titulo {i}", $"Descrição {i}", 2000 + i, false));
            }

            dbContextMock.AddRange(series);
            dbContextMock.SaveChanges();
        }
    }
}
