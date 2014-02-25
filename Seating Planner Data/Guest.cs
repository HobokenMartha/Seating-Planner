using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Threading.Tasks;

namespace Seating_Planner_Data
{
    public class Guest
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int GuestId { get; set; }
        public string Title { get; set; }
        [Required(ErrorMessage="A first name is required")] 
        public string FirstName { get; set; }
        [Required(ErrorMessage = "A surname is required")] 
        public string Surname { get; set; }
        [DataType(DataType.EmailAddress, ErrorMessage="Email address is not valid")]
        public string Email { get; set; }
        public int CreatedBy { get; set; }
        [DataType(DataType.DateTime, ErrorMessage="Incorrect DateTime format entered")]
        public DateTime DateTimeCreated { get; set; }
    }
}
