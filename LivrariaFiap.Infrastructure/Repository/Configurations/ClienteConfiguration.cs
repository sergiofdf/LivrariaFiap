using LivrariaFiap.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LivrariaFiap.Infrastructure.Repository.Configurations
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente");
            builder.HasKey(p => p.Id);
            //builder.Property(p => p.Id).HasColumnType("Integer").ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(p => p.DataCriacao).HasColumnType("timestamp").IsRequired();
            builder.Property(p => p.Nome).HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(p => p.Email).HasColumnType("VARCHAR(100)").IsRequired();

            builder.OwnsOne(c => c.Endereco, enderecoBuilder =>
            {
                enderecoBuilder.ToTable("Endereco");
                enderecoBuilder.HasKey(p => p.Id);
                //enderecoBuilder.Property(p => p.Id).HasColumnType("Integer").ValueGeneratedNever().UseIdentityColumn();
                enderecoBuilder.Property(p => p.DataCriacao).HasColumnType("timestamp").IsRequired();
                enderecoBuilder.Property(p => p.Rua).HasColumnType("VARCHAR(100)");
                enderecoBuilder.Property(p => p.Cidade).HasColumnType("VARCHAR(100)");
                enderecoBuilder.Property(p => p.Estado).HasColumnType("VARCHAR(2)");
                enderecoBuilder.Property(p => p.Cep).HasColumnType("VARCHAR(9)");
                enderecoBuilder.Property(p => p.Pais).HasColumnType("VARCHAR(100)");
            });
            builder.OwnsOne(c => c.Telefone, telefoneBuilder =>
            {
                telefoneBuilder.ToTable("Telefone");
                telefoneBuilder.HasKey(p => p.Id);
                //telefoneBuilder.Property(p => p.Id).HasColumnType("Integer").ValueGeneratedNever().UseIdentityColumn();
                telefoneBuilder.Property(p => p.DataCriacao).HasColumnType("timestamp").IsRequired();
                telefoneBuilder.Property(p => p.CodigoPais).HasColumnType("VARCHAR(2)").IsRequired();
                telefoneBuilder.Property(p => p.CodigoLocal).HasColumnType("VARCHAR(2)").IsRequired();
                telefoneBuilder.Property(p => p.Numero).HasColumnType("VARCHAR(10)").IsRequired();
            });
        }
    }
}
