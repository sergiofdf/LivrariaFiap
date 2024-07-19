using LivrariaFiap.Domain.Abstractions;
using LivrariaFiap.Domain.Entities;

namespace LivrariaFiap.Infrastructure.Repository
{
    public class LivroRepository : EFRepository<Livro>, ILivroRepository
    {
        public LivroRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
