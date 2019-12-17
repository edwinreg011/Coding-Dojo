using System;
using System.ComponentModel.DataAnnotations;

namespace QuotingDojo.Models
{
    public class Quote
    {
        [Required]
        [MinLength(2,ErrorMessage="Enter Valid Name!")]
        [Display(Name="Your Name: ")]
        public string Name {get; set;}

        
        [Required]
        [Display(Name="Your Quote: ")]
        [MinLength(10, ErrorMessage="Please enter quote at least 10 characters long!")]
        public string Content { get; set;}

    }
}