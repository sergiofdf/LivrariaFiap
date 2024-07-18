namespace LivrariaFiap.Api.Models
{
    public class ClienteModel
    {
        public string Nome { get; set; }
        public string Email { get; set; }

        public EnderecoModel Endereco { get; set; }
        public TelefoneCreateModel Telefone { get; set; }
    }
}
