using LivrariaFiap.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LivrariaFiap.Infrastructure.Repository.Configurations
{
    public class ItemPedidoConfiguration : IEntityTypeConfiguration<ItemPedido>
    {
        public void Configure(EntityTypeBuilder<ItemPedido> builder)
        {
            builder.ToTable("ItemPedido");
            builder.HasKey(p => p.Id);
            //builder.Property(p => p.Id).HasColumnType("Integer").ValueGeneratedNever().UseIdentityColumn();
            builder.Property(p => p.DataCriacao).HasColumnType("timestamp").IsRequired();
            builder.Property(p => p.Quantidade).HasColumnType("SMALLINT");
            builder.Property(p => p.PrecoTotalItem).HasColumnType("NUMERIC(8,2)");

            builder.HasOne(ip => ip.Pedido).WithMany(p => p.ItemsPedido).HasPrincipalKey(p => p.Id);
            builder.HasOne(ip => ip.Livro).WithMany(l => l.ItemsPedido).HasPrincipalKey(l => l.Id);

        }
    }
}
