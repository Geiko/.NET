using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestShipping.Models
{
    public class ShippingViewModel
    {
        public int MAX_DAYS_IN_MONTH = 31;
        public Shipping Shipping { get; set; }
        public PagedList.IPagedList<Shipping> Shippings { get; set; }
        public SelectList Month { get; set; }
        public SelectList DepartureCities { get; set; }
        public SelectList PurposeCities { get; set; }                
        public SelectList Customers { get; set; }
        public SelectList Carriers { get; set; }
        public string SelectedMonthFilter { get; set; }
        public string SelectedDepartureFilter { get; set; }
        public string SelectedPurposeFilter { get; set; }
        public string SelectedCustomerFilter { get; set; }
        public string SelectedCarrierFilter { get; set; }
    }
}