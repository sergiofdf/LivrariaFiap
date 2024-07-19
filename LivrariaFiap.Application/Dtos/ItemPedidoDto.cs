namespace LivrariaFiap.Application.Dtos
{
    public class ItemPedidoDto
    {
        public int Quantidade { get; set; }
        public int PedidoId { get; set; }
        public int LivroId { get; set; }
    }

    public class ItemPedidoResponseDto
    {
        public int Quantidade { get; set; }
        public double PrecoTotalItem { get; set; }
        public int PedidoId { get; set; }
        public int LivroId { get; set; }
    }
}