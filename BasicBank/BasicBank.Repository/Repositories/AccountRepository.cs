using BasicBank.Domain.Entities;
using BasicBank.Domain.Repositories;
using BasicBank.Repository.EF;
using BasicBank.Repository.Repositories.Base;

namespace BasicBank.Repository.Repositories
{
    public class AccountRepository : BaseRepository<Account>, IAccountRepository
    {
        public AccountRepository(EFContext context) : base(context)
        {
        }
    }
}
