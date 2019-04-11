using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web_App_BioWell.Models
{
    public class MessagesModel
    {
        [Key]
        public int MessageID { get; set; }

        [Required, MaxLength(40)]
        public string MessageName { get; set; }
    }
}