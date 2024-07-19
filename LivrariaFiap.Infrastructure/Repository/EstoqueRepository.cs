using LivrariaFiap.Domain.Abstractions;
using LivrariaFiap.Domain.Entities;

namespace LivrariaFiap.Infrastructure.Repository
{
    public class EstoqueRepository : EFRepository<Estoque>, IEstoqueRepository
    {
        public EstoqueRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
