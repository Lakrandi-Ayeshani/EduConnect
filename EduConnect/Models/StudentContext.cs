using Microsoft.EntityFrameworkCore;

namespace EduConnect.Models
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options)
        : base(options)
        {
        }

        public DbSet<Student> Students { get; set; } = null!;

    }
}
