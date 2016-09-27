using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PipeStore.Models
{
    public class PipeInitializer : DropCreateDatabaseAlways<PipeDBContext>
    {
        protected override void Seed(PipeDBContext context)
        {
            Pipe p1 = new Pipe
            {
                Size = "325x15xndl mm",
                PipeStandardId = 0,
                Manufacturer = "China",
                ReleaseDate = DateTime.Parse("2015-1-11"),
                Material = "st.20",
                Price = 1898.60M,
                InStock = 8330,
                ImageUrl = "/Content/img/big_steel.jpg"
            };

            Pipe p2 = new Pipe
            {
                Size = "159x6x9000 mm",
                PipeStandardId = 0,
                Manufacturer = "Italy",
                ReleaseDate = DateTime.Parse("2016-5-12"),
                Material = "st.12X18H10T",
                Price = 6744.20M,
                InStock = 5232,
                ImageUrl = "/Content/img/stainless.jpg"
            };

            context.PipeStandards.Add(new PipeStandard()
            {
                Title = "3262",
                Pipes = new List<Pipe>() { p1 }
            });
            context.PipeStandards.Add(new PipeStandard()
            {
                Title = "5566",
                Pipes = new List<Pipe>() { p2 }
            });

            //context.Pipes

            //context.Products.Add(new Product() { Name = "Product 2", Price = 20 });
            //    context.Products.Add(new Product() { Name = "Product 3", Price = 30 });
            //    context.Products.Add(new Product() { Name = "Product 4", Price = 40 });

            base.Seed(context);
        }

    }
}