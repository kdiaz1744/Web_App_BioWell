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
    
    public partial class Message
    {
        public int messageId { get; set; }
        public string doctorUser { get; set; }
        public string patientUser { get; set; }
        public string subject { get; set; }
        public string messageBody { get; set; }
    }
}
