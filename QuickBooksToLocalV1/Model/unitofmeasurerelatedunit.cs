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
    
    public partial class unitofmeasurerelatedunit
    {
        public string ID { get; set; }
        public string UnitOfMeasureSetId { get; set; }
        public string RelatedUnit_Name { get; set; }
        public string RelatedUnit_Abbreviation { get; set; }
        public string RelatedUnit_ConversionRatio { get; set; }
        public Nullable<System.DateTime> TimeModified { get; set; }
    }
}
