using LivrariaFiap.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LivrariaFiap.Infrastructure.Repository.Configurations
{
    public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("Pedido");
            builder.HasKey(p => p.Id);
            //builder.Property(p => p.Id).HasColumnType("Integer").ValueGeneratedNever().UseIdentityColumn();
            builder.Property(p => p.DataCriacao).HasColumnType("timestamp").IsRequired();
            builder.Property(p => p.ValorPedido).HasColumnType("NUMERIC(8,2)");
            builder.Property(p => p.Status).HasColumnType("SMALLINT").IsRequired();

            builder.HasOne(p => p.Cliente).WithMany(c => c.Pedidos).HasPrincipalKey(c => c.Id);
        }
    }
}
