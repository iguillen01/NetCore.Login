namespace NetCoreLogin.Logic
{
    public interface IUserService
    {
        public bool ValidateLogin(string email, string password);
    }
}
