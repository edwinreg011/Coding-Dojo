using System.ComponentModel.DataAnnotations;

namespace BeltExam.Models
{
    public class Attendant
    {
        [Key]
        public int AttendantId {get;set;}
        public int UserId {get;set;}
        public int MeetingId {get;set;}
        public User Invited {get;set;}
        public Meeting Coming {get;set;}
    }
}