using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Threading.Tasks;

namespace Seating_Planner_Data
{
    public class Table
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int TableId { get; set; }
        public string Name { get; set; }
        [Required(ErrorMessage="Please enter a capacity")]
        [RegularExpression("^\\d+$")]
        public int Capacity { get; set; }
        public int xCoordinate { get; set; }
        public int yCoordinate { get; set; }
    }
}
