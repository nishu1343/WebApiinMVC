using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC.Context;
using MVC.Models;

namespace MVC.Controllers
{
    public class MvcEmployeeModelsController : Controller
    {
        private EmployeeManagementContext db = new EmployeeManagementContext();

        // GET: MvcEmployeeModels
        public ActionResult Index()
        {
            return View(db.EmployeeModels.ToList());
        }

        // GET: MvcEmployeeModels/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MvcEmployeeModel mvcEmployeeModel = db.EmployeeModels.Find(id);
            if (mvcEmployeeModel == null)
            {
                return HttpNotFound();
            }
            return View(mvcEmployeeModel);
        }

        // GET: MvcEmployeeModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MvcEmployeeModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeId,First_Name,Last_Name,Position,Age,Salary")] MvcEmployeeModel mvcEmployeeModel)
        {
            //    if (ModelState.IsValid)
            //    {
            //        mvcEmployeeModel.EmployeeId = Guid.NewGuid();
            //        db.EmployeeModels.Add(mvcEmployeeModel);
            //        db.SaveChanges();
            //        return RedirectToAction("Index");
            //    }

            //    return View(mvcEmployeeModel);
            //}

            mvcEmployeeModel.EmployeeId = Guid.NewGuid();
            var errors = ModelState
    .Where(x => x.Value.Errors.Count > 0)
    .Select(x => new { x.Key, x.Value.Errors })
    .ToArray();
            if (ModelState.IsValid)
            {
                db.EmployeeModels.Add(mvcEmployeeModel);

                db.SaveChanges();
            }
            return View(mvcEmployeeModel);
        }

        // GET: MvcEmployeeModels/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MvcEmployeeModel mvcEmployeeModel = db.EmployeeModels.Find(id);
            if (mvcEmployeeModel == null)
            {
                return HttpNotFound();
            }
            return View(mvcEmployeeModel);
        }

        // POST: MvcEmployeeModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeId,First_Name,Last_Name,Position,Age,Salary")] MvcEmployeeModel mvcEmployeeModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mvcEmployeeModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mvcEmployeeModel);
        }

        // GET: MvcEmployeeModels/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MvcEmployeeModel mvcEmployeeModel = db.EmployeeModels.Find(id);
            if (mvcEmployeeModel == null)
            {
                return HttpNotFound();
            }
            return View(mvcEmployeeModel);
        }

        // POST: MvcEmployeeModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            MvcEmployeeModel mvcEmployeeModel = db.EmployeeModels.Find(id);
            db.EmployeeModels.Remove(mvcEmployeeModel);
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
