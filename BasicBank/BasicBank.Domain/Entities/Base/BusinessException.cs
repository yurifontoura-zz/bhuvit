namespace BasicBank.Domain.Entities
{
    public class BusinessException : Exception
    {
        public BusinessException()
        {
        }

        public BusinessException(string? message) : base(message)
        {
        }
    }
}
