using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeltExam.Models
{
    public class User
    {
        [Key]
        public int UserId {get;set;}

        [Required]
        [MinLength(2,ErrorMessage="First name must be 2 characters or more!")]
        [Display(Name = "First Name")]
        public string FirstName {get;set;}

        [Required]
        [MinLength(2,ErrorMessage="Last name must be 2 characters or more!")]
        [Display(Name="Last Name")]
        public string LastName {get;set;}

        [Required]
        [Display(Name="Email")]
        [EmailAddress]
        public string Email {get;set;}

        [Required]
        [MinLength(8,ErrorMessage="Password name must be 8 characters or more!")]
        [Display(Name="Password")]
        [DataType(DataType.Password)]
        public string Password {get;set;}

        [Required]
        [NotMapped]
        [Display(Name="Confirm Password")]
        [Compare("Password")]
        public string ComparePassword {get;set;}

        public DateTime CreatedAt {get;set;} = DateTime.Now;

        public DateTime UpdatedAt {get;set;} = DateTime.Now;

        //Associations

        public List<Attendant> GoingTo {get;set;}

        public List<Meeting> PlannedMeetings {get;set;}
    }
}