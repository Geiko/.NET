using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using PagedList;
using TestShipping.Models;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.UI;

namespace TestShipping.Controllers
{
    public class ShippingsController : Controller
    {
        private ShippingDBContext db = new ShippingDBContext();
        private const int PAGE_SIZE = 10;
        private const int MONTH_QUANTITY = 12;
        private const int DEFAULT_MONTH = 1;

        // GET: Shippings
        public ActionResult Index(
            string departureCity,
            string purposeCity,
            string customer,
            string carrier,
            string month,
            int? page)
        {
            var monthList = getMonthList();
            var departureList = getDepartureList();
            var purposeList = getPurposeList();
            var customersList = getCustomersList();
            var carriersList = getCarriersList();

            departureCity = getSelectedFilter(departureCity, "departureCityFilter");
            purposeCity = getSelectedFilter(purposeCity, "purposeCityFilter");
            customer = getSelectedFilter(customer, "customerFilter");
            carrier = getSelectedFilter(carrier, "carrierFilter");
            month = getSelectedFilter(month, "monthFilter");

            List<Shipping> shippings =
                getShippings(month, departureCity, purposeCity, customer, carrier);
                        
            TempData["ShippingsList"] = shippings;
            int pageNumber = (page ?? 1);
            ShippingViewModel shipViewModel = new ShippingViewModel
            {
                Shippings = shippings.ToPagedList(pageNumber, PAGE_SIZE),
                DepartureCities = new SelectList(departureList),
                PurposeCities = new SelectList(purposeList),
                Customers = new SelectList(customersList),
                Carriers = new SelectList(carriersList),
                Month = new SelectList(monthList),
                SelectedDepartureFilter = departureCity,
                SelectedPurposeFilter = purposeCity,
                SelectedCustomerFilter = customer,
                SelectedCarrierFilter = carrier,
                SelectedMonthFilter = month
            };

            return View(shipViewModel);
        }

        private List<Shipping> getShippings
            (string month, string departureCity, string purposeCity, string customer, string carrier)
        {
            List<Shipping> shippings = null;
            if (string.IsNullOrEmpty(month))
            {
                shippings = db.Shippings.Where(s => s.Month == DEFAULT_MONTH).ToList();
            }
            else
            {
                int monthNumber = int.Parse(month);
                shippings = db.Shippings
                    .Where(s => s.Month == monthNumber)
                    .Where(s => s.Departure == departureCity || departureCity.Equals("All"))
                    .Where(s => s.Purpose == purposeCity || purposeCity.Equals("All"))
                    .Where(s => s.Customer == customer || customer.Equals("All"))
                    .Where(s => s.Carrier == carrier || carrier.Equals("All")).ToList();
            }

            return shippings;
        }

        private string getSelectedFilter(string category, string categoryFilter)
        {
            if (category != null)
            {
                TempData[categoryFilter] = category;
                TempData.Keep();
            }
            else
            {
                if (TempData[categoryFilter] != null)
                {
                    category = TempData.Peek(categoryFilter).ToString();
                    TempData.Keep();
                }
            }

            return category;
        }

        private List<int> getMonthList()
        {
            return db.Shippings.Select(s => s.Month)
                                        .Distinct()
                                        .OrderBy(s => s).ToList();
        }

        private List<string> getDepartureList()
        {
            var departureList = db.Shippings.Select(s => s.Departure)
                                            .Distinct()
                                            .OrderBy(s => s).ToList();
            departureList.Insert(0, "All");
            return departureList;
        }

        private List<string> getCustomersList()
        {
            var customerList = db.Shippings.Select(s => s.Customer)
                                            .Distinct()
                                            .OrderBy(s => s).ToList();
            customerList.Insert(0, "All");
            return customerList;
        }

        private List<string> getPurposeList()
        {
            var purposeCitiesList = db.Shippings.Select(s => s.Purpose)
                                            .Distinct()
                                            .OrderBy(s => s).ToList();
            purposeCitiesList.Insert(0, "All");
            return purposeCitiesList;
        }

        private List<string> getCarriersList()
        {
            var carrierCitiesList = db.Shippings.Select(s => s.Carrier)
                                            .Distinct()
                                            .OrderBy(s => s).ToList();
            carrierCitiesList.Insert(0, "All");
            return carrierCitiesList;
        }

        public void ExportToExcel()
        {
            var gv = new GridView();
            gv.DataSource = TempData.Peek("ShippingsList") as List<Shipping>;
            gv.DataBind();
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=Shippings.xls");
            Response.ContentType = "application/ms-excel";
            Response.Charset = "";
            StringWriter objStringWriter = new StringWriter();
            HtmlTextWriter objHtmlTextWriter = new HtmlTextWriter(objStringWriter);
            gv.RenderControl(objHtmlTextWriter);
            Response.Output.Write(objStringWriter.ToString());
            Response.Flush();
            Response.End();
        }

        // GET: Shippings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Shipping shipping = db.Shippings.Find(id);
            if (shipping == null)
            {
                return HttpNotFound();
            }

            return View(shipping);
        }

        // GET: Shippings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Shippings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Month,Year,Departure,Purpose,Customer,Carrier,ScheduledTraffic,ActualTraffic,Day1Tons,Day2Tons,Day3Tons,Day4Tons,Day5Tons,Day6Tons,Day7Tons,Day8Tons,Day9Tons,Day10Tons,Day11Tons,Day12Tons,Day13Tons,Day14Tons,Day15Tons,Day16Tons,Day17Tons,Day18Tons,Day19Tons,Day20Tons,Day21Tons,Day22Tons,Day23Tons,Day24Tons,Day25Tons,Day26Tons,Day27Tons,Day28Tons,Day29Tons,Day30Tons,Day31Tons")] Shipping shipping)
        {
            if (ModelState.IsValid)
            {
                db.Shippings.Add(shipping);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(shipping);
        }

        // GET: Shippings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shipping shipping = db.Shippings.Find(id);
            if (shipping == null)
            {
                return HttpNotFound();
            }
            return View(shipping);
        }

        // POST: Shippings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Month,Year,Departure,Purpose,Customer,Carrier,ScheduledTraffic,ActualTraffic,Day1Tons,Day2Tons,Day3Tons,Day4Tons,Day5Tons,Day6Tons,Day7Tons,Day8Tons,Day9Tons,Day10Tons,Day11Tons,Day12Tons,Day13Tons,Day14Tons,Day15Tons,Day16Tons,Day17Tons,Day18Tons,Day19Tons,Day20Tons,Day21Tons,Day22Tons,Day23Tons,Day24Tons,Day25Tons,Day26Tons,Day27Tons,Day28Tons,Day29Tons,Day30Tons,Day31Tons")] Shipping shipping)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shipping).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shipping);
        }

        // GET: Shippings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shipping shipping = db.Shippings.Find(id);
            if (shipping == null)
            {
                return HttpNotFound();
            }
            return View(shipping);
        }

        // POST: Shippings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Shipping shipping = db.Shippings.Find(id);
            db.Shippings.Remove(shipping);
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
