using LivrariaFiap.Domain.Abstractions;
using LivrariaFiap.Domain.Entities;

namespace LivrariaFiap.Infrastructure.Repository
{
    public class ItemPedidoRepository : EFRepository<ItemPedido>, IItemPedidoRepository
    {
        public ItemPedidoRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
