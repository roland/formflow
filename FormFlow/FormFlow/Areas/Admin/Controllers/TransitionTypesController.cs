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
    public class TransitionTypesController : Controller
    {
        private FormFlowEntities db = new FormFlowEntities();

        //
        // GET: /Admin/TransitionTypes/

        public ActionResult Index()
        {
            return View(db.TransitionTypes.ToList());
        }

        //
        // GET: /Admin/TransitionTypes/Details/5

        public ActionResult Details(Guid? id = null)
        {
            TransitionType transitiontype = db.TransitionTypes.Find(id);
            if (transitiontype == null)
            {
                return HttpNotFound();
            }
            return View(transitiontype);
        }

        //
        // GET: /Admin/TransitionTypes/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/TransitionTypes/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TransitionType transitiontype)
        {
            if (ModelState.IsValid)
            {
                transitiontype.ID = Guid.NewGuid();
                db.TransitionTypes.Add(transitiontype);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(transitiontype);
        }

        //
        // GET: /Admin/TransitionTypes/Edit/5

        public ActionResult Edit(Guid? id = null)
        {
            TransitionType transitiontype = db.TransitionTypes.Find(id);
            if (transitiontype == null)
            {
                return HttpNotFound();
            }
            return View(transitiontype);
        }

        //
        // POST: /Admin/TransitionTypes/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TransitionType transitiontype)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transitiontype).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(transitiontype);
        }

        //
        // GET: /Admin/TransitionTypes/Delete/5

        public ActionResult Delete(Guid? id = null)
        {
            TransitionType transitiontype = db.TransitionTypes.Find(id);
            if (transitiontype == null)
            {
                return HttpNotFound();
            }
            return View(transitiontype);
        }

        //
        // POST: /Admin/TransitionTypes/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            TransitionType transitiontype = db.TransitionTypes.Find(id);
            db.TransitionTypes.Remove(transitiontype);
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