using System.Data.Entity;
using DomainModel.Model;

namespace DomainModel
{
    public class MyContext : DbContext
    {
        public MyContext() : base("name=MyContext")
        {

        }

        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Answer> Answers { get; set; }
    }
}
