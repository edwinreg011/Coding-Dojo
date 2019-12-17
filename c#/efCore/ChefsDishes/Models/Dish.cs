using System.ComponentModel.DataAnnotations;

namespace ChefsDishes.Models
{
    public class Dish
    {
        [Key]
        public int DishId{get;set;}

        [Required]
        [Display(Name="Name of Dish: ")]
        public string Name {get;set;}

        [Required]
        [Display(Name="# of Calories")]
        [Range(0,100, ErrorMessage="Calories must be greater than 0!")]
        public int Calories {get;set;}

        [Required]
        [Display(Name="Tastiness: ")]
        [Range(0,6, ErrorMessage="Please enter valid tastiness!")]
        public int Tastiness {get;set;}
        
        [Required]
        [Display(Name="Description: ")]
        public string Description {get;set;}

        [Required]
        public int ChefId {get;set;}
        public Chef Chef{get;set;}
    }
}