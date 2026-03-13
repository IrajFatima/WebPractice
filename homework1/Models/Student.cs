using System.ComponentModel.DataAnnotations;

namespace homework1.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        [Required]
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Department { get; set; }
        [Range(0, 4)]
        public double CGPA { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
