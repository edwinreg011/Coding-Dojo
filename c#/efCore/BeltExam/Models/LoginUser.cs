using System.ComponentModel.DataAnnotations;

namespace BeltExam.Models
{
    public class LoginUser
    {
        [Required]
        [Display(Name="Email")]
        [EmailAddress]
        public string LoginEmail {get;set;}


        [Required]
        [Display(Name="Password")]
        [DataType(DataType.Password)]
        public string LoginPassword {get;set;}
    }
}