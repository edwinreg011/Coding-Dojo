using System.ComponentModel.DataAnnotations;
namespace FormSubmission.Models
{
    public class User
    {
        [Required]
        [MinLength(3, ErrorMessage="Please enter a valid first name!")]
        public string FirstName {get; set;}

        [Required]
        [MinLength(3, ErrorMessage="Please enter a valid last name!")]
        public string LastName {get; set;}

        [Required]
        // [Range(1,150)]

        public int Age {get; set;}

        [Required]
        [EmailAddress]
        public string Email {get; set;}

        [Required]
        [DataType(DataType.Password)]
        public string Password {get; set;}
    }
}