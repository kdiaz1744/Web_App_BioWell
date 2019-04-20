using Web_App_BioWell.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web.Mvc;
using System;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Web_App_BioWell.Controllers
{
    public class GraphController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ContentResult JSON()
        {
            List<DataPoint> dataPoints = new List<DataPoint>();

            /*The JavaScript date is based on a time value that is milliseconds since 
             midnight January 1, 1970, UTC.
             * A day holds 86,400,000 milliseconds.
             December 17th,2018 is 1545071400000*/

            //double x = 1481999400000;
            //double y = 86400000;
            //dataPoints.Add(new DataPoint(x + y, 280));

            dataPoints.Add(new DataPoint(1481999400000, 290));
            dataPoints.Add(new DataPoint(1482604200000, 290));
            dataPoints.Add(new DataPoint(1483209000000, 286));
            dataPoints.Add(new DataPoint(1483813800000, 287));
            dataPoints.Add(new DataPoint(1484418600000, 282));
            dataPoints.Add(new DataPoint(1485023400000, 279));
            dataPoints.Add(new DataPoint(1485628200000, 275));
            dataPoints.Add(new DataPoint(1486233000000, 269));
            dataPoints.Add(new DataPoint(1486837800000, 261));
            dataPoints.Add(new DataPoint(1487442600000, 255));
            dataPoints.Add(new DataPoint(1488047400000, 250));
            dataPoints.Add(new DataPoint(1488652200000, 243));
            dataPoints.Add(new DataPoint(1489257000000, 237));
            dataPoints.Add(new DataPoint(1489861800000, 240));
            dataPoints.Add(new DataPoint(1490466600000, 239));
            dataPoints.Add(new DataPoint(1491071400000, 238));
            dataPoints.Add(new DataPoint(1491676200000, 240));
            dataPoints.Add(new DataPoint(1492281000000, 232));
            dataPoints.Add(new DataPoint(1492885800000, 223));
            dataPoints.Add(new DataPoint(1493490600000, 216));
            dataPoints.Add(new DataPoint(1494095400000, 209));
            dataPoints.Add(new DataPoint(1494700200000, 203));
            dataPoints.Add(new DataPoint(1495305000000, 200));
            dataPoints.Add(new DataPoint(1495909800000, 195));
            dataPoints.Add(new DataPoint(1496514600000, 190));
            dataPoints.Add(new DataPoint(1497119400000, 184));
            dataPoints.Add(new DataPoint(1497724200000, 180));
            dataPoints.Add(new DataPoint(1498329000000, 173));
            dataPoints.Add(new DataPoint(1498933800000, 168));
            dataPoints.Add(new DataPoint(1499538600000, 164));
            dataPoints.Add(new DataPoint(1500143400000, 165));
            dataPoints.Add(new DataPoint(1500748200000, 169));
            dataPoints.Add(new DataPoint(1501353000000, 171));
            dataPoints.Add(new DataPoint(1501957800000, 170));
            dataPoints.Add(new DataPoint(1502562600000, 169));
            dataPoints.Add(new DataPoint(1503167400000, 163));
            dataPoints.Add(new DataPoint(1503772200000, 158));
            dataPoints.Add(new DataPoint(1504377000000, 155));
            dataPoints.Add(new DataPoint(1504981800000, 150));
            dataPoints.Add(new DataPoint(1505586600000, 149));
            dataPoints.Add(new DataPoint(1506191400000, 150));
            dataPoints.Add(new DataPoint(1506796200000, 143));
            dataPoints.Add(new DataPoint(1507401000000, 140));
            dataPoints.Add(new DataPoint(1508005800000, 139));
            dataPoints.Add(new DataPoint(1508610600000, 138));
            dataPoints.Add(new DataPoint(1509215400000, 137));
            dataPoints.Add(new DataPoint(1509820200000, 138));
            dataPoints.Add(new DataPoint(1510425000000, 140));
            dataPoints.Add(new DataPoint(1511029800000, 141));
            dataPoints.Add(new DataPoint(1511634600000, 143));
            dataPoints.Add(new DataPoint(1512239400000, 145));
            dataPoints.Add(new DataPoint(1512844200000, 144));
            dataPoints.Add(new DataPoint(1513449000000, 145));
            dataPoints.Add(new DataPoint(1513621800000, 146));


            JsonSerializerSettings _jsonSetting = new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore };
            return Content(JsonConvert.SerializeObject(dataPoints, _jsonSetting), "application/json");
        }
    }
    //---------- Graph Controller ends --------------

}