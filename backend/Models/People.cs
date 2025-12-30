using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Person
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; } = String.Empty;
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; } = String.Empty;
    }
}