namespace EduConnect.Models
{
    public class TeachersDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string TeachersCollectionName { get; set; } = null!;
    }
}
