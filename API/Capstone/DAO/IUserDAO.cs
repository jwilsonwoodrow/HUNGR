using System.Collections.Generic;
using Capstone.Models;

namespace Capstone.DAO
{
    public interface IUserDAO
    {
        User GetUserByEmail (string email);
        User GetUserByUsername(string username);
        User AddUser(string email, string username, string password, string role);
    }
}
