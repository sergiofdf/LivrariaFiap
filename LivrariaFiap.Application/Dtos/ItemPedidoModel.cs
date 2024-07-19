namespace LivrariaFiap.Application.Dtos
{
    public class ItemPedidoResponseModel
    {
        public int Quantidade { get; set; }
        public double PrecoTotalItem { get; set; }
        public LivroDto Livro { get; set; }
    }
}
