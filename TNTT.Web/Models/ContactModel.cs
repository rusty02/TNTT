using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TNTT.Web.Models
{
    public class ContactModel
    {
        public int Id { get; set; }
        public int Role { get; set; }
        public string SaintName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }
        public string Status { get; set; }
        public int DoanId { get; set; }
        public string DoanName { get; set; }
        public string MienName { get; set; }
        public int MienId { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}