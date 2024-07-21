using LivrariaFiap.Domain.Abstractions;
using LivrariaFiap.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LivrariaFiap.Infrastructure.Repository
{
    public class PedidoRepository : EFRepository<Pedido>, IPedidoRepository
    {
        public PedidoRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Pedido? ObterPorIdComItens(int id)
        {
            return _context.Pedido.AsNoTracking()
                .Include(p => p.ItemsPedido)
                .FirstOrDefault(p => p.Id == id);
        }

        public List<Pedido>? ObterPedidosCliente(int idCliente)
        {
            return _context.Pedido.AsNoTracking()
                .Include(p => p.ItemsPedido)
                .Where(p => p.ClienteId == idCliente)
                .ToList();
        }
    }
}
