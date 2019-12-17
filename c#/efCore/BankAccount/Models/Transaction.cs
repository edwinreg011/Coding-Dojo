using System;
using System.ComponentModel.DataAnnotations;

namespace BankAccount.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionId{get;set;}
        public double Amount {get;set;}

        //navigatinoal properties
        public int UserId{get;set;}
        public User AccountHolder{get;set;}
        public DateTime CreatedAt{get;set;} = DateTime.Now;
        public DateTime UpdatedAt{get;set;} = DateTime.Now;
    }
}