namespace BasicBank.Domain.Entities
{
    public abstract class BaseEntity
    {
        public Guid ID { get; set; }
        public DateTime Updated { get; set; }

        public BaseEntity()
        {
            ID = Guid.NewGuid();
            Updated = DateTime.Now;
        }
    }
}
