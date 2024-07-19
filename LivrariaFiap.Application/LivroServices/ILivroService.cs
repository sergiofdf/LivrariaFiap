using LivrariaFiap.Application.Dtos;

namespace LivrariaFiap.Application.LivroServices
{
    public interface ILivroService
    {
        Task<List<LivroResponseDto>> ObterTodos();
        Task<LivroResponseDto>? ObterPorId(int id);
        Task Cadastrar(LivroDto dto);
        Task Alterar(int id, LivroDto dto);
        Task Deletar(int id);
    }
}