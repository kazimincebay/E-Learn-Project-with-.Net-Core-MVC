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
    public class QuestionManager : IQuestionService
    {
        IGenericDal<Question> _question;

        public QuestionManager(IGenericDal<Question> question)
        {
            _question = question;
        }

        public void AddQuestion(Question question)
        {
           _question.Insert(question);
        }

        public void DeleteQuestion(Question question)
        {
            _question.Delete(question);
        }

        public List<Question> GetAllQuestions()
        {
            return _question.GetAll();
        }

        public Question GetQuestion(int id)
        {
            return _question.GetById(id);
        }


        public void UpdateQuestion(Question question)
        {
            _question.Update(question);
        }
    }
}
