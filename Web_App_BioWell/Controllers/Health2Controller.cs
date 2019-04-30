using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Web_App_BioWell.Models;

namespace Web_App_BioWell.Controllers
{
    public class Health2Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private UserManager<ApplicationUser> manager;

        public Health2Controller()
        {
            manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
        }

        // GET: Health2
        public ActionResult Index()
        {
            var currentUser = manager.FindById(User.Identity.GetUserId());

            return View(db.HealthData.ToList().Where(req => req.PatientId == currentUser.Id));
        }

        // GET: Health2/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HealthData healthData = db.HealthData.Find(id);
            if (healthData == null)
            {
                return HttpNotFound();
            }
            return View(healthData);
        }

        // GET: Health2/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Health2/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DataId,PatientId,DataDate,DataWeight,DataBmi")] HealthData healthData)
        {
            if (ModelState.IsValid)
            {
                var currentUser = manager.FindById(User.Identity.GetUserId());
                healthData.PatientId = currentUser.Id;

                db.HealthData.Add(healthData);
                db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(healthData);
        }

        // GET: Health2/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HealthData healthData = db.HealthData.Find(id);
            if (healthData == null)
            {
                return HttpNotFound();
            }
            return View(healthData);
        }

        // POST: Health2/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DataId,PatientId,DataDate,DataWeight,DataBmi")] HealthData healthData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(healthData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(healthData);
        }

        // GET: Health2/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HealthData healthData = db.HealthData.Find(id);
            if (healthData == null)
            {
                return HttpNotFound();
            }
            return View(healthData);
        }

        // POST: Health2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HealthData healthData = db.HealthData.Find(id);
            db.HealthData.Remove(healthData);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        // GET: Home for 
        public ActionResult GraphWeight()
        {
            return View();
        }

        public ActionResult GraphBMI()
        {
            return View();
        }

        public ContentResult JSON()
        {
            //Creating dataPoint list so it can be sent to view
            List<DataPoint> dataPoints = new List<DataPoint>();

            //These are the lines of code that will help me filter out value results on User ID
            var currentUser = manager.FindById(User.Identity.GetUserId());
            List<HealthData> UData =new List<HealthData>(db.HealthData.ToList().Where(req => req.PatientId == currentUser.Id));

            //creating arrays full of database values that will be put into dataPoint list
            DateTime[] dates = UData.Select(req => req.DataDate).ToArray();
            Double[] weights = UData.Select(req => req.DataWeight).ToArray();
            Double[] bmi = UData.Select(req => req.DataBmi).ToArray();

            //Populating List
            for (int i = 0; i < weights.Length; i++)
            {
                dataPoints.Add(new DataPoint(dates[i], weights[i], bmi[i]));
                
            }

            JsonSerializerSettings _jsonSetting = new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore };
            return Content(JsonConvert.SerializeObject(dataPoints, _jsonSetting), "application/json");
        }


    }
}
