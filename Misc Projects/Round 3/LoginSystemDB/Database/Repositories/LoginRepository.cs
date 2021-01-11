using Common.Entities;
using LoginDatabase.Interfaces;
using System.Data.Entity;
using System.Linq;
using System.Threading;

namespace LoginDatabase.Repositories
{
    public class LoginRepository : Repository<Login>, ILoginRepository
    {
        private readonly ILoginContext _loginContext = new LoginContext();

        public LoginRepository(IDbContext dbContext) : base(dbContext) { }

        #region CRUD
        public void AddLogin(Login login)
        {
            if (this.Find(login.Username) != null) throw new InvalidLoginException(InvalidLoginException.ExceptionTypes.InvalidUsername, "This username is already taken!");

            _loginContext.Login.Attach(login);
            _loginContext.Login.Add(login);
            _loginContext.SaveChanges();
        }
        public Login GetLogin(string username, string password)
        {
            var usernameCollection = this.Get(usernameLogin => usernameLogin.Username == username);
            if (!usernameCollection.Any()) throw new InvalidLoginException(InvalidLoginException.ExceptionTypes.InvalidUsername, "Username not found in database!");

            var passwordCollection = usernameCollection.Where(passwordLogin => passwordLogin.Password == password);
            if (!passwordCollection.Any()) throw new InvalidLoginException(InvalidLoginException.ExceptionTypes.InvalidPassword, "Password is incorrect!");

            return passwordCollection.First();
        }
        public void UpdateLogin(string username, string newPassword)
        {
            Login dbLogin = this.Find(username);
            dbLogin.Password = newPassword;

            _loginContext.SaveChanges();
        }
        public void RemoveLogin(Login login)
        {
            var Login = this.Find(login.Username);
            if (Login == null) throw new System.Exception("Login is not in database!");

            _loginContext.Login.Attach(login);
            _loginContext.Login.Remove(login);
            _loginContext.SaveChanges();
        }
        #endregion

        public Login Find(string username) =>
            _loginContext.Login
            .Where(login => login.Username == username)
            .AsNoTracking()
            .FirstOrDefault();
    }
}
