using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        public void Delete(T t)
        {
            using var c = new Context();
            c.Remove(t);
            c.SaveChanges();
        }

        public List<T> GetAll()
        {
            using var c = new Context();
            return c.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            using var c = new Context();
            return c.Set<T>().Find(id);
        }

        public void DeleteChoicewithQuestionId(int id)
        {
            using var c = new Context();
            Choice choice = new Choice();
            c.Choices.Where(choice => choice.QuestionId == id).ExecuteDelete();

        }

        public void Insert(T t)
        {
            using var c = new Context();
            c.Add(t);
            c.SaveChanges();

        }

        public void Update(T t)
        {
            using var c = new Context();
            c.Update(t);
            c.SaveChanges();
        }

        public Choice GetChoicebyQuestionId(int id)
        {
            using var c = new Context();
            Choice choice = new Choice();
            var choices = c.Choices.Where(choice => choice.QuestionId == id).FirstOrDefault();
            return choices;
        }

        public User GetUserbyUsername(string username)
        {
            using var c = new Context();
            User user = new User();
            var userinformation = c.Users.Where(user => user.UserName == username).FirstOrDefault();
            return userinformation;
        }

        public List<UserandExam> GetUserandExambyUserId(int id)
        {
            using var c = new Context();
            UserandExam userandExam = new UserandExam();
            var userandexam = c.UserandExams.Where(userandExam => userandExam.UserId == id).ToList();
            return userandexam;
        }
    }
}
