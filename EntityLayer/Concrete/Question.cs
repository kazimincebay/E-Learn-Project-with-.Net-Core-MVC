using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Question
    {
        [Key]
        public int QuestionId { get; set; }

        public string QuestionCategory { get; set; }

        public string QuestionType { get; set; }

        public string QuestionText { get; set; }


    }
}
