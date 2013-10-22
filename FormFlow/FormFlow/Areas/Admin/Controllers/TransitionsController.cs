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
    public class TransitionsController : Controller
    {
        private FormFlowEntities db = new FormFlowEntities();

        //
        // GET: /Admin/Transitions/

        public ActionResult Index()
        {
            var transitions = db.Transitions.Include(t => t.FromStep).Include(t => t.ToStep).Include(t => t.TransitionType);
            return View(transitions.ToList());
        }

        //
        // GET: /Admin/Transitions/Details/5

        public ActionResult Details(Guid? id = null)
        {
            Transition transition = db.Transitions.Find(id);
            if (transition == null)
            {
                return HttpNotFound();
            }
            return View(transition);
        }

        //
        // GET: /Admin/Transitions/Create

        public ActionResult Create()
        {
            ViewBag.FromStepID = new SelectList(db.Steps, "ID", "ID");
            ViewBag.ToStepID = new SelectList(db.Steps, "ID", "ID");
            ViewBag.TranistionTypeID = new SelectList(db.TransitionTypes, "ID", "Name");
            return View();
        }

        //
        // POST: /Admin/Transitions/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Transition transition)
        {
            if (ModelState.IsValid)
            {
                transition.ID = Guid.NewGuid();
                db.Transitions.Add(transition);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FromStepID = new SelectList(db.Steps, "ID", "ID", transition.FromStepID);
            ViewBag.ToStepID = new SelectList(db.Steps, "ID", "ID", transition.ToStepID);
            ViewBag.TranistionTypeID = new SelectList(db.TransitionTypes, "ID", "Name", transition.TranistionTypeID);
            return View(transition);
        }

        //
        // GET: /Admin/Transitions/Edit/5

        public ActionResult Edit(Guid? id = null)
        {
            Transition transition = db.Transitions.Find(id);
            if (transition == null)
            {
                return HttpNotFound();
            }
            ViewBag.FromStepID = new SelectList(db.Steps, "ID", "ID", transition.FromStepID);
            ViewBag.ToStepID = new SelectList(db.Steps, "ID", "ID", transition.ToStepID);
            ViewBag.TranistionTypeID = new SelectList(db.TransitionTypes, "ID", "Name", transition.TranistionTypeID);
            return View(transition);
        }

        //
        // POST: /Admin/Transitions/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Transition transition)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transition).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FromStepID = new SelectList(db.Steps, "ID", "ID", transition.FromStepID);
            ViewBag.ToStepID = new SelectList(db.Steps, "ID", "ID", transition.ToStepID);
            ViewBag.TranistionTypeID = new SelectList(db.TransitionTypes, "ID", "Name", transition.TranistionTypeID);
            return View(transition);
        }

        //
        // GET: /Admin/Transitions/Delete/5

        public ActionResult Delete(Guid? id = null)
        {
            Transition transition = db.Transitions.Find(id);
            if (transition == null)
            {
                return HttpNotFound();
            }
            return View(transition);
        }

        //
        // POST: /Admin/Transitions/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Transition transition = db.Transitions.Find(id);
            db.Transitions.Remove(transition);
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