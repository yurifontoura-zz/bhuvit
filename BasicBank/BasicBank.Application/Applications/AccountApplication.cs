using BasicBank.Application.Interface.Applications;
using BasicBank.Application.Interface.DTO;
using BasicBank.Domain.Entities;
using BasicBank.Domain.Repositories;

namespace BasicBank.Application.Applications
{
    public class AccountApplication : IAccountApplication
    {
        protected IAccountRepository _accountRepository;
        protected IUserRepository _userRepository;

        public AccountApplication(IAccountRepository accountRepository, IUserRepository userRepository)
        {
            _accountRepository = accountRepository;
            _userRepository = userRepository;
        }

        public TypedEnvelope<Account> AddAccount(Account account)
        {
            TypedEnvelope<Account> envelope = new();

            try
            {
                if (!_userRepository.List().Any(u => u.ID == account.UserID))
                    throw new BusinessException("The account must have a registered user to be added.");

                account = _accountRepository.Add(account);
                _accountRepository.Commit();

                envelope.SetSuccess(account);
            }
            catch (BusinessException bex)
            {
                envelope.Success = false;
                envelope.Message = $"Business error caught: {bex.Message}";
            }
            catch (Exception ex)
            {
                envelope.Success = false;
                envelope.Message = $"Unexpected error caught: {ex.Message}";
            }

            return envelope;
        }

        public TypedEnvelope<Account> Deposit(Guid id, decimal  amount)
        {
            TypedEnvelope<Account> envelope = new();
            try
            {
                Account? account = _accountRepository.List().Where(a => a.ID == id).FirstOrDefault();
                if (account == null) throw new BusinessException("Account not found.");

                account.Deposit(amount);
                account = _accountRepository.Update(account);
                _accountRepository.Commit();

                envelope.SetSuccess(account);
            }
            catch (BusinessException bex)
            {
                envelope.Success = false;
                envelope.Message = $"Business error caught: {bex.Message}";
            }
            catch (Exception ex)
            {
                envelope.Success = false;
                envelope.Message = $"Unexpected error caught: {ex.Message}";
            }

            return envelope;
        }

        public TypedEnvelope<Account> Withdraw(Guid id, decimal amount)
        {
            TypedEnvelope<Account> envelope = new();
            try
            {
                Account? account = _accountRepository.List().Where(a => a.ID == id).FirstOrDefault() ?? throw new BusinessException("Account not found.");

                account.Withdraw(amount);
                account = _accountRepository.Update(account);
                _accountRepository.Commit();

                envelope.SetSuccess(account);
            }
            catch (BusinessException bex)
            {
                envelope.Success = false;
                envelope.Message = $"Business error caught: {bex.Message}";
            }
            catch (Exception ex)
            {
                envelope.Success = false;
                envelope.Message = $"Unexpected error caught: {ex.Message}";
            }

            return envelope;
        }

        public Envelope DeleteAccount(Guid id)
        {
            Envelope envelope = new();

            try
            {
                Account? account = _accountRepository.List().Where(account => account.ID == id).FirstOrDefault() ?? throw new BusinessException("Account not found.");

                _accountRepository.Delete(account);
                _accountRepository.Commit();

                envelope.SetSuccess();
            }
            catch (BusinessException bex)
            {
                envelope.Success = false;
                envelope.Message = $"Business error caught: {bex.Message}";
            }
            catch (Exception ex)
            {
                envelope.Success = false;
                envelope.Message = $"Unexpected error caught: {ex.Message}";
            }

            return envelope;
        }
    }
}
