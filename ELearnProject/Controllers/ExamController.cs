using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Globalization;

namespace ELearnProject.Controllers
{
    public class ExamController : Controller
    {
        ExamManager examManager = new ExamManager(new EFExamRepository());

        public IActionResult Index()
        {
            
            var deger = examManager.GetAllExams();
            
            


            return View(deger);
        }

        [HttpGet]
        public IActionResult AddExam()
        {
            CategoryManager categoryManager = new CategoryManager(new EFCategoryRepository());
            List<SelectListItem> categories = (from x in categoryManager.GetAllCategories()
                                               select new SelectListItem
                                               {

                                                   Text = x.CategoryName,
                                                   Value = x.CategoryId.ToString(),
                                               }).ToList();
            ViewBag.c = categories;
            return View();
        }

        [HttpPost]
        public IActionResult AddExam(Exam exam)
        {
            examManager.AddExam(exam);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateExam(int id)
        {
            CategoryManager categoryManager = new CategoryManager(new EFCategoryRepository());
            List<SelectListItem> categories = (from x in categoryManager.GetAllCategories()
                                               select new SelectListItem
                                               {

                                                   Text = x.CategoryName,
                                                   Value = x.CategoryId.ToString(),
                                               }).ToList();
            ViewBag.c = categories;
            var exam = examManager.GetExam(id);
            return View(exam);
        }

        [HttpPost]
        public IActionResult UpdateExam(int id,string examName,int examDuration,string examCategory,string examDescription,int examSuccessPoint)
        {
            var exam= examManager.GetExam(id);
            exam.ExamName=examName;
            exam.ExamDuration=examDuration;
            exam.ExamCategory=examCategory;
            exam.ExamDescription=examDescription;
            exam.ExamSuccessPoint = examSuccessPoint;
            examManager.UpdateExam(exam);
            return RedirectToAction("Index");
        }




        public IActionResult DeleteExam(int id)
        {
            var deletedExam = examManager.GetExam(id);
            examManager.DeleteExam(deletedExam);
            return RedirectToAction("Index");

        }
    }
}
