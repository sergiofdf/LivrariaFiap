using LivrariaFiap.Domain.Entities;

namespace LivrariaFiap.Domain.Abstractions
{
    public interface IPedidoRepository : IRepository<Pedido>
    {
        Pedido? ObterPorIdComItens(int id);
        List<Pedido>? ObterPedidosCliente(int idCliente);
    }
}
