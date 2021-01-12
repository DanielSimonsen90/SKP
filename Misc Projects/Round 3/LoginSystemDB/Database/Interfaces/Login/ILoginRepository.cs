using Common.Entities;

namespace LoginDatabase.Interfaces
{
    public interface ILoginRepository
    {
        void AddLogin(Login login);
        Login GetLogin(string username, string password);
        void RemoveLogin(Login login);
    }
}
