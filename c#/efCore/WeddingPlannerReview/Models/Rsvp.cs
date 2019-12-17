using System.ComponentModel.DataAnnotations;

namespace WeddingPlannerReview.Models
{
    public class Rsvp
    {
        [Key]
        public int RsvpId {get;set;}
        public int UserId {get;set;}
        public int WeddingId {get;set;}
        public User Guest {get;set;}
        public Wedding Attending {get;set;}
    }
}