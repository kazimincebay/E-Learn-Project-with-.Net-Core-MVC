using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace ELearnProject.Controllers
{
    public class QuestionCategoryController : Controller
    {
        QuestionCategoryManager questionCategoryManager = new QuestionCategoryManager(new EFQuestionCategoryRepository());


        public IActionResult Index()
        {
            var questionCategories = questionCategoryManager.GetAllQuestionCategories();
            return View(questionCategories);
        }

        [HttpGet]
        public IActionResult AddQuestionCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddQuestionCategory(QuestionCategory questionCategory)
        {
            questionCategoryManager.AddQuestionCategory(questionCategory);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateQuestionCategory(int id)
        {
            var questionCategoryName = questionCategoryManager.GetQuestionCategory(id);
            return View(questionCategoryName);
        }

        [HttpPost]
        public IActionResult UpdateQuestionCategory(int id, string questionCategoryName)
        {
            var qctg = questionCategoryManager.GetQuestionCategory(id);
            qctg.QuestionCategoryName = questionCategoryName;
            questionCategoryManager.UpdateQuestionCategory(qctg);
            return RedirectToAction("Index");
        }



        public IActionResult DeleteQuestionCategory(int id)
        {
            var questionCategory = questionCategoryManager.GetQuestionCategory(id);
            questionCategoryManager.DeleteQuestionCategory(questionCategory);
            return RedirectToAction("Index");
        }
    }
}
