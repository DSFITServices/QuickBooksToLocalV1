//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuickBooksToLocalV1.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class todo
    {
        public string ID { get; set; }
        public string Notes { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string Type { get; set; }
        public string Priority { get; set; }
        public Nullable<bool> IsDone { get; set; }
        public Nullable<System.DateTime> ReminderDate { get; set; }
        public string ReminderTime { get; set; }
        public string EditSequence { get; set; }
        public Nullable<System.DateTime> TimeCreated { get; set; }
        public Nullable<System.DateTime> TimeModified { get; set; }
    }
}
