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
    
    public partial class billpaymentchecksappliedto
    {
        public string ID { get; set; }
        public string BillPaymentId { get; set; }
        public string AppliedToRefId { get; set; }
        public Nullable<double> AppliedToAmount { get; set; }
        public Nullable<double> AppliedToBalanceRemaining { get; set; }
        public Nullable<double> AppliedToCreditAmount { get; set; }
        public string AppliedToCreditMemoId { get; set; }
        public string AppliedToDiscountAccountId { get; set; }
        public string AppliedToDiscountAccountName { get; set; }
        public Nullable<double> AppliedToDiscountAmount { get; set; }
        public Nullable<double> AppliedToPaymentAmount { get; set; }
        public string AppliedToReferenceNumber { get; set; }
        public Nullable<System.DateTime> AppliedToTxnDate { get; set; }
        public string AppliedToTxnType { get; set; }
        public Nullable<System.DateTime> TimeModified { get; set; }
    }
}
