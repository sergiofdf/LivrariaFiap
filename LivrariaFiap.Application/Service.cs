using LivrariaFiap.Domain.Abstractions;
using LivrariaFiap.Domain.Entities;

namespace LivrariaFiap.Application
{
    public class Service<T> : IService<T> where T : EntityBase
    {
        private readonly IRepository<T> _repository;

        public Service(IRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task Alterar(T entidade)
        {
            _repository.Alterar(entidade);
        }

        public async Task Cadastrar(T entidade)
        {
            _repository.Cadastrar(entidade);
        }

        public async Task Deletar(int id)
        {
            _repository.Deletar(id);
        }

        public async Task<T>? ObterPorId(int id) => _repository.ObterPorId(id);

        public async Task<IList<T>> ObterTodos() => _repository.ObterTodos();

    }
}
