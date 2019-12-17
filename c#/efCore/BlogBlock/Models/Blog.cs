using System;
using System.ComponentModel.DataAnnotations;

namespace BlogBlock.Models
{
    public class Blog
    {
        [Key]
        public int BlogId {get;set;}
        public int UserId {get;set;}
        [Required]
        public string Message{get;set;}
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;

        public User Creator {get;set;}
        
    }
}