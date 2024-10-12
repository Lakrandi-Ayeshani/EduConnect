using Microsoft.EntityFrameworkCore;

namespace EduConnect.Models
{
    public class TeacherContext : DbContext
    {
        public TeacherContext(DbContextOptions<TeacherContext> options)
      : base(options)
        {
        }

        public DbSet<Teacher> Teachers { get; set; } = null!;

    }
}
