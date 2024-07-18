using LivrariaFiap.Domain.Entities;

namespace LivrariaFiap.Domain.Abstractions
{
    public interface IService<T> where T : EntityBase
    {
        Task<IList<T>> ObterTodos();
        Task<T>? ObterPorId(int id);
        Task Cadastrar(T entidade);
        Task Alterar(T entidade);
        Task Deletar(int id);
    }
}
