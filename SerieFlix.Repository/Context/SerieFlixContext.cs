using Microsoft.EntityFrameworkCore;
using SerieFlix.Repository.Context.Mappings;

namespace SerieFlix.Repository.Context
{
    public class SerieFlixContext : DbContext
    {
        public SerieFlixContext() { }

        public SerieFlixContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseInMemoryDatabase(databaseName: "serieflix");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SerieMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
