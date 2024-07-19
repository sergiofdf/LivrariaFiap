using LivrariaFiap.Application.Dtos;

namespace LivrariaFiap.Application.PedidosServices
{
    public interface IPedidoService
    {
        Task<List<PedidoResponseDto>> ObterTodos();
        Task<PedidoResponseDto>? ObterPorId(int id);
        Task Cadastrar(PedidoDto dto);
        Task Alterar(int id, PedidoDto dto);
        Task Deletar(int id);
    }
}