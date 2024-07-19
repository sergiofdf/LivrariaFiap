namespace LivrariaFiap.Application.Dtos
{
    public class LivroDto
    {
        public string Nome { get; set; }
        public string Autor { get; set; }
        public string Editora { get; set; }
        public string Tema { get; set; }
        public double Preco { get; set; }
    }

    public class LivroResponseDto
    {
        public int Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public string Nome { get; set; }
        public string Autor { get; set; }
        public string Editora { get; set; }
        public string Tema { get; set; }
        public double Preco { get; set; }
    }
}
