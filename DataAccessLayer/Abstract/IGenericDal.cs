using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IGenericDal<T> where T : class
    {
        List<T> GetAll();

        T GetById(int id);

        void DeleteChoicewithQuestionId(int id);

        User GetUserbyUsername(string username);

        Choice GetChoicebyQuestionId(int id);

        List<UserandExam> GetUserandExambyUserId(int id);

        void Insert(T t);

        void Update(T t);

        void Delete(T t);

        


    }
}
