using System.Web.Mvc;

namespace LibraryUI.Areas.Admin.Controllers
{
    public class OrdersController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        // GET: Admin/Orders/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Orders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Orders/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Orders/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Orders/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Orders/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Orders/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
