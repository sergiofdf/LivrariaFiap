namespace LivrariaFiap.Domain.Entities
{
    public class Estoque : EntityBase
    {
        public int Quantidade { get; set; }
        public int LivroId { get; set; }

        public Livro Livro { get; set; }

    }
}
