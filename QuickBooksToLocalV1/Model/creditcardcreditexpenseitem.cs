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
    
    public partial class creditcardcreditexpenseitem
    {
        public string ID { get; set; }
        public string CCCreditId { get; set; }
        public string ExpenseLineId { get; set; }
        public string ExpenseAccount { get; set; }
        public string ExpenseAccountId { get; set; }
        public Nullable<double> ExpenseAmount { get; set; }
        public string ExpenseBillableStatus { get; set; }
        public string ExpenseCustomer { get; set; }
        public string ExpenseCustomerId { get; set; }
        public string ExpenseClass { get; set; }
        public string ExpenseClassId { get; set; }
        public string ExpenseMemo { get; set; }
        public string ExpenseTaxCode { get; set; }
        public string ExpenseTaxCodeId { get; set; }
        public Nullable<System.DateTime> TimeModified { get; set; }
    }
}
