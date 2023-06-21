using BasicBank.Domain.Entities;

namespace BasicBank.Domain.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        IQueryable<User> GetAll();
    }
}
