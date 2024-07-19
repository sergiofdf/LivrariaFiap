using LivrariaFiap.Api.Models;
using LivrariaFiap.Domain.Entities;

namespace LivrariaFiap.Application.Dtos
{
    public class ClienteDto
    {
        public string Nome { get; set; }
        public string Email { get; set; }

        public EnderecoDto Endereco { get; set; }
        public TelefoneCreateDto Telefone { get; set; }

    }

    public class ClienteResponseDto
    {
        public string Nome { get; set; }
        public string Email { get; set; }

        public EnderecoDto Endereco { get; set; }
        public TelefoneCreateDto Telefone { get; set; }
        public List<PedidoCliente> Pedidos { get; set; } = [];
    }


    public class PedidoCliente
    {
        public double ValorPedido { get; set; }
        public StatusPedido Status { get; set; }
        public ICollection<ItemPedidoResponseDto> ItemsPedido { get; set; }
    }
}