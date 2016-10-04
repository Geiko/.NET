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
using LPipe.Data.Contracts;
using LPipe.Data.Queries.Material;
using LPipe.Data.Queries.Common;
using LPipe.Data.MsSql.Queries;
using System.Net;

namespace LPipe.UI.Areas.Mvc.Controllers.Domain
{
    public class MaterialController : Controller
    {
        private readonly IMaterialService _materialService;


        public MaterialController()
        {
            IUnitOfWork unitOfWork = new LPipeUnitOfWork();
                      
            IQuery<Material, FindByIdCriteria> getMaterialByIdQuery =
                new MaterialQueries(unitOfWork);

            IQuery<List<Material>, GetAllCriteria> getAllMaterialsQuery =
                new MaterialQueries(unitOfWork);

            IMaterialRepository materialRepository = 
                new MaterialRepository(unitOfWork);

            IMaterialService materialService = 
                new MaterialService(
                    materialRepository, getAllMaterialsQuery, getMaterialByIdQuery);

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
            //return View(); 
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
            return View();
        }



        // POST: Mvc/Material/Create
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

        // GET: Mvc/Material/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Mvc/Material/Edit/5
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

        // GET: Mvc/Material/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Mvc/Material/Delete/5
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
