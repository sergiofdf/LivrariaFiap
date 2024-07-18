
namespace LivrariaFiap.Domain.Entities
{
    public sealed class Livro : EntityBase
    {
        public string Nome { get; set; }
        public string Autor { get; set; }
        public string Editora { get; set; }
        public string Tema { get; set; }
        public double Preco { get; set; }

        public ICollection<ItemPedido> ItemsPedido { get; set; }

    }
}
