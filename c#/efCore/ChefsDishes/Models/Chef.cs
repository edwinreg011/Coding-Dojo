using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChefsDishes.Models
{
    public class NoFutureDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if ((DateTime)value > DateTime.Now)
            {
                return new ValidationResult("Date must be in the past");
            }
            return ValidationResult.Success;
        }
    }


    public class Chef
    {
        [Key]
        public int ChefId {get;set;}
        [Required]
        [Display(Name="First name: ")]
        public string FirstName {get;set;}
        [Required]
        [Display(Name="Last name: ")]
        public string LastName{get;set;}

        [Required]
        [NoFutureDate]
        [Display(Name="Date of Birth: ")]
        public DateTime DateOfBirth {get;set;}
        public int Age{get;set;}
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
        public List<Dish> CreatedDishes {get;set;}
    }
}