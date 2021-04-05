using System.Collections.Generic;
using Capstone.Models;

namespace Capstone.DAO
{
    public interface IUserDAO
    {
        User GetUser(string email);
        User AddUser(string email, string username, string password, string role);
    }
}
