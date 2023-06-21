using BasicBank.Domain.Entities;
using BasicBank.Domain.Repositories;
using BasicBank.Repository.EF;
using BasicBank.Repository.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace BasicBank.Repository.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(EFContext context) : base(context)
        {
        }

        public IQueryable<User> GetAll()
            => _context.Users.Include(u => u.Accounts);
    }
}
