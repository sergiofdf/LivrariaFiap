using LivrariaFiap.Domain.Abstractions;
using LivrariaFiap.Domain.Entities;

namespace LivrariaFiap.Infrastructure.Repository
{
    public class TelefoneRepository : EFRepository<Telefone>, ITelefoneRepository
    {
        public TelefoneRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
