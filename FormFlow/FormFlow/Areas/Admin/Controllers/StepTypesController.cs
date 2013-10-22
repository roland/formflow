using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FormFlow.Models;

namespace FormFlow.Areas.Admin.Controllers
{
    public class StepTypesController : Controller
    {
        private FormFlowEntities db = new FormFlowEntities();

        //
        // GET: /Admin/StepTypes/

        public ActionResult Index()
        {
            return View(db.StepTypes.ToList());
        }

        //
        // GET: /Admin/StepTypes/Details/5

        public ActionResult Details(Guid? id = null)
        {
            StepType steptype = db.StepTypes.Find(id);
            if (steptype == null)
            {
                return HttpNotFound();
            }
            return View(steptype);
        }

        //
        // GET: /Admin/StepTypes/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/StepTypes/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StepType steptype)
        {
            if (ModelState.IsValid)
            {
                steptype.ID = Guid.NewGuid();
                db.StepTypes.Add(steptype);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(steptype);
        }

        //
        // GET: /Admin/StepTypes/Edit/5

        public ActionResult Edit(Guid? id = null)
        {
            StepType steptype = db.StepTypes.Find(id);
            if (steptype == null)
            {
                return HttpNotFound();
            }
            return View(steptype);
        }

        //
        // POST: /Admin/StepTypes/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StepType steptype)
        {
            if (ModelState.IsValid)
            {
                db.Entry(steptype).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(steptype);
        }

        //
        // GET: /Admin/StepTypes/Delete/5

        public ActionResult Delete(Guid? id = null)
        {
            StepType steptype = db.StepTypes.Find(id);
            if (steptype == null)
            {
                return HttpNotFound();
            }
            return View(steptype);
        }

        //
        // POST: /Admin/StepTypes/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            StepType steptype = db.StepTypes.Find(id);
            db.StepTypes.Remove(steptype);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}