using Catalogo.Api.Entidade;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalogo.Api.EntityFramework.Configuration
{
    public class FilmeConfig : IEntityTypeConfiguration<Filme>
    {
        public void Configure(EntityTypeBuilder<Filme> builder)
        {
            builder.ToTable("Filmes");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Titulo).HasMaxLength(30).IsRequired();
            builder.Property(x => x.Descricao).HasMaxLength(4000).IsRequired();
            builder.Property(x => x.Ano).IsRequired();
            builder.Property(x => x.Nota).IsRequired();
            builder.Property(x => x.UrlImagem).HasMaxLength(4000);
            builder.HasOne(x => x.Categoria).WithMany(x => x.Filmes).HasForeignKey(x => x.CategoriaId);
            builder.HasIndex(x => x.CategoriaId).HasName("IX_FILME_CATEGORIA");
        }
    }
}