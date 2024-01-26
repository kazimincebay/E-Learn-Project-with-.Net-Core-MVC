using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class QuestionCategory
    {
        [Key]
        public int QuestionCategoryId { get; set; }

        public string QuestionCategoryName { get; set; }
    }
}
