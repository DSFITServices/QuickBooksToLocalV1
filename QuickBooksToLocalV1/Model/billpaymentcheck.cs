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
    
    public partial class billpaymentcheck
    {
        public string ID { get; set; }
        public string PayeeName { get; set; }
        public string PayeeId { get; set; }
        public string ReferenceNumber { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<double> Amount { get; set; }
        public string AccountsPayable { get; set; }
        public string AccountsPayableId { get; set; }
        public string BankAccountName { get; set; }
        public string BankAccountId { get; set; }
        public Nullable<bool> IsToBePrinted { get; set; }
        public string Memo { get; set; }
        public string CustomFields { get; set; }
        public Nullable<System.DateTime> TimeModified { get; set; }
        public Nullable<System.DateTime> TimeCreated { get; set; }
    }
}
