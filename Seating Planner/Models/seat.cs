//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Seating_Planner.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class seat
    {
        public int seat_id { get; set; }
        public int event_id { get; set; }
        public int parent_table { get; set; }
    
        public virtual table table { get; set; }
        public virtual event_detail event_detail { get; set; }
    }
}
