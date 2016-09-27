using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using PipeStore.Models;
using PipeStore.ViewModels;

namespace PipeStore.Controllers
{
    public class PipesController : Controller
    {
        private PipeDBContext db = new PipeDBContext();

        // GET: Pipes
        public ActionResult Index(
            int? materialId, int? standardId, string searchString)
        {
            var pipes = db.Pipes.Include(p => p.PipeStandard);            
            if (!String.IsNullOrEmpty(searchString))
            {
                pipes = pipes.Where(p => p.Size.Contains(searchString));
            }

            if (materialId != null && materialId != 0)
            {
                pipes = pipes.Where(p => p.MaterialId == materialId);
            }

            if (standardId != null && standardId != 0)
            {
                pipes = pipes.Where(p => p.PipeStandardId == standardId);
            }

            var materials = db.Materials.ToList();
            materials.Insert(0, new Material { Name = "All" });
            var standards = db.PipeStandards.ToList();
            standards.Insert(0, new PipeStandard { Title = "All" });
            PipeListViewModel plvModel = new PipeListViewModel
            {
                Pipes = pipes.ToList(),
                PipeStandards = new SelectList(standards, "Id", "Title", 0),
                Materials = new SelectList(materials, "Id", "Name", 0)
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
            List<PipeStandard> standards = db.PipeStandards.ToList();
            List<Material> materials = db.Materials.ToList();
            PipeListViewModel plvModel = new PipeListViewModel
            {
                PipeStandards = new SelectList(standards, "Id", "Title"),
                Materials = new SelectList(materials, "Id", "Name")
            };

            return View(plvModel);
        }

        // POST: Pipes/Create
        // To protect from overposting attacks, 
        // please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include ="Id,Size,PipeStandard,PipeStandardId,Material,MaterialId,Manufacturer,ReleaseDate,Material,Price,InStock,ImageUrl")] Pipe pipe)
        {
            if (ModelState.IsValid)
            {
                db.Pipes.Add(pipe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            PipeListViewModel plvModel = new PipeListViewModel
            {
                Pipe = pipe
            };

            return View(plvModel);
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

            List<PipeStandard> standards = db.PipeStandards.ToList();
            List<Material> materials = db.Materials.ToList();
            PipeListViewModel plvModel = new PipeListViewModel
            {
                Pipe = pipe,
                PipeStandards = new SelectList(standards, "Id", "Title"),
                Materials = new SelectList(materials, "Id", "Name")
            };
            return View(plvModel);
        }

        // POST: Pipes/Edit/5
        // To protect from overposting attacks, 
        // please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Size,PipeStandard,PipeStandardId,Material,MaterialId,Manufacturer,ReleaseDate,Material,Price,InStock,ImageUrl")] Pipe pipe)
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
