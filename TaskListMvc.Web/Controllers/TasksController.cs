using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TaskListMvc.Data;
using TaskListMvc.Model;
using TaskListMvc.Web.Infrastructure;

namespace TaskListMvc.Web.Controllers
{
    public class TasksController : StandardController
    {
        private TaskListContext db = new TaskListContext();

        public ActionResult Index()
        {
            return View();
        }

        // POST: Tasks/Read
        [HttpPost]
        public ActionResult Read()
        {
            var tasks = db.Tasks.ToList();
            return JsonSuccess(new { tasks = tasks });
        }

        // POST: Tasks/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "Title")] Task task)
        {
            if (ModelState.IsValid)
            {
                db.Tasks.Add(task);
                db.SaveChanges();
                return JsonSuccess ( new { task = task } );
            }

            return JsonError("Model is invalid");
        }

        // POST: Tasks/Update
        [HttpPost]
        public ActionResult Update([Bind(Include = "Id,IsDone")] Task task)
        {
            if (ModelState.IsValid)
            {
                db.Tasks.Attach(task);
                db.Entry(task).Property(t => t.IsDone).IsModified = true;
                db.Configuration.ValidateOnSaveEnabled = false;
                db.SaveChanges();
                return JsonSuccess(new { task = task });
            }
            return JsonError("Model is invalid");
        }

        // POST: Tasks/Delete
        [HttpPost]
        public ActionResult Delete(int id)
        {
            Task task = db.Tasks.Find(id);
            db.Tasks.Remove(task);
            db.SaveChanges();
            return JsonSuccess(new { task = task });
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
