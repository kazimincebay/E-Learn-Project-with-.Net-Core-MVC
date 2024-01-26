using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IUserandExamService
    {
        void AddUserandExam(UserandExam userandExam);

        void DeleteUserandExam(UserandExam userandExam);

        void UpdateUserandExam(UserandExam userandExam);

        List<UserandExam> GetUserandExambyUserId(int id);

        List<UserandExam> GetAllUserandExam();

        UserandExam GetUserandExam(int id);
    }
}
