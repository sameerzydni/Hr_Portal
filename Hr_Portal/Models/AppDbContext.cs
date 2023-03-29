using Microsoft.EntityFrameworkCore;

namespace Hr_Portal.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions options):base(options)
        {

        }

        public DbSet<ResumeModel> Resumes { get; set; }
        
        public DbSet<LoginModel> Logins { get; set; }

        public DbSet<JavaQuestion> JavaQuestions { get; set; }
    }
}
