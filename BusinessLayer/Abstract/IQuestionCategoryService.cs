using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IQuestionCategoryService
    {
        void AddQuestionCategory(QuestionCategory questionCategory);

        void DeleteQuestionCategory(QuestionCategory questionCategory);

        void UpdateQuestionCategory(QuestionCategory questionCategory);

        List<QuestionCategory> GetAllQuestionCategories();

        QuestionCategory GetQuestionCategory(int id);
    }
}
