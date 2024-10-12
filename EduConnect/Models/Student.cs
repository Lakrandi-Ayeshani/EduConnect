
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EduConnect.Models
{
    public class Student
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [Key]
        public string? Id { get; set; }

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
        public string? Class { get; set; }
        public string? Section { get; set; }
        public DateTime? DateOfBirth { get; set; }  
        public string? Address { get; set; }
        public string? GuardianID { get; set; }

        [Required]
        [ScaffoldColumn(false)]
        public string? Password { get; set; }

        [Compare("Password")]
        [ScaffoldColumn(false)]
        public string? ComfirmPassword { get; set; }
    }
}
