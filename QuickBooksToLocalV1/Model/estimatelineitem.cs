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
    
    public partial class estimatelineitem
    {
        public string ID { get; set; }
        public string EstimateId { get; set; }
        public string ItemLineID { get; set; }
        public string ItemName { get; set; }
        public string ItemId { get; set; }
        public string ItemGroup { get; set; }
        public string ItemGroupId { get; set; }
        public string ItemDescription { get; set; }
        public string ItemUnitOfMeasure { get; set; }
        public Nullable<double> ItemQuantity { get; set; }
        public Nullable<double> ItemRate { get; set; }
        public Nullable<double> ItemRatePercent { get; set; }
        public string ItemTaxCode { get; set; }
        public string ItemTaxCodeId { get; set; }
        public Nullable<double> ItemAmount { get; set; }
        public string ItemClass { get; set; }
        public string ItemClassId { get; set; }
        public string ItemInventorySiteId { get; set; }
        public string ItemInventorySiteName { get; set; }
        public Nullable<double> ItemMarkupRate { get; set; }
        public Nullable<double> ItemMarkupRatePercent { get; set; }
        public string ItemOther1 { get; set; }
        public string ItemOther2 { get; set; }
        public string ItemCustomFields { get; set; }
        public string ItemUOMSetFullName { get; set; }
        public string ItemUOMSetListID { get; set; }
        public string ItemIsGetPrintItemsInGroup { get; set; }
        public Nullable<System.DateTime> TimeModified { get; set; }
    }
}
