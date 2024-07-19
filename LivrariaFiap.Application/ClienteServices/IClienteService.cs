using LivrariaFiap.Application.Dtos;

namespace LivrariaFiap.Application.ClienteServices
{
    public interface IClienteService
    {
        Task<List<ClienteResponseDto>> ObterTodos();
        Task<ClienteResponseDto>? ObterPorId(int id);
        Task Cadastrar(ClienteDto dto);
        Task Alterar(int id, ClienteDto dto);
        Task Deletar(int id);
    }
}
