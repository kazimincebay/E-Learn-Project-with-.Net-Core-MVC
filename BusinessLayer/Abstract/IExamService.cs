using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IExamService
    {
        void AddExam(Exam exam);

        void DeleteExam(Exam exam);

        void UpdateExam(Exam exam);

        List<Exam> GetAllExams();

        Exam GetExam(int id);
    }
}
