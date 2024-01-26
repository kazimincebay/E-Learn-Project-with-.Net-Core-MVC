using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using ELearnProject.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ELearnProject.Controllers
{
    public class UserController : Controller
    {
        UserManager userManager = new UserManager(new EFUserRepository());

        public IActionResult Index()
        {
            var users = userManager.GetAllUser();
            return View(users);
        }

        public IActionResult UserDetails(int id) {
            UserandExamManager userandExamManager = new UserandExamManager(new EFUserandExamRepository());
            
            var model1 = userManager.GetUser(id);

            List<UserandExam> model2 = userandExamManager.GetUserandExambyUserId(id);

            // Birden fazla modeli view modele atayarak view modele gönder
            MyViewModel2 viewModel = new MyViewModel2
            {
                user = model1,
                userandexam = model2
            };
            
            return View(viewModel);
        }



        [HttpGet]
        public IActionResult AssignmentExam(int id)
        {
            
            UserandExamManager userandExamManager = new UserandExamManager(new EFUserandExamRepository());
            var model1 =userManager.GetUser(id);

            UserandExam model2 = userandExamManager.GetUserandExam(id);

            // Birden fazla modeli view modele atayarak view modele gönder
            MyViewModel2 viewModel = new MyViewModel2
            {
                user = model1,
                userandExam= model2
            };
            ExamManager examManager= new ExamManager(new EFExamRepository());
            var user = userManager.GetUser(id);
            List<SelectListItem> Exams = (from x in examManager.GetAllExams()
                                                     select new SelectListItem
                                                     {
                                                         Text = x.ExamName,
                                                         Value = x.ExamId.ToString(),
                                                     }).ToList();
            ViewBag.Exams = Exams;
            return View(viewModel);
        }


        [HttpPost]
        public IActionResult AssignmentExam(User user,UserandExam userandExam)
        {
            UserandExamManager userandExamManager = new UserandExamManager(new EFUserandExamRepository());
            UserandExam userandexam= new UserandExam();
            userandexam.UserId = user.UserId;
            userandexam.ExamId=userandExam.ExamId;
            userandexam.startDate = userandExam.startDate;
            userandexam.endDate= userandExam.endDate;
            userandExamManager.AddUserandExam(userandexam);


            return RedirectToAction("Index");
        }
    }
}
