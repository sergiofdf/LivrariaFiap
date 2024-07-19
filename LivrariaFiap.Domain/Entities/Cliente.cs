
using System.ComponentModel.DataAnnotations.Schema;

namespace LivrariaFiap.Domain.Entities
{
    public class Cliente : EntityBase
    {
        public string Nome { get; set; }
        public string Email { get; set; }

        public Endereco Endereco { get; set; }
        public Telefone Telefone { get; set; }
        [NotMapped]
        public ICollection<Pedido> Pedidos { get; set; } = [];
    }
}