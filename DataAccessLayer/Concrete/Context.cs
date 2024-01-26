using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=KAZıM;database=eLearnDb;integrated security=true;TrustServerCertificate=true");
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Exam> Exams { get; set; }

        public DbSet<Question> Questions { get; set; }

        public DbSet<QuestionCategory> QuestionCategories { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Choice> Choices{ get; set; }

        public DbSet<UserandExam> UserandExams { get; set; }
    }
}
