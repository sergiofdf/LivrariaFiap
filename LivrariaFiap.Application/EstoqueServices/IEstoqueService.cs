using LivrariaFiap.Application.Dtos;

namespace LivrariaFiap.Application.EstoqueServices
{
    public interface IEstoqueService
    {
        Task<List<EstoqueResponseDto>> ObterTodos();
        Task<EstoqueResponseDto>? ObterPorId(int id);
        Task Cadastrar(EstoqueDto dto);
        Task Alterar(int id, EstoqueDto dto);
        Task Deletar(int id);
    }
}