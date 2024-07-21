using LivrariaFiap.Domain.Entities;

namespace LivrariaFiap.Application.Dtos
{
    public class PedidoDto
    {
        public ICollection<CadastroPedidoItemDto> ItemsPedido { get; set; } = [];
        public int ClienteId { get; set; }
    }

    public class PedidoResponseDto
    {
        public double ValorPedido { get; set; }
        public StatusPedido Status { get; set; }
        public ICollection<ItemPedidoResponseDto> ItemsPedido { get; set; } = [];
        public int ClienteId { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
