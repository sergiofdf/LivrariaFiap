namespace LivrariaFiap.Application.Dtos
{
    public class EstoqueDto
    {
        public int Quantidade { get; set; }

        public int LivroId { get; set; }
    }

    public class EstoqueResponseDto
    {
        public int IdEstoque { get; set; }
        public DateTime DataCriacao { get; set; }
        public int Quantidade { get; set; }
        public int LivroId { get; set; }

    }
}
