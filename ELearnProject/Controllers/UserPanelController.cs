using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using ELearnProject.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace ELearnProject.Controllers
{
    public class UserPanelController : Controller
    {
        UserManager userManager = new UserManager(new EFUserRepository());
        



        [HttpGet]
        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("User") !=null)
            {
                ViewBag.isLoggedin = true;

                UserandExamManager userandExamManager = new UserandExamManager(new EFUserandExamRepository());
                User model1 = userManager.GetUser(Convert.ToInt32(HttpContext.Session.GetInt32("User")));
                
                List<UserandExam> model2 = userandExamManager.GetUserandExambyUserId(Convert.ToInt32(HttpContext.Session.GetInt32("User")));

                // Birden fazla modeli view modele atayarak view modele gönder
                MyViewModel2 viewModel = new MyViewModel2
                {
                    user = model1,
                    userandexam = model2
                };

                return View(viewModel);
            }
            ViewBag.isLoggedin = false;

            return View();
        }

        public IActionResult Exam(int id)
        {
            ExamManager examManager=new ExamManager(new EFExamRepository());
            QuestionManager questionManager=new QuestionManager(new EFQuestionRepository());
            ChoiceManager choiceManager=new ChoiceManager(new EFChoiceRepository());

            var exam=examManager.GetExam(id);
            ViewBag.examDuration = exam.ExamDuration;
            

            Question model1 = questionManager.GetQuestion(1);

            Choice model2 = choiceManager.GetChoicebyQuestionId(1);

            // Birden fazla modeli view modele atayarak view modele gönder
            MyViewModel viewModel = new MyViewModel
            {
                question = model1,
                choice = model2
            };
            return View(viewModel);
        }


        [HttpPost]
        public IActionResult Result(int id)
        {
            return View();
        }



        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            userManager.AddUser(user);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            var userinformation = userManager.GetUserbyUsername(user.UserName);
            if (userinformation.UserName == user.UserName && userinformation.UserPassword == user.UserPassword)
            {
                HttpContext.Session.SetInt32("User", userinformation.UserId);
            }



            return RedirectToAction("Index");
        }


        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }


}
