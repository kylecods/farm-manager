namespace Entities
{
    public class Entity
    {
        public Guid Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public void SetNewId()
        {
            Id = Guid.NewGuid();
        }
    }
}
