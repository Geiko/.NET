namespace PipeStore.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PipeStore.Models.PipeDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PipeStore.Models.PipeDBContext context)
        {
            context.Pipes.AddOrUpdate(i => i.Size,

                 new Pipe
                 {
                     Size = "325x15 mm ndl",
                     Standard = "GOST 8732-78",
                     ReleaseDate = DateTime.Parse("2015-1-11"),
                     Material = "st.20",
                     Price = 1898.60M,
                     Weight = 8330,
                     ImageUrl = "/Content/img/big_steel.jpg"
                 },

               new Pipe
               {
                   Size = "159x6x9000 mm",
                   Standard = "GOST 9940-81",
                   ReleaseDate = DateTime.Parse("2016-5-12"),
                   Material = "st.12X18H10T",
                   Price = 6744.20M,
                   Weight = 5232,
                   ImageUrl = "/Content/img/stainless.jpg"
               },

               new Pipe
               {
                   Size = "32x6 mm ndl",
                   Standard = "TU14-3-987-78",
                   ReleaseDate = DateTime.Parse("2012-9-06"),
                   Material = "Copper M1",
                   Price = 12476.20M,
                   Weight = 158,
                   ImageUrl = "/Content/img/copper.jpg"
               },

               new Pipe
               {
                   Size = "3/4\"",
                   Standard = "GOST 3262-78",
                   ReleaseDate = DateTime.Parse("2016-7-06"),
                   Material = "PVC",
                   Price = 3476.20M,
                   Weight = 786,
                   ImageUrl = "/Content/img/pvc.jpg"
               },

                 new Pipe
                 {
                     Size = "219x10x2000x5000 mm",
                     Standard = "GOST 8732-78",
                     ReleaseDate = DateTime.Parse("2015-5-12"),
                     Material = "st.45",
                     Price = 1999.20M,
                     Weight = 7232,
                     ImageUrl = "/Content/img/boile.jpg"
                 },

               new Pipe
               {
                   Size = "25p x 2p x 6000 mm",
                   Standard = "TU 14-3-654-78",
                   ReleaseDate = DateTime.Parse("2016-9-06"),
                   Material = "BT-1-0",
                   Price = 50476.20M,
                   Weight = 38,
                   ImageUrl = "Content/img/titan.jpeg"
               },

               new Pipe
               {
                   Size = "14 v x 2v x 4000 mm",
                   Standard = "TU14-3-654-78",
                   ReleaseDate = DateTime.Parse("2016-9-06"),
                   Material = "Zirconium",
                   Price = 103476.20M,
                   Weight = 456,
                   ImageUrl = "/Content/img/Zirconium.jpg"
               },

               new Pipe
               {
                   Size = "133x6 mm ndl",
                   Standard = "GOST 9940-81",
                   ReleaseDate = DateTime.Parse("2016-5-12"),
                   Material = "st.10X23H18",
                   Price = 15888.20M,
                   Weight = 3232,
                   ImageUrl = "/Content/img/stainless.jpg"
               },

               new Pipe
               {
                   Size = "8v x 1p mm ndl",
                   Standard = "TU14-3-987-78",
                   ReleaseDate = DateTime.Parse("2003-9-06"),
                   Material = "Copper M1",
                   Price = 17476.20M,
                   Weight = 45,
                   ImageUrl = "/Content/img/copper.jpg"
               },

               new Pipe
               {
                   Size = "108x5 mm ndl",
                   Standard = "GOST 9940-81",
                   ReleaseDate = DateTime.Parse("2016-2-12"),
                   Material = "st.10X23H18",
                   Price = 16888.20M,
                   Weight = 2232,
                   ImageUrl = "/Content/img/stainless.jpg"
               },

               new Pipe
               {
                   Size = "108x8x3000-6000 mm",
                   Standard = "TU14-3-987-78",
                   ReleaseDate = DateTime.Parse("2003-9-06"),
                   Material = "Aluminum",
                   Price = 4667.20M,
                   Weight = 145,
                   ImageUrl = "/Content/img/aluminum.jpg"
               },

                new Pipe
                {
                    Size = "630x50x6000 mm",
                    Standard = "GOST 8732-78",
                    ReleaseDate = DateTime.Parse("2014-1-11"),
                    Material = "st.20",
                    Price = 1578.33M,
                    Weight = 9232,
                    ImageUrl = "/Content/img/big_steel2.jpg"
                }
           );

        }
    }
}
