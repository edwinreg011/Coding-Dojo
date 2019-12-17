using System.ComponentModel.DataAnnotations;

namespace DojoSurveyV.Models
{
    public class Survey
    {
        [Required]
        [MinLength(2, ErrorMessage="Enter Valid Name!")]
        [Display(Name="Name: ")]
        public string Name {get; set;}



        [Required]
        [Display(Name="Dojo Location: ")]
        public string Location { get; set;}


        [Required]
        [Display(Name="Fav Language: ")]
        public string Language { get; set;}


        [MinLength(20, ErrorMessage = "Please enter comment at least 20 characters!")]
        [Display(Name="Comments (optional) ")]
        public string Comments {get; set;}
    }
}