using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Threading.Tasks;

namespace Seating_Planner_Data
{
    public class Event
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int EventId { get; set; }
        public string Name { get; set; }
        public string Venue { get; set; }
        public double Budget { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int createdBy { get; set; }
        
        public virtual ICollection<Table> Tables { get; set; }
        public virtual ICollection<Guest> Guests { get; set; }
    }
}
