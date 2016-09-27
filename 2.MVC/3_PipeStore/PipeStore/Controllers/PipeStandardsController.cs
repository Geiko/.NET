using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using PipeStore.Models;

namespace PipeStore.Controllers
{
    public class PipeStandardsController : Controller
    {
        private PipeDBContext db = new PipeDBContext();

        // GET: PipeStandards
        public ActionResult Index()
        {
            return View(db.PipeStandards.ToList());
        }

        // GET: PipeStandards/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PipeStandard pipeStandard = db.PipeStandards.Find(id);
            if (pipeStandard == null)
            {
                return HttpNotFound();
            }
            return View(pipeStandard);
        }

        // GET: PipeStandards/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PipeStandards/Create
        // To protect from overposting attacks, 
        // please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            [Bind(Include = "Id,Title")] PipeStandard pipeStandard)
        {
            if (ModelState.IsValid)
            {
                db.PipeStandards.Add(pipeStandard);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pipeStandard);
        }

        // GET: PipeStandards/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PipeStandard pipeStandard = db.PipeStandards.Find(id);
            if (pipeStandard == null)
            {
                return HttpNotFound();
            }
            return View(pipeStandard);
        }

        // POST: PipeStandards/Edit/5
        // To protect from overposting attacks, 
        // please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
            [Bind(Include = "Id,Title")] PipeStandard pipeStandard)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pipeStandard).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pipeStandard);
        }

        // GET: PipeStandards/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PipeStandard pipeStandard = db.PipeStandards.Find(id);
            if (pipeStandard == null)
            {
                return HttpNotFound();
            }
            return View(pipeStandard);
        }

        // POST: PipeStandards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PipeStandard pipeStandard = db.PipeStandards.Find(id);
            db.PipeStandards.Remove(pipeStandard);
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
