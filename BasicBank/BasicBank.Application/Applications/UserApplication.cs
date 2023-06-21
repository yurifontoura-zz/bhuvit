using BasicBank.Application.Interface.Applications;
using BasicBank.Application.Interface.DTO;
using BasicBank.Domain.Entities;
using BasicBank.Domain.Repositories;

namespace BasicBank.Application.Applications
{
    public class UserApplication : IUserApplication
    {
        protected IUserRepository _userRepository;

        public UserApplication(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public TypedEnvelope<User> AddOrUpdateUser(User user)
        {
            TypedEnvelope<User> envelope = new();

            try
            {
                if (!_userRepository.List().Where(u => u.ID == user.ID).Any())
                    user = _userRepository.Add(user);
                else
                    user = _userRepository.Update(user);

                _userRepository.Commit();

                envelope.SetSuccess(user);
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

        public TypedEnvelope<List<User>> GetAll()
        {
            TypedEnvelope<List<User>> envelope = new();

            try
            {
                List<User> users = _userRepository.GetAll().ToList();

                envelope.SetSuccess(users);
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

        public TypedEnvelope<User> GetUserByID(Guid id)
        {
            TypedEnvelope<User> envelope = new();

            try
            {
                User? user = _userRepository.GetAll().Where(u => u.ID == id).FirstOrDefault() ?? throw new BusinessException("User not found.");

                envelope.SetSuccess(user);
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
