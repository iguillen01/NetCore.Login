using NetCoreLogin.Repository.Model;

namespace NetCoreLogin.Repository
{
    public class UserRepository : IUserRepository
    {
        readonly List<User> _users;

        public UserRepository()
        {
            _users = new List<User>();
            _users.Add(new User { Id = 1, Username = "test@test.com", Password = "123456789", Active = true });
        }
        public User GetUser(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetUsers()
        {

            return _users.Where(x => x.Active == true);
        }
    }
}
