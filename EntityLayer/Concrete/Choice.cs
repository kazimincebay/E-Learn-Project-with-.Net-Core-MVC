using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Choice
    {
        [Key]
        public int ChoiceId { get; set; }

        public int QuestionId { get; set; }

        public string CorrectAnswer { get; set; }

        public string ?Choice1 { get; set; }
        public string ?Choice2 { get; set; }
        public string ?Choice3 { get; set; }
        public string ?Choice4 { get; set; }
        public string ?Choice5 { get; set; }
    }
}
