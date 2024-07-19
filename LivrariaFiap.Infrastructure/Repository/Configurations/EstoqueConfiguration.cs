using LivrariaFiap.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LivrariaFiap.Infrastructure.Repository.Configurations
{
    public class EstoqueConfiguration : IEntityTypeConfiguration<Estoque>
    {
        public void Configure(EntityTypeBuilder<Estoque> builder)
        {
            builder.ToTable("Estoque");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.DataCriacao).HasColumnType("timestamp").IsRequired();
            builder.Property(p => p.Quantidade).HasColumnType("SMALLINT");
            builder.HasOne(e => e.Livro).WithOne().HasForeignKey<Estoque>(e => e.LivroId);
        }
    }
}
