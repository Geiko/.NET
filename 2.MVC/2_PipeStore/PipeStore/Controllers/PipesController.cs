using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PipeStore.Models;

namespace PipeStore.Controllers
{
    public class PipesController : Controller
    {
        private PipeDBContext db = new PipeDBContext();

        // GET: Pipes
        public ActionResult Index(string pipeMaterial, string searchString, int? standardId)
        {           
            var materials = new List<string>();

            var MaterialQry = from d in db.Pipes
                           orderby d.Material
                           select d.Material;

            materials.AddRange(MaterialQry.Distinct());
            ViewBag.pipeMaterial = new SelectList(materials);

            var pipes = from p in db.Pipes
                         select p;

            if (!String.IsNullOrEmpty(searchString))
            {
                pipes = pipes.Where(p => p.Size.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(pipeMaterial))
            {
                pipes = pipes.Where(p => p.Material == pipeMaterial);
            }

            if (standardId != null && standardId != 0)
            {
                pipes = pipes.Where(p => p.StandardId == standardId);
            }

            List<Standard> standards = db.Standards.ToList();
            standards.Insert(0, new Standard { Title = "All" });

            PipeListViewModel plvModel = new PipeListViewModel
            {
                Pipes = pipes.ToList(),
                Standards = new SelectList(standards, "Id", "Title")
            };
            return View(plvModel);
        }

        // GET: Pipes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pipe pipe = db.Pipes.Find(id);
            if (pipe == null)
            {
                return HttpNotFound();
            }
            return View(pipe);
        }

        // GET: Pipes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pipes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Size,Standard,Manufacturer,ReleaseDate,Material,Price,InStock,ImageUrl")] Pipe pipe)
        {
            if (ModelState.IsValid)
            {
                db.Pipes.Add(pipe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pipe);
        }

        // GET: Pipes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pipe pipe = db.Pipes.Find(id);
            if (pipe == null)
            {
                return HttpNotFound();
            }
            return View(pipe);
        }

        // POST: Pipes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Size,Standard,Manufacturer,ReleaseDate,Material,Price,InStock,ImageUrl")] Pipe pipe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pipe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pipe);
        }

        // GET: Pipes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pipe pipe = db.Pipes.Find(id);
            if (pipe == null)
            {
                return HttpNotFound();
            }
            return View(pipe);
        }

        // POST: Pipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pipe pipe = db.Pipes.Find(id);
            db.Pipes.Remove(pipe);
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
