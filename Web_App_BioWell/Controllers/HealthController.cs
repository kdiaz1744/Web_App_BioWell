using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
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
    public class HealthController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private UserManager<ApplicationUser> manager;

        public HealthController()
        {
            manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
        }

        // GET: Health
        public async Task<ActionResult> Index()
        {
            return View(await db.HealthData.ToListAsync());
        }

        // GET: Health/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HealthData healthData = await db.HealthData.FindAsync(id);
            if (healthData == null)
            {
                return HttpNotFound();
            }
            return View(healthData);
        }

        // GET: Health/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Health/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "DataId,PatientId,DataDate,DataWeight,DataBmi")] HealthData healthData)
        {
            if (ModelState.IsValid)
            {
                var currentUser = manager.FindById(User.Identity.GetUserId());
                healthData.PatientId = currentUser.Id;

                db.HealthData.Add(healthData);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(healthData);
        }

        // GET: Health/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HealthData healthData = await db.HealthData.FindAsync(id);
            if (healthData == null)
            {
                return HttpNotFound();
            }
            return View(healthData);
        }

        // POST: Health/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "DataId,PatientId,DataDate,DataWeight,DataBmi")] HealthData healthData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(healthData).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(healthData);
        }

        // GET: Health/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HealthData healthData = await db.HealthData.FindAsync(id);
            if (healthData == null)
            {
                return HttpNotFound();
            }
            return View(healthData);
        }

        // POST: Health/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            HealthData healthData = await db.HealthData.FindAsync(id);
            db.HealthData.Remove(healthData);
            await db.SaveChangesAsync();
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

        // GET: Home
        public ActionResult Graph()
        {
            return View();
        }

        public ContentResult JSON()
        {
            List<DataPoint> dataPoints = new List<DataPoint>();



            //dataPoints.Add(new DataPoint(1513621800000, 146));



            /*The JavaScript Date() is based on a time value that is milliseconds since 
             midnight January 1, 1970, UTC.
             * A day holds 86,400,000 milliseconds.
             December 17th,2018 is 1545071400000*/

            //double x = 1481999400000;
            //double y = 86400000;
            //dataPoints.Add(new DataPoint(x + y, 280));

            //dataPoints.Add(new DataPoint(1481999400000, 290));



            JsonSerializerSettings _jsonSetting = new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore };
            return Content(JsonConvert.SerializeObject(dataPoints, _jsonSetting), "application/json");
        }
    }
}
