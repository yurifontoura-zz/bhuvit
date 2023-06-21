namespace BasicBank.Domain.Entities
{
    public class User : BaseEntity
    {
        public User(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public ICollection<Account>? Accounts { get; set; }
    }
}
