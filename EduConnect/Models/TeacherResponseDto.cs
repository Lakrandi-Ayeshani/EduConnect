namespace EduConnect.Models
{
    public class TeacherResponseDto
    {
		public string? Id { get; set; }
		public string? UserId { get; set; }
		public string? FirstName { get; set; }
		public string? LastName { get; set; }
		public string? Email { get; set; }
		public string? Contact { get; set; }
		public string? Role { get; set; }
		public string? ClassAssigned { get; set; }
		public string? GuardianClass { get; set; }
		public string? Subject { get; set; }
		public DateTime? DateOfBirth { get; set; }
		public string? Address { get; set; }
	}
}
