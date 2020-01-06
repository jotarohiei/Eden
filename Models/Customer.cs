using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Eden.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        public bool IsSubcribedToNewsletter { get; set; }

        public MembershipType MembershipType { get; set; } // this is a navigation property because it allows to navigate from one type to another.

        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; } //foreign key. Used for optimisation. 

        [Display(Name="Date of Birth")]
        public string Birthday { get; set; }
    }
}