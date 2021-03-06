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
    
    public partial class salesreceipt
    {
        public string ID { get; set; }
        public string ReferenceNumber { get; set; }
        public Nullable<int> TxnNumber { get; set; }
        public string CustomerName { get; set; }
        public string CustomerId { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string ShipMethod { get; set; }
        public string ShipMethodId { get; set; }
        public Nullable<System.DateTime> ShipDate { get; set; }
        public string Memo { get; set; }
        public string Class { get; set; }
        public string ClassId { get; set; }
        public Nullable<System.DateTime> DueDate { get; set; }
        public Nullable<double> TotalAmount { get; set; }
        public string Message { get; set; }
        public string MessageId { get; set; }
        public string SalesRep { get; set; }
        public string SalesRepId { get; set; }
        public string Template { get; set; }
        public string TemplateId { get; set; }
        public Nullable<double> ExchangeRate { get; set; }
        public string FOB { get; set; }
        public string BillingAddress { get; set; }
        public string BillingLine1 { get; set; }
        public string BillingLine2 { get; set; }
        public string BillingLine3 { get; set; }
        public string BillingLine4 { get; set; }
        public string BillingLine5 { get; set; }
        public string BillingCity { get; set; }
        public string BillingState { get; set; }
        public string BillingPostalCode { get; set; }
        public string BillingCountry { get; set; }
        public string BillingNote { get; set; }
        public string ShippingAddress { get; set; }
        public string ShippingLine1 { get; set; }
        public string ShippingLine2 { get; set; }
        public string ShippingLine3 { get; set; }
        public string ShippingLine4 { get; set; }
        public string ShippingLine5 { get; set; }
        public string ShippingCity { get; set; }
        public string ShippingState { get; set; }
        public string ShippingPostalCode { get; set; }
        public string ShippingCountry { get; set; }
        public string ShippingNote { get; set; }
        public Nullable<double> Subtotal { get; set; }
        public Nullable<double> Tax { get; set; }
        public string TaxItem { get; set; }
        public string TaxItemId { get; set; }
        public Nullable<double> TaxPercent { get; set; }
        public Nullable<bool> IsPending { get; set; }
        public Nullable<bool> IsToBePrinted { get; set; }
        public Nullable<bool> IsTaxIncluded { get; set; }
        public Nullable<bool> IsToBeEmailed { get; set; }
        public string CheckNumber { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentMethodId { get; set; }
        public string DepositAccount { get; set; }
        public string DepositAccountId { get; set; }
        public string CustomerTaxCode { get; set; }
        public string CustomerTaxCodeId { get; set; }
        public string CustomFields { get; set; }
        public string EditSequence { get; set; }
        public Nullable<System.DateTime> TimeModified { get; set; }
        public Nullable<System.DateTime> TimeCreated { get; set; }
    }
}
