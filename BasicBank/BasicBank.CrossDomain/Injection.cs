using BasicBank.Domain.Repositories;
using BasicBank.Repository.EF;
using BasicBank.Repository.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BasicBank.CrossDomain
{
    public class Injection
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IAccountRepository, AccountRepository>();
        }

        public static void SetDatabaseContext(IServiceCollection services, string dataBaseName)
        {
            services.AddDbContextFactory<EFContext>(options => options.UseInMemoryDatabase(dataBaseName));
        }
    }
}