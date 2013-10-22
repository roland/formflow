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
    public class WebServicesController : Controller
    {
        private FormFlowEntities db = new FormFlowEntities();

        //
        // GET: /Admin/WebServices/

        public ActionResult Index()
        {
            return View(db.WebServices.ToList());
        }

        //
        // GET: /Admin/WebServices/Details/5

        public ActionResult Details(Guid? id = null)
        {
            WebService webservice = db.WebServices.Find(id);
            if (webservice == null)
            {
                return HttpNotFound();
            }
            return View(webservice);
        }

        //
        // GET: /Admin/WebServices/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/WebServices/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(WebService webservice)
        {
            if (ModelState.IsValid)
            {
                webservice.ID = Guid.NewGuid();
                db.WebServices.Add(webservice);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(webservice);
        }

        //
        // GET: /Admin/WebServices/Edit/5

        public ActionResult Edit(Guid? id = null)
        {
            WebService webservice = db.WebServices.Find(id);
            if (webservice == null)
            {
                return HttpNotFound();
            }
            return View(webservice);
        }

        //
        // POST: /Admin/WebServices/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(WebService webservice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(webservice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(webservice);
        }

        //
        // GET: /Admin/WebServices/Delete/5

        public ActionResult Delete(Guid? id = null)
        {
            WebService webservice = db.WebServices.Find(id);
            if (webservice == null)
            {
                return HttpNotFound();
            }
            return View(webservice);
        }

        //
        // POST: /Admin/WebServices/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            WebService webservice = db.WebServices.Find(id);
            db.WebServices.Remove(webservice);
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