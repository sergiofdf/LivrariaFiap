﻿namespace LivrariaFiap.Domain.Entities
{
    public class ItemPedido : EntityBase
    {
        public int Quantidade { get; set; }
        public double PrecoTotalItem { get; set; }

        public int PedidoId { get; set; }
        public int LivroId { get; set; }
        public Pedido Pedido { get; set; }
        public Livro Livro { get; set; }
    }
}
