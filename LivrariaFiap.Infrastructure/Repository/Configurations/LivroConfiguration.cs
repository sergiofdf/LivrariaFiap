using LivrariaFiap.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LivrariaFiap.Infrastructure.Repository.Configurations
{
    public class LivroConfiguration : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        {
            builder.ToTable("Livro");
            builder.HasKey(p => p.Id);
            //builder.Property(p => p.Id).HasColumnType("Integer").ValueGeneratedNever().UseIdentityColumn();
            builder.Property(p => p.DataCriacao).HasColumnType("timestamp").IsRequired();
            builder.Property(p => p.Nome).HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(p => p.Autor).HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(p => p.Editora).HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(p => p.Tema).HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(p => p.Preco).HasColumnType("NUMERIC(8,2)").IsRequired();
        }
    }
}
