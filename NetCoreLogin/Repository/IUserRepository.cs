using NetCoreLogin.Repository.Model;

namespace NetCoreLogin.Repository
{
    public interface IUserRepository
    {
        public User GetUser(int id);

        public IEnumerable<User> GetUsers();
    }
}
