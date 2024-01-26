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
    public class QuestionCategoryManager : IQuestionCategoryService
    {
        IGenericDal<QuestionCategory> _questionCategory;

        public QuestionCategoryManager(IGenericDal<QuestionCategory> questionCategory)
        {
            _questionCategory = questionCategory;
        }

        public void AddQuestionCategory(QuestionCategory questionCategory)
        {
            _questionCategory.Insert(questionCategory);
        }

        public void DeleteQuestionCategory(QuestionCategory questionCategory)
        {
            _questionCategory?.Delete(questionCategory);
        }

        public List<QuestionCategory> GetAllQuestionCategories()
        {
            return _questionCategory.GetAll();
        }

        public QuestionCategory GetQuestionCategory(int id)
        {
            return _questionCategory.GetById(id);
        }

        public void UpdateQuestionCategory(QuestionCategory questionCategory)
        {
            _questionCategory.Update(questionCategory);
        }
    }
}
