using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCproject.Models;

namespace MVCproject.Controllers
{
    public class Task_ManagerController : Controller
    {
        private TaskMangerEntities1 db = new TaskMangerEntities1();
        // GET: Task_Manager
        public ActionResult Index()
        {
            return View(db.Task_Managers.ToList());
        }

        // GET: Task_Manager/Details/5
        public ActionResult Details(int? id)
        {


            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Task_Manager task_Manager = db.Task_Managers.Find(id);
            if (task_Manager == null)
            {
                return HttpNotFound();
            }
            return View(task_Manager);
        }

        // GET: Task_Manager/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Task_Manager/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Description")] Task_Manager task_Manager)
        {
            if (ModelState.IsValid)
            {
                db.Task_Managers.Add(task_Manager);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(task_Manager);
        }

        // GET: Task_Manager/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Task_Manager task_Manager = db.Task_Managers.Find(id);
            if (task_Manager == null)
            {
                return HttpNotFound();
            }
            return View(task_Manager);
        }

        // POST: Task_Manager/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Description")] Task_Manager task_Manager)
        {
            if (ModelState.IsValid)
            {
                db.Entry(task_Manager).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(task_Manager);
        }

        // GET: Task_Manager/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Task_Manager task_Manager = db.Task_Managers.Find(id);
            if (task_Manager == null)
            {
                return HttpNotFound();
            }
            return View(task_Manager);
        }

        // POST: Task_Manager/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Task_Manager task_Manager = db.Task_Managers.Find(id);
            db.Task_Managers.Remove(task_Manager);
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
