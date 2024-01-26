using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IQuestionService
    {
        void AddQuestion(Question question);

        void DeleteQuestion(Question question);

        void UpdateQuestion(Question question);

        List<Question> GetAllQuestions();

        Question GetQuestion(int id);
    }
}
