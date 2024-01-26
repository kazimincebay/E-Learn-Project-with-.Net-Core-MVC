using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IChoiceService
    {
        void AddChoice(Choice choice);

        void DeleteChoicewithQuestionId(int id);

        Choice GetChoicebyQuestionId(int id);

        void DeleteChoice(Choice choice);

        void UpdateChoice(Choice choice);

        List<Choice> GetAllChoices();

        Choice GetChoice(int id);
    }
}
