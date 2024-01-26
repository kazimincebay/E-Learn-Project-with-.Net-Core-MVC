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
    public class ChoiceManager : IChoiceService
    {
        IGenericDal<Choice> _choice;

        public ChoiceManager(IGenericDal<Choice> choice)
        {
            _choice = choice;
        }

        public void AddChoice(Choice choice)
        {
            _choice.Insert(choice);
        }

        public void DeleteChoicewithQuestionId(int id)
        {
            _choice.DeleteChoicewithQuestionId(id);
        }

        public void DeleteChoice(Choice choice)
        {
            _choice.Delete(choice);
        }

        public List<Choice> GetAllChoices()
        {
            return _choice.GetAll();
        }

        public Choice GetChoice(int id)
        {
            return _choice.GetById(id);
        }

        public void UpdateChoice(Choice choice)
        {
            _choice.Update(choice);
        }

        public Choice GetChoicebyQuestionId(int id)
        {
           return _choice.GetChoicebyQuestionId(id);
        }
    }
}
