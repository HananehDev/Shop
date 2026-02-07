using MySHop.Models;

namespace MySHop.Data.Repositories
{
    public interface IUserRepository
    {
        bool IsExistuserByEmail(string email);
        void AddUser(Users user);

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
    }
}
