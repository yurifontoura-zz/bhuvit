using BasicBank.Application.Interface.DTO;
using BasicBank.Domain.Entities;

namespace BasicBank.Application.Interface.Applications
{
    public interface IAccountApplication
    {
        TypedEnvelope<Account> AddAccount(Account account);
        TypedEnvelope<Account> Deposit(Guid id, decimal amount);
        TypedEnvelope<Account> Withdraw(Guid id, decimal amount);
        Envelope DeleteAccount(Guid id);
    }
}
