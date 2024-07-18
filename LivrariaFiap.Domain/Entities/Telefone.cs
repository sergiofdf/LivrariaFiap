
namespace LivrariaFiap.Domain.Entities
{
    public class Telefone : EntityBase
    {
        public int CodigoPais { get; set; }
        public int CodigoLocal { get; set; }
        public int Numero { get; set; }

    }
}