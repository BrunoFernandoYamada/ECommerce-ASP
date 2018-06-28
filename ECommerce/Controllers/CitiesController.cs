using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ECommerce.Classes;
using ECommerce.Models;

namespace ECommerce.Controllers
{
    public class CitiesController : Controller
    {
        private ECommerceContext db = new ECommerceContext();

        // GET: Cities
        public ActionResult Index()
        {
            var cities = db.Cities.Include(c => c.Department);
            return View(cities.ToList());
        }

        // GET: Cities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cities cities = db.Cities.Find(id);
            if (cities == null)
            {
                return HttpNotFound();
            }
            return View(cities);
        }

        // GET: Cities/Create
        public ActionResult Create()
        {

            ViewBag.DepartmentsId = new SelectList(ComboHelper.GetDepartments(), "DepartmentsId", "Name");
            return View();
        }

        // POST: Cities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CityId,Name,DepartmentsId")] Cities cities)
        {
            if (ModelState.IsValid)
            {
                db.Cities.Add(cities);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
         
            ViewBag.DepartmentsId = new SelectList(ComboHelper.GetDepartments(), "DepartmentsId", "Name");
            return View();
        }

        // GET: Cities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cities cities = db.Cities.Find(id);
            if (cities == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentsId = new SelectList(ComboHelper.GetDepartments(), "DepartmentsId", "Name", cities.DepartmentsId);
            return View(cities);
        }

        // POST: Cities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CityId,Name,DepartmentsId")] Cities cities)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cities).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentsId = new SelectList(ComboHelper.GetDepartments(), "DepartmentsId", "Name", cities.DepartmentsId);
            return View(cities);
        }

        // GET: Cities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cities cities = db.Cities.Find(id);
            if (cities == null)
            {
                return HttpNotFound();
            }
            return View(cities);
        }

        // POST: Cities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cities cities = db.Cities.Find(id);
            db.Cities.Remove(cities);
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
    }
}
