using MySHop.Models;

namespace MySHop.Data.Repositories
{
    public interface IUserRepository
    {
        bool IsExistuserByEmail(string email);
        void AddUser(Users user);
        Users GetUserForLogin(string email , string password);
    }

    public class UserReposirory : IUserRepository
    {
        private MyShopContext _Context;
        public UserReposirory(MyShopContext context)
        {
            _Context = context;
        }
        public void AddUser(Users user)
        {
             _Context.Add(user);
            _Context.SaveChanges();

        }


        public bool IsExistuserByEmail(string email)
        {
            return _Context.Users.Any(x => x.Email == email);

        }

        public Users GetUserForLogin(string email, string password)
        {
            return _Context.Users
                .SingleOrDefault(u => u.Email == email && u.Password == password);
                
        }
    }
}
