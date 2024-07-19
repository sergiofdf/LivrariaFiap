using LivrariaFiap.Api.Models;
using LivrariaFiap.Domain.Entities;

namespace LivrariaFiap.Application.Dtos
{
    public class ClienteModel
    {
        public string Nome { get; set; }
        public string Email { get; set; }

        public EnderecoModel Endereco { get; set; }
        public TelefoneCreateModel Telefone { get; set; }

    }

    public class ClienteResponseModel
    {
        public string Nome { get; set; }
        public string Email { get; set; }

        public EnderecoModel Endereco { get; set; }
        public TelefoneCreateModel Telefone { get; set; }
        public List<PedidoCliente> Pedidos { get; set; } = [];
    }


    public class PedidoCliente
    {
        public double ValorPedido { get; set; }
        public StatusPedido Status { get; set; }
        public ICollection<ItemPedidoResponseModel> ItemsPedido { get; set; }
    }
}