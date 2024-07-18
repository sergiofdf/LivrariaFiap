namespace LivrariaFiap.Domain.Entities
{
    public abstract class EntityBase
    {
        public int Id { get; init; }
        public DateTime DataCriacao { get; set; }

        public EntityBase()
        {
            DataCriacao = DateTime.Now;
        }
    }
}
