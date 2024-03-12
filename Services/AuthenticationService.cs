using ZJAllemanWeb.Models;

namespace ZJAllemanWeb.Services
{
    public class AuthenticationService
    {
        UsersDAO usersDAO = new UsersDAO();

        public bool IsValid(Demo1UserModel user)
        {
            return usersDAO.FindUserByNameAndPassword(user);
        }
    }
}
