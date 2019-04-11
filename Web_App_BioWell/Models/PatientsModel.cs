using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web_App_BioWell.Models
{
    public class PatientsModel
    {
        [Key]
        public int PatientID { get; set; }

        [Required, MaxLength(40)]
        public string FirstName { get; set; }

        [Required, MaxLength(40)]
        public string LastName { get; set; }

        [Required, MaxLength(40)]
        public string Address { get; set; }

        [Required, MaxLength(40)]
        public string Email { get; set; }

        [Required, MaxLength(40)]
        public string Phone { get; set; }
    }
}