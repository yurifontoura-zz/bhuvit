using BasicBank.Application.Interface.DTO;
using BasicBank.Domain.Entities;

namespace BasicBank.Application.Interface.Applications
{
    public interface IUserApplication
    {
        TypedEnvelope<User> AddOrUpdateUser(User user);
        TypedEnvelope<User> GetUserByID(Guid id);
        TypedEnvelope<List<User>> GetAll();
    }
}
