using LivrariaFiap.Domain.Entities;

namespace LivrariaFiap.Application.Dtos
{
    public class PedidoDto
    {
        public double ValorPedido { get; set; }
        public StatusPedido Status { get; set; }
        public ICollection<ItemPedidoDto> ItemsPedido { get; set; } = [];
        public int ClienteId { get; set; }
    }

    public class PedidoResponseDto
    {
        public double ValorPedido { get; set; }
        public StatusPedido Status { get; set; }
        public ICollection<ItemPedido> ItemsPedido { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
