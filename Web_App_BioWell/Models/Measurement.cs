//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Web_App_BioWell.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Measurement
    {
        public System.DateTime Date { get; set; }
        public string Patient_Username { get; set; }
        public Nullable<double> Height { get; set; }
        public Nullable<double> Weight { get; set; }
        public Nullable<double> Body_Mass_Index { get; set; }
        public Nullable<double> Body_Fat_Percentage { get; set; }
        public Nullable<double> Fat_Free_Percentage { get; set; }
    }
}
