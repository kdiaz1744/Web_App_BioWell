//using System;
//using System.Web;

//namespace Web_App_BioWell.Models
//{


//}

using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web_App_BioWell.Models
{
    //--------------------Line Type Graph----------------------
    //DataContract for Serializing Data - required to serve in JSON format
    [DataContract]
    public class DataPoint
    {
        public DataPoint(DateTime x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        //Explicitly setting the name to be used while serializing to JSON.
        [DataMember(Name = "x")]
        public Nullable<DateTime> X = null;

        //Explicitly setting the name to be used while serializing to JSON.
        [DataMember(Name = "y")]
        public Nullable<double> Y = null;
    }

    public class HealthData
    {
        [Key]
        public int DataId { get; set; }

        public string PatientId { get; set; }

        [Display(Name = "Date")]
        public DateTime DataDate { get; set; }

        [Display(Name = "Weight")]
        public double DataWeight { get; set; }

        [Display(Name = "BMI")]
        public double DataBmi { get; set; }

    }
}