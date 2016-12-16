using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TestShipping.Models
{
    public class ShippingDBContext : DbContext
    {
        public DbSet<Shipping> Shippings { get; set; }
    }
}