namespace LivrariaFiap.Domain.Entities
{
    public class Endereco : EntityBase
    {
        public string Rua { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }
        public string Pais { get; set; }

    }
}
