using NetCoreLogin.Repository;

namespace NetCoreLogin.Logic
{
    public class UserService : IUserService
    {
        readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool ValidateLogin(string email, string password)
        {

            var users = _userRepository.GetUsers();
            
            if (users == null)
                return false;

            return users.Any(x => x.Username.ToLower() == email && x.Password.ToLower() == password);
        }
    }
}
