namespace CleanMVC.Domain.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; protected set; }

        public BaseEntity(int id)
        {
            Id = id;
        }

        public BaseEntity()
        {

        }
    }
}
