namespace LivrariaFiap.Domain.Entities
{
    public abstract class EntityBase
    {
        public int Id { get; set; }
        public DateTime DataCriacao { get; set; }

        public EntityBase()
        {
            DataCriacao = DateTime.Now;
        }
    }
}
