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
    public class FlowsController : Controller
    {
        private FormFlowEntities db = new FormFlowEntities();

        //
        // GET: /Admin/Flows/

        public ActionResult Index()
        {
            return View(db.Flows.ToList());
        }

        //
        // GET: /Admin/Flows/Details/5

        public ActionResult Details(Guid? id = null)
        {
            Flow flow = db.Flows.Find(id);
            if (flow == null)
            {
                return HttpNotFound();
            }
            return View(flow);
        }

        //
        // GET: /Admin/Flows/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/Flows/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Flow flow)
        {
            if (ModelState.IsValid)
            {
                flow.ID = Guid.NewGuid();
                db.Flows.Add(flow);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(flow);
        }

        //
        // GET: /Admin/Flows/Edit/5

        public ActionResult Edit(Guid? id = null)
        {
            Flow flow = db.Flows.Find(id);
            if (flow == null)
            {
                return HttpNotFound();
            }
            return View(flow);
        }

        //
        // POST: /Admin/Flows/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Flow flow)
        {
            if (ModelState.IsValid)
            {
                db.Entry(flow).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(flow);
        }

        //
        // GET: /Admin/Flows/Delete/5

        public ActionResult Delete(Guid? id = null)
        {
            Flow flow = db.Flows.Find(id);
            if (flow == null)
            {
                return HttpNotFound();
            }
            return View(flow);
        }

        //
        // POST: /Admin/Flows/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Flow flow = db.Flows.Find(id);
            db.Flows.Remove(flow);
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