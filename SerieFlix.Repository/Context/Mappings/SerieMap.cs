using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SerieFlix.Domain.Entities;

namespace SerieFlix.Repository.Context.Mappings
{
    internal class SerieMap : BaseMap<Serie>
    {
        public SerieMap(string nomeTabela = "serie") : base(nomeTabela)
        {
        }

        public override void Configure(EntityTypeBuilder<Serie> builder)
        {
            builder.Property(x => x.Ano)
                .IsRequired();

            builder.Property(x => x.Descricao)
                .IsRequired();

            builder.Property(x => x.Genero)
                .IsRequired();

            builder.Property(x => x.Titulo)
                .IsRequired();

            base.Configure(builder);
        }
    }
}
