using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace ELearnProject.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EFCategoryRepository());

        public IActionResult Index()
        {
            var values = categoryManager.GetAllCategories();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddCategory(int id)
        {
            var category = categoryManager.GetCategory(id);
            return View(category);
        }

        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            categoryManager.AddCategory(category);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateCategory(int id)
        {
            var category = categoryManager.GetCategory(id);
            return View(category);
        }

        [HttpPost]
        public IActionResult UpdateCategory(int id, string CategoryName)
        {

            var ctg = categoryManager.GetCategory(id);
            ctg.CategoryName = CategoryName;
            categoryManager.UpdateCategory(ctg);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteCategory(int id)
        {
            var category = categoryManager.GetCategory(id);
            categoryManager.DeleteCategory(category);
            return RedirectToAction("Index");
        }


    }
}
