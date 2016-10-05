namespace LPipe.UI.Areas.Mvc.Controllers.Domain
{
    using LPipe.Contracts;
    using LPipe.Domain.MaterialsAggregate;
    using LPipe.Services;
    using LPipe.UI.Areas.Mvc.ViewModels.Materials;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using LPipe.Data.MsSql.Repositories;
    using LPipe.Data.MsSql;
    using LPipe.Data.MsSql.Queries;
    using System.Net;

    public class MaterialController : Controller
    {
        private readonly IMaterialService _materialService;



        public MaterialController(IMaterialService materialService)
        {
            this._materialService = materialService;
        }



        // GET: Mvc/Material
        public ActionResult Index()
        {
            IEnumerable<MaterialViewModel> materials = this._materialService.Get()
                                         .ToList()
                                         .Select(m => MaterialViewModel.Map(m));
            return View(materials);
        }      



        // GET: Mvc/Material/Details/5
        public ActionResult Details(int? id)
        { 
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Material material = this._materialService.Get((int)id);
            if (material == null)
            {
                return HttpNotFound();
            }
            return View(MaterialViewModel.Map(material));
        }





        // GET: Mvc/Material/Create
        public ActionResult Create()
        {
            var materialViewModel = new MaterialViewModel();
            return this.View(materialViewModel);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            [Bind(Include = "Id,Name")] Material material)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _materialService.Create(material);
                    return RedirectToAction("Index");
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View(MaterialViewModel.Map(material));
            }
        }





        // GET: Materials/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Material material = this._materialService.Get((int)id);
            if (material == null)
            {
                return HttpNotFound();
            }
            return View(MaterialViewModel.Map(material));
        }

        // POST: Materials/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
            [Bind(Include = "Id,Name")] Material material)
        {
            try
            {
                if (ModelState.IsValid)
                {
                   _materialService.Edit(material);
                    return RedirectToAction("Index");
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View(MaterialViewModel.Map(material));
            }
        }
                  





        // GET: Mvc/Material/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Material material = this._materialService.Get((int)id);
            if (material == null)
            {
                return HttpNotFound();
            }
            return View(MaterialViewModel.Map(material));
        }


        // POST: Materials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                this._materialService.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Index");
            }
        }
    }
}
