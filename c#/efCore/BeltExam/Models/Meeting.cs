using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BeltExam.Models
{
    public class Meeting
    {
        [Key]
        public int MeetingId {get;set;}
        [Required]
        public string Name {get;set;}
        [Required]
        [FutureDate]
        [Display(Name="Date")]
        public DateTime Date {get;set;}
        [Required]
        [Display(Name="Time")]
        public DateTime Time {get;set;}
        [Required]
        public string Duration {get;set;}
        [Required]
        public string Description {get;set;}
        public DateTime CreatedAt {get;set;} = DateTime.Now;

        public DateTime UpdatedAt {get;set;} = DateTime.Now;

        //ASSOCIATIONS

        public int UserId {get;set;}
        public User Planner {get;set;}
        public List<Attendant> ComingList {get;set;}
    }

    public class FutureDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime date;
            if(value is DateTime)
            {
                date = (DateTime)value;
            }
            else
            {
                return new ValidationResult("Invalid DateTime");
            }
            if(date < DateTime.Now)
            {
                return new ValidationResult("Date must be in the future!");
            }
            return ValidationResult.Success;
        }
    }
}