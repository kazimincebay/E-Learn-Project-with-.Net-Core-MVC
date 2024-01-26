using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using ELearnProject.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;



namespace ELearnProject.Controllers
{
    public class QuestionController : Controller
    {
        QuestionManager questionManager = new QuestionManager(new EFQuestionRepository());

        public IActionResult Index()
        {
            var questions = questionManager.GetAllQuestions();
            return View(questions);
        }

        public IActionResult DeleteQuestion(int id)
        {
            ChoiceManager choiceManager = new ChoiceManager(new EFChoiceRepository());
            var question = questionManager.GetQuestion(id);
            questionManager.DeleteQuestion(question);
            choiceManager.DeleteChoicewithQuestionId(id);

            return RedirectToAction("Index");
        }


        


        public IActionResult QuestionDetails(int id)
        {   ChoiceManager choiceManager=new ChoiceManager(new EFChoiceRepository());
            var choice= choiceManager.GetChoicebyQuestionId(id);

            ViewBag.choice1 =choice.Choice1;
            ViewBag.choice2 =choice.Choice2;
            ViewBag.choice3 =choice.Choice3;
            ViewBag.choice4 =choice.Choice4;
            ViewBag.choice5 = choice.Choice5;
            ViewBag.correctAnswer =choice.CorrectAnswer ;
            var question = questionManager.GetQuestion(id);

            return View(question);
        }
        [HttpGet]
        public IActionResult UpdateQuestion(int id)
        {
            ChoiceManager choiceManager = new ChoiceManager(new EFChoiceRepository());
            var model1 = questionManager.GetQuestion(id);  
            
            Choice model2 = choiceManager.GetChoicebyQuestionId(id);

            // Birden fazla modeli view modele atayarak view modele gönder
            MyViewModel viewModel = new MyViewModel
            {
                question = model1,
                choice = model2
            };
            QuestionCategoryManager questionctgManager = new QuestionCategoryManager(new EFQuestionCategoryRepository());
            
            List<SelectListItem> QuestionCategory = (from x in questionctgManager.GetAllQuestionCategories()
                                                     select new SelectListItem
                                                     {
                                                         Text = x.QuestionCategoryName,
                                                         Value = x.QuestionCategoryId.ToString(),
                                                     }).ToList();
            ViewBag.QuestionCategory = QuestionCategory;
            questionManager.GetQuestion(id);
            

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult UpdateQuestion(Question question,Choice choice) {
            
            QuestionCategoryManager questionctgManager = new QuestionCategoryManager(new EFQuestionCategoryRepository());

            List<SelectListItem> QuestionCategory = (from x in questionctgManager.GetAllQuestionCategories()
                                                     select new SelectListItem
                                                     {
                                                         Text = x.QuestionCategoryName,
                                                         Value = x.QuestionCategoryId.ToString(),
                                                     }).ToList();
            ViewBag.QuestionCategory = QuestionCategory;
            ChoiceManager choiceManager = new ChoiceManager(new EFChoiceRepository());
            var getquestion = questionManager.GetQuestion(question.QuestionId);

            
                getquestion.QuestionText = question.QuestionText;
                getquestion.QuestionCategory = question.QuestionCategory;
                getquestion.QuestionType = question.QuestionType;
                questionManager.UpdateQuestion(getquestion);


            var getchoice = choiceManager.GetChoicebyQuestionId(question.QuestionId);
            if (question.QuestionType == "Aciklamali")
            {
                getchoice.CorrectAnswer = choice.CorrectAnswer;
                choiceManager.UpdateChoice(getchoice);
            }
            if (question.QuestionType == "CoktanSecmeli")
            {
                getchoice.Choice1 = choice.Choice1;
                getchoice.Choice2 = choice.Choice2;
                getchoice.Choice3 = choice.Choice3;
                getchoice.Choice4 = choice.Choice4;
                getchoice.Choice5 = choice.Choice5;
                getchoice.CorrectAnswer = choice.CorrectAnswer;
                choiceManager.UpdateChoice(getchoice);
            }

            return RedirectToAction("Index");
        }





        [HttpGet]
        public IActionResult AddQuestion()
        {
            QuestionCategoryManager questionctgManager = new QuestionCategoryManager(new EFQuestionCategoryRepository());
            List<SelectListItem> QuestionCategory = (from x in questionctgManager.GetAllQuestionCategories()
                                                     select new SelectListItem
                                                     {

                                                         Text = x.QuestionCategoryName,
                                                         Value = x.QuestionCategoryId.ToString(),
                                                     }).ToList();
            ViewBag.QuestionCategory = QuestionCategory;
            return View();
        }

        [HttpPost]
        public IActionResult AddQuestion(Question question, string correctAnswer,string answer,string choice1, string choice2, string choice3, string choice4, string choice5)
        {
            ChoiceManager choiceManager = new ChoiceManager(new EFChoiceRepository());
            QuestionCategoryManager questionctgManager = new QuestionCategoryManager(new EFQuestionCategoryRepository());
            List<SelectListItem> QuestionCtg = (from x in questionctgManager.GetAllQuestionCategories()
                                                select new SelectListItem
                                                {

                                                    Text = x.QuestionCategoryName,
                                                    Value = x.QuestionCategoryId.ToString(),
                                                }).ToList();
            ViewBag.QuestionCategory = QuestionCtg;


            questionManager.AddQuestion(question);
            if (question.QuestionType == "Aciklamali")
            {
                Choice choice = new Choice();
                choice.QuestionId = question.QuestionId;
                choice.CorrectAnswer = answer;
                choiceManager.AddChoice(choice);
            }
            if (question.QuestionType == "CoktanSecmeli")
            {
                
                Choice choice = new Choice();
                choice.QuestionId = question.QuestionId;
                choice.Choice1 = choice1;
                choice.Choice2 = choice2;
                choice.Choice3 = choice3;
                choice.Choice4 = choice4;
                choice.Choice5 = choice5;
                choice.CorrectAnswer = correctAnswer;
                choiceManager.AddChoice(choice);
                

            }

            return RedirectToAction("Index");
        }




    }
}
