using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class UserManager : IUserService
    {
        IGenericDal<User> _user;

        public UserManager(IGenericDal<User> user)
        {
            _user = user;
        }

        public List<User> GetAllUser()
        {
           return _user.GetAll();
            
        }

        public User GetUser(int id)
        {
            return _user.GetById(id);
        }

        public void AddUser(User user)
        {
            _user.Insert(user);
        }

        public User GetUserbyUsername(string username)
        {
            return _user.GetUserbyUsername(username);
        }
    }
}
