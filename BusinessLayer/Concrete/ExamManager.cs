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
    public class ExamManager : IExamService
    {
        IGenericDal<Exam> _exam;

        public ExamManager(IGenericDal<Exam> exam)
        {
            _exam = exam;
        }

        public void AddExam(Exam exam)
        {
            _exam.Insert(exam);
            
        }

        public void DeleteExam(Exam exam)
        {
            _exam.Delete(exam);
        }

        public List<Exam> GetAllExams()
        {
            return _exam.GetAll();
        }

        

        public Exam GetExam(int id)
        {
            return _exam.GetById(id);
        }

        public void UpdateExam(Exam exam)
        {
            _exam.Update(exam);
        }
    }
}
