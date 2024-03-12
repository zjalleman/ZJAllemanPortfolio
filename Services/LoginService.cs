using ZJAllemanWeb.Models;

namespace ZJAllemanWeb.Services
{
    public class LoginService
    {
        UsersDAO usersDAO = new UsersDAO();

        public bool IsValid(UserModel user)
        {
            return usersDAO.FindUserByNameAndPassword(user);
        }

        public UserModel CreateAccount(UserModel user)
        {
            return usersDAO.CreateAccount(user);
        }
    }
}
