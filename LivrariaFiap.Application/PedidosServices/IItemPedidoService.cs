using LivrariaFiap.Application.Dtos;

namespace LivrariaFiap.Application.PedidosServices
{
    public interface IItemPedidoService
    {
        Task<List<ItemPedidoResponseDto>> ObterTodos();
        Task<ItemPedidoResponseDto>? ObterPorId(int id);
        Task Cadastrar(ItemPedidoDto dto);
        Task Alterar(int id, ItemPedidoDto dto);
        Task Deletar(int id);
    }
}
