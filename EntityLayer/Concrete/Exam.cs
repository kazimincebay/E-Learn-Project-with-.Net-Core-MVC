using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Exam
    {
        [Key]
        public int ExamId { get; set; }

        public string ExamName { get; set; }

        public int ExamDuration { get; set; }

        public string ExamCategory { get; set; }

        public string ExamDescription { get; set; }

        public int ExamSuccessPoint { get; set; }

        
    }
}
