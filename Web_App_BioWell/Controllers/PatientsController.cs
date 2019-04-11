using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.Mvc;
using Web_App_BioWell.Models;
using System.Data.Entity;

namespace Web_App_BioWell.Controllers
{
    public class PatientsController : BaseController
    {
        // GET: Patients
        public ActionResult Index()
        {
            return View(DataBase.Patients.ToList());
        }

        // GET: Patients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatientsModel patients = DataBase.Patients.Find(id);
            if (patients == null)
            {
                return HttpNotFound();
            }
            return View(patients);
        }

        // GET: Patients/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Patients/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "FirstName,LastName,Address,Email,Phone")] PatientsModel patients)
        {
            if (ModelState.IsValid)
            {
                DataBase.Patients.Add(patients);
                DataBase.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(patients);
        }

        // GET: Patients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatientsModel patients = DataBase.Patients.Find(id);
            if (patients == null)
            {
                return HttpNotFound();
            }
            return View(patients);
        }

        // POST: Patients/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "FirstName,LastName,Address,Email,Phone")] PatientsModel patients, int id)
        {
            patients = DataBase.Patients.FirstOrDefault(x => x.PatientID == id);
            if (ModelState.IsValid)
            {
                DataBase.Entry(patients).State = EntityState.Modified;
                DataBase.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(patients);
        }

        // GET: Patients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatientsModel patients = DataBase.Patients.Find(id);
            if (patients == null)
            {
                return HttpNotFound();
            }
            return View(patients);
        }

        // POST: Patients/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                PatientsModel patients = DataBase.Patients.Find(id);
                DataBase.Patients.Remove(patients);
                DataBase.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
