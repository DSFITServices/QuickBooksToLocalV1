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
    
    public partial class buildassemblylineitem
    {
        public string ID { get; set; }
        public string BuildAssemblyId { get; set; }
        public string ComponentItemLineRet_ItemRef_ListID { get; set; }
        public string ComponentItemLineRet_ItemRef_FullName { get; set; }
        public string ComponentItemLineRet_InventorySiteRef_ListID { get; set; }
        public string ComponentItemLineRet_InventorySiteRef_FullName { get; set; }
        public string ComponentItemLineRet_Desc { get; set; }
        public Nullable<double> ComponentItemLineRet_QuantityOnHand { get; set; }
        public Nullable<double> ComponentItemLineRet_QuantityNeeded { get; set; }
        public Nullable<System.DateTime> TimeModified { get; set; }
    }
}
