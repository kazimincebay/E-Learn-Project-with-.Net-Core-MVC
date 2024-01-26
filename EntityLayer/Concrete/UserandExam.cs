using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class UserandExam
    {
        [Key]
        public int UserandExamId { get; set; }

        public int UserId { get; set; }

        public int ExamId { get; set; }

        public DateTime startDate { get; set; }

        public DateTime endDate { get; set; }
    }
}
