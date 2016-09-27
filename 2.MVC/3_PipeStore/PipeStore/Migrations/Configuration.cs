namespace PipeStore.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PipeStore.Models.PipeDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(PipeStore.Models.PipeDBContext context)
        {
            context.Materials.AddOrUpdate(
                new Material { Name = "st.20" },
                new Material { Name = "st.45" },
                new Material { Name = "st.12X18H10T" },
                new Material { Name = "st.10X23H18" },
                new Material { Name = "st.10X17H13M2T" },
                new Material { Name = "Copper M1" },
                new Material { Name = "Aluminum 3000" },
                new Material { Name = "BT-1-0" },
                new Material { Name = "Zirconium" },
                new Material { Name = "PVC" }
            );

            context.PipeStandards.AddOrUpdate(
                new PipeStandard { Title = "Gost 3262-78" },
                new PipeStandard { Title = "Gost 8732-78" },
                new PipeStandard { Title = "Gost 9940-78" },
                new PipeStandard { Title = "ANSI 56894" },
                new PipeStandard { Title = "ANSI 65432" },
                new PipeStandard { Title = "DSTU 9940-2000" },
                new PipeStandard { Title = "TU 14-3-456-87" }
            );

            context.Pipes.AddOrUpdate(i => i.Size,
                 new Pipe
                 {
                     Size = "325x15xndl mm",
                     Manufacturer = "China",
                     ReleaseDate = DateTime.Parse("2015-1-11"),
                     Price = 1898.60M,
                     InStock = 8330,
                     ImageUrl = "/Content/img/big_steel.jpg"
                 },

               new Pipe
               {
                   Size = "159x6x9000 mm",
                   Manufacturer = "Italy",
                   ReleaseDate = DateTime.Parse("2016-5-12"),
                   Price = 6744.20M,
                   InStock = 5232,
                   ImageUrl = "/Content/img/stainless.jpg"
               },

               new Pipe
               {
                   Size = "32x6xndl mm",
                   Manufacturer = "Ukraine",
                   ReleaseDate = DateTime.Parse("2012-9-06"),
                   Price = 12476.20M,
                   InStock = 158,
                   ImageUrl = "/Content/img/copper.jpg"
               },

               new Pipe
               {
                   Size = "3/4\"x3,2x6000 mm",
                   Manufacturer = "China",
                   ReleaseDate = DateTime.Parse("2016-7-06"),
                   Price = 3476.20M,
                   InStock = 786,
                   ImageUrl = "/Content/img/pvc.jpg"
               },

                 new Pipe
                 {
                     Size = "219x10x2000x5000 mm",
                     Manufacturer = "Russia",
                     ReleaseDate = DateTime.Parse("2015-5-12"),
                     Price = 1999.20M,
                     InStock = 7232,
                     ImageUrl = "/Content/img/boile.jpg"
                 },

               new Pipe
               {
                   Size = "25p x 2p x 6000 mm",
                   Manufacturer = "Ukraine",
                   ReleaseDate = DateTime.Parse("2016-9-06"),
                   Price = 50476.20M,
                   InStock = 38,
                   ImageUrl = "Content/img/titan.jpg"
               },

               new Pipe
               {
                   Size = "14v x 2v x 4000 mm",
                   Manufacturer = "Ukraine",
                   ReleaseDate = DateTime.Parse("2016-9-06"),
                   Price = 103476.20M,
                   InStock = 456,
                   ImageUrl = "/Content/img/Zirconium.jpg"
               },

               new Pipe
               {
                   Size = "133x6xndl mm",
                   Manufacturer = "Germany",
                   ReleaseDate = DateTime.Parse("2016-5-12"),
                   Price = 15888.20M,
                   InStock = 3232,
                   ImageUrl = "/Content/img/stainless.jpg"
               },

               new Pipe
               {
                   Size = "8v x 1p x ndl mm",
                   Manufacturer = "Ukraine",
                   ReleaseDate = DateTime.Parse("2003-9-06"),
                   Price = 17476.20M,
                   InStock = 45,
                   ImageUrl = "/Content/img/copper.jpg"
               },

               new Pipe
               {
                   Size = "108x5xndl mm",
                   Manufacturer = "China",
                   ReleaseDate = DateTime.Parse("2016-2-12"),
                   Price = 16888.20M,
                   InStock = 2232,
                   ImageUrl = "/Content/img/stainless.jpg"
               },

               new Pipe
               {
                   Size = "108x8x3000-6000 mm",
                   Manufacturer = "Ukraine",
                   ReleaseDate = DateTime.Parse("2003-9-06"),
                   Price = 4667.20M,
                   InStock = 145,
                   ImageUrl = "/Content/img/aluminum.jpg"
               },

                new Pipe
                {
                    Size = "630x50x6000 mm",
                    Manufacturer = "Russia",
                    ReleaseDate = DateTime.Parse("2014-1-11"),
                    Price = 1578.33M,
                    InStock = 9232,
                    ImageUrl = "/Content/img/big_steel2.jpg"
                }
           );
        }
    }
}
