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
    public class UserandExamManager : IUserandExamService
    {
        IGenericDal<UserandExam> _userandExam;

        public UserandExamManager(IGenericDal<UserandExam> userandExam)
        {
            _userandExam = userandExam;
        }

        public void AddUserandExam(UserandExam userandExam)
        {
            _userandExam.Insert(userandExam);
        }

        public void DeleteUserandExam(UserandExam userandExam)
        {
            _userandExam.Delete(userandExam);
        }

        public List<UserandExam> GetAllUserandExam()
        {
            return _userandExam.GetAll();
        }

        public UserandExam GetUserandExam(int id)
        {
            return _userandExam.GetById(id);
        }

        public List<UserandExam> GetUserandExambyUserId(int id)
        {
            return _userandExam.GetUserandExambyUserId(id);
        }

        public void UpdateUserandExam(UserandExam userandExam)
        {
            _userandExam.Update(userandExam);
        }
    }
}
