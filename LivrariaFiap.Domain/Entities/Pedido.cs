namespace LivrariaFiap.Domain.Entities
{
    public class Pedido : EntityBase
    {
        public double ValorPedido { get; set; }
        public StatusPedido Status { get; set; }
        public ICollection<ItemPedido> ItemsPedido { get; set; } = [];
        public Cliente Cliente { get; set; }

    }

    public enum StatusPedido
    {
        Iniciado = 0,
        AguardandoPagamento = 1,
        Aprovado = 2,
        Rejeitado = 3,
        Cancelado = 4
    }
}
