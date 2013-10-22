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
    public class StepsController : Controller
    {
        private FormFlowEntities db = new FormFlowEntities();

        //
        // GET: /Admin/Steps/

        public ActionResult Index()
        {
            var steps = db.Steps.Include(s => s.Flow).Include(s => s.StepType);
            return View(steps.ToList());
        }

        //
        // GET: /Admin/Steps/Details/5

        public ActionResult Details(Guid? id = null)
        {
            Step step = db.Steps.Find(id);
            if (step == null)
            {
                return HttpNotFound();
            }
            return View(step);
        }

        //
        // GET: /Admin/Steps/Create

        public ActionResult Create()
        {
            ViewBag.FlowID = new SelectList(db.Flows, "ID", "Name");
            ViewBag.StepTypeID = new SelectList(db.StepTypes, "ID", "Name");
            return View();
        }

        //
        // POST: /Admin/Steps/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Step step)
        {
            if (ModelState.IsValid)
            {
                step.ID = Guid.NewGuid();
                db.Steps.Add(step);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FlowID = new SelectList(db.Flows, "ID", "Name", step.FlowID);
            ViewBag.StepTypeID = new SelectList(db.StepTypes, "ID", "Name", step.StepTypeID);
            return View(step);
        }

        //
        // GET: /Admin/Steps/Edit/5

        public ActionResult Edit(Guid? id = null)
        {
            Step step = db.Steps.Find(id);
            if (step == null)
            {
                return HttpNotFound();
            }
            ViewBag.FlowID = new SelectList(db.Flows, "ID", "Name", step.FlowID);
            ViewBag.StepTypeID = new SelectList(db.StepTypes, "ID", "Name", step.StepTypeID);
            return View(step);
        }

        //
        // POST: /Admin/Steps/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Step step)
        {
            if (ModelState.IsValid)
            {
                db.Entry(step).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FlowID = new SelectList(db.Flows, "ID", "Name", step.FlowID);
            ViewBag.StepTypeID = new SelectList(db.StepTypes, "ID", "Name", step.StepTypeID);
            return View(step);
        }

        //
        // GET: /Admin/Steps/Delete/5

        public ActionResult Delete(Guid? id = null)
        {
            Step step = db.Steps.Find(id);
            if (step == null)
            {
                return HttpNotFound();
            }
            return View(step);
        }

        //
        // POST: /Admin/Steps/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Step step = db.Steps.Find(id);
            db.Steps.Remove(step);
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