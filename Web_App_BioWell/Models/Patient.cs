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
    
    public partial class Patient
    {
        public string Patients_Username { get; set; }
        public string Doctor_Username { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }
        public string Password_Hash { get; set; }
        public string Salt { get; set; }
    }
}
