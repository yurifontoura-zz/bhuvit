namespace BasicBank.Domain.Entities
{
    public class Account : BaseEntity
    {
        protected const decimal MAX_DEPOSIT = 10000M;
        protected const decimal MIN_BALANCE = 100M;
        protected const decimal MAX_WITHDRAW_PERCENT = 0.9M;

        public Account() { }
        public Account(User user)
        {
            User = user;
            Balance = 0;
        }

        public string? Name { get; set; }
        public decimal Balance { get; protected set; }

        public Guid UserID { get; set; }
        public User? User { get; set; }

        /// <summary>
        /// Responsible to deposit process.
        /// </summary>
        /// <param name="amount">Amount to be deposited.</param>
        /// <returns>The balance after the deposit.</returns>
        /// <exception cref="BusinessException">If the provided amount was not between 1 and 10000, a BusinessException will be thrown.</exception>
        public decimal Deposit(decimal amount)
        {
            if (amount < 0 || amount > MAX_DEPOSIT) throw new BusinessException($"The provided amount ({amount}) must be between 1 and {MAX_DEPOSIT}.");

            return Balance += amount;
        }

        /// <summary>
        /// Responsible to withdraw process.
        /// </summary>
        /// <param name="amount">Required amount to be withdrawal.</param>
        /// <returns>The balance after the withdraw.</returns>
        /// <exception cref="BusinessException">If final balance would be less than 100 or more than 90% of total value.</exception>
        public decimal Withdraw(decimal amount)
        {
            if (amount < 0) throw new BusinessException("Invalid provided amount to withdraw.");

            decimal maxWithdraw = Balance - amount;
            if (maxWithdraw < MIN_BALANCE) throw new BusinessException($"You can not have less than ${MIN_BALANCE}, you have now {Balance}. Max withdraw value allowed: {(Balance - MIN_BALANCE).Positive()}.");

            maxWithdraw = Balance * MAX_WITHDRAW_PERCENT;
            if (amount > maxWithdraw) throw new BusinessException($"Max withraw value allowed: {maxWithdraw}");

            return Balance -= amount;
        }
    }
}
