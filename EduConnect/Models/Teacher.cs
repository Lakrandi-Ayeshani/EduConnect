using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace EduConnect.Models
{
    public class Teacher
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [Key]
        public string? Id { get; set; }

        [Key]
        [Required]
        public string? UserId { get; set; }

        [StringLength(20)]
        [Required]
        public string? FirstName { get; set; }

        [StringLength(20)]
        public string? LastName { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        [Phone]
        public string? Contact { get; set; }

        [Required]
        public string? Role { get; set; }
        public string? ClassAssigned { get; set; }

        public string? GuardianClass { get; set; }
        public string? Subject { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Address { get; set; }

        [ScaffoldColumn(false)]
        public string? Password { get; set; }

        [Compare("Password")]
        [ScaffoldColumn(false)]
        public string? ComfirmPassword { get; set; }
    }
}
