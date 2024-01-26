using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IUserService
    {
        List<User> GetAllUser();

        User GetUser(int id);

        User GetUserbyUsername(string username);

        void AddUser(User user);
    }
}
