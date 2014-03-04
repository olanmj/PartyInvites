using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PartyInvites.Models
{
    public class GuestResponse
    {
        public int ID { get; set; }
        [Required( ErrorMessage = "Please enter your name")]
        public string Name { get; set; }
        [Required( ErrorMessage = "Please provide a phone number")]
        public string Phone { get; set; }
        
        [Required( ErrorMessage = "Please indicate if you will attend")] 
        [Display(Name="Will Attend")]
        public bool? WillAttend { get; set; }
    }

    public class ResponseDBContext : DbContext
    {
        public DbSet<GuestResponse> Responses { get; set; }
    }
}