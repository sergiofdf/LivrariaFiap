﻿
namespace LivrariaFiap.Domain.Entities
{
    public class Cliente : EntityBase
    {
        public string Nome { get; set; }
        public string Email { get; set; }

        public Endereco Endereco { get; set; }
        public Telefone Telefone { get; set; }
        public ICollection<Pedido> Pedidos { get; set; }
    }
}