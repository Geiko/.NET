//namespace PipeStore.Migrations
//{
//    using Controllers;
//    using Models;
//    using System;
//    using System.Collections.Generic;
//    using System.Data.Entity;
//    using System.Data.Entity.Migrations;
//    using System.Linq;

//    internal sealed class Configuration : DbMigrationsConfiguration<PipeStore.Models.PipeDBContext>
//    {
//        public Configuration()
//        {
//            AutomaticMigrationsEnabled = true;
//            AutomaticMigrationDataLossAllowed = true;
//        }

//        protected override void Seed(PipeStore.Models.PipeDBContext context)
//        {
//            Material m1 = new Material { Name = "st.20" };
//            Material m2 = new Material { Name = "st.45" };
//            Material m3 = new Material { Name = "st.12X18H10T" };
//            Material m4 = new Material { Name = "st.10X23H18" };
//            Material m5 = new Material { Name = "st.10X17H13M2T" };
//            Material m6 = new Material { Name = "Copper M1" };
//            Material m7 = new Material { Name = "Aluminum 3000" };
//            Material m8 = new Material { Name = "BT-1-0" };
//            Material m9 = new Material { Name = "Zirconium" };
//            Material m10 = new Material { Name = "PVC" };
//            var materials = new List<Material>{
//                m1,m2,m3,m4,m5,m6,m7,m8,m9,m10};
//            context.Materials.AddOrUpdate(
//                m => m.Name, m1, m2, m3, m4, m5, m6, m7, m8, m9, m10);
//            context.SaveChanges();

//            Standard s1 = new Standard { Title = "Gost 3262-78" };
//            Standard s2 = new Standard { Title = "Gost 8732-78" };
//            Standard s3 = new Standard { Title = "Gost 9940-78" };
//            Standard s4 = new Standard { Title = "ANSI 56894" };
//            Standard s5 = new Standard { Title = "ANSI 65432" };
//            Standard s6 = new Standard { Title = "DSTU 9940-2000" };
//            Standard s7 = new Standard { Title = "TU 14-3-456-87" };
//            var standards = new List<Standard> {
//                s1, s2, s3, s4, s5, s6, s7 };
//            context.Standards.AddOrUpdate(
//                s => s.Title, s1, s2, s3, s4, s5, s6, s7);
//            context.SaveChanges();

//            Manufacturer mn1 = new Manufacturer { Name = "Ukraine" };
//            Manufacturer mn2 = new Manufacturer { Name = "Russia" };
//            Manufacturer mn3 = new Manufacturer { Name = "Germany" };
//            Manufacturer mn4 = new Manufacturer { Name = "China" };
//            var manufacturers = new List<Manufacturer> { mn1, mn2, mn3, mn4 };
//            context.Manufacturers.AddOrUpdate(
//                mn => mn.Name, mn1, mn2, mn3, mn4);
//            context.SaveChanges();

//            Pipe p1 = new Pipe
//            {
//                Size = "325x15xndl mm",
//                MaterialId = materials.Single(m => m.Name == "st.20").Id,
//                StandardId = standards.Single(s => s.Title == "Gost 3262-78").Id,
//                ManufacturerId = manufacturers.Single(mn => mn.Name == "Ukraine").Id,
//                ReleaseDate = DateTime.Parse("2015-1-11"),
//                Price = 1898.60M,
//                InStock = 8330,
//                ImageUrl = "/Content/img/big_steel.jpg"
//            };

//            Pipe p2 = new Pipe
//            {
//                Size = "159x6x9000 mm",
//                MaterialId = materials.Single(m => m.Name == "st.20").Id,
//                StandardId = standards.Single(s => s.Title == "Gost 3262-78").Id,
//                ManufacturerId = manufacturers.Single(mn => mn.Name == "China").Id,
//                ReleaseDate = DateTime.Parse("2016-5-12"),
//                Price = 6744.20M,
//                InStock = 5232,
//                ImageUrl = "/Content/img/stainless.jpg"
//            };

//            Pipe p3 = new Pipe
//            {
//                Size = "32x6xndl mm",
//                MaterialId = materials.Single(m => m.Name == "Copper M1").Id,
//                StandardId = standards.Single(s => s.Title == "TU 14-3-456-87").Id,
//                ManufacturerId = manufacturers.Single(mn => mn.Name == "Ukraine").Id,
//                ReleaseDate = DateTime.Parse("2012-9-06"),
//                Price = 12476.20M,
//                InStock = 158,
//                ImageUrl = "/Content/img/copper.jpg"
//            };

//            Pipe p4 = new Pipe
//            {
//                Size = "3/4\"x3,2x6000 mm",
//                MaterialId = materials.Single(m => m.Name == "PVC").Id,
//                StandardId = standards.Single(s => s.Title == "Gost 3262-78").Id,
//                ManufacturerId = manufacturers.Single(mn => mn.Name == "China").Id,
//                ReleaseDate = DateTime.Parse("2016-7-06"),
//                Price = 3476.20M,
//                InStock = 786,
//                ImageUrl = "/Content/img/pvc.jpg"
//            };

//            Pipe p5 = new Pipe
//            {
//                Size = "219x10x2000x5000 mm",
//                MaterialId = materials.Single(m => m.Name == "st.12X18H10T").Id,
//                StandardId = standards.Single(s => s.Title == "Gost 9940-78").Id,
//                ManufacturerId = manufacturers.Single(mn => mn.Name == "China").Id,
//                ReleaseDate = DateTime.Parse("2015-5-12"),
//                Price = 1999.20M,
//                InStock = 7232,
//                ImageUrl = "/Content/img/boile.jpg"
//            };

//            Pipe p6 = new Pipe
//            {
//                Size = "25p x 2p x 6000 mm",
//                MaterialId = materials.Single(m => m.Name == "BT-1-0").Id,
//                StandardId = standards.Single(s => s.Title == "TU 14-3-456-87").Id,
//                ManufacturerId = manufacturers.Single(mn => mn.Name == "Ukraine").Id,
//                ReleaseDate = DateTime.Parse("2016-9-06"),
//                Price = 50476.20M,
//                InStock = 38,
//                ImageUrl = "Content/img/titan.jpg"
//            };

//            Pipe p7 = new Pipe
//            {
//                Size = "14v x 2v x 4000 mm",
//                MaterialId = materials.Single(m => m.Name == "Zirconium").Id,
//                StandardId = standards.Single(s => s.Title == "TU 14-3-456-87").Id,
//                ManufacturerId = manufacturers.Single(mn => mn.Name == "Ukraine").Id,
//                ReleaseDate = DateTime.Parse("2016-9-06"),
//                Price = 103476.20M,
//                InStock = 456,
//                ImageUrl = "/Content/img/Zirconium.jpg"
//            };

//            Pipe p8 = new Pipe
//            {
//                Size = "133x6xndl mm",
//                MaterialId = materials.Single(m => m.Name == "st.12X18H10T").Id,
//                StandardId = standards.Single(s => s.Title == "Gost 9940-78").Id,
//                ManufacturerId = manufacturers.Single(mn => mn.Name == "Ukraine").Id,
//                ReleaseDate = DateTime.Parse("2016-5-12"),
//                Price = 15888.20M,
//                InStock = 3232,
//                ImageUrl = "/Content/img/stainless.jpg"
//            };

//            Pipe p9 = new Pipe
//            {
//                Size = "8v x 1p x ndl mm",
//                MaterialId = materials.Single(m => m.Name == "Copper M1").Id,
//                StandardId = standards.Single(s => s.Title == "ANSI 56894").Id,
//                ManufacturerId = manufacturers.Single(mn => mn.Name == "Germany").Id,
//                ReleaseDate = DateTime.Parse("2003-9-06"),
//                Price = 17476.20M,
//                InStock = 45,
//                ImageUrl = "/Content/img/copper.jpg"
//            };

//            Pipe p10 = new Pipe
//            {
//                Size = "108x5xndl mm",
//                MaterialId = materials.Single(m => m.Name == "Aluminum 3000").Id,
//                StandardId = standards.Single(s => s.Title == "TU 14-3-456-87").Id,
//                ManufacturerId = manufacturers.Single(mn => mn.Name == "Ukraine").Id,
//                ReleaseDate = DateTime.Parse("2016-2-12"),
//                Price = 16888.20M,
//                InStock = 2232,
//                ImageUrl = "/Content/img/stainless.jpg"
//            };

//            Pipe p11 = new Pipe
//            {
//                Size = "108x8x3000-6000 mm",
//                MaterialId = materials.Single(m => m.Name == "st.10X23H18").Id,
//                StandardId = standards.Single(s => s.Title == "ANSI 56894").Id,
//                ManufacturerId = manufacturers.Single(mn => mn.Name == "Germany").Id,
//                ReleaseDate = DateTime.Parse("2003-9-06"),
//                Price = 4667.20M,
//                InStock = 145,
//                ImageUrl = "/Content/img/aluminum.jpg"
//            };

//            Pipe p12 = new Pipe
//            {
//                Size = "630x50x6000 mm",
//                MaterialId = materials.Single(m => m.Name == "st.45").Id,
//                StandardId = standards.Single(s => s.Title == "Gost 9940-78").Id,
//                ManufacturerId = manufacturers.Single(mn => mn.Name == "Russia").Id,
//                ReleaseDate = DateTime.Parse("2014-1-11"),
//                Price = 1578.33M,
//                InStock = 9232,
//                ImageUrl = "/Content/img/big_steel2.jpg"
//            };

//            context.Pipes.AddOrUpdate(
//                i => i.Size, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12);
//            context.SaveChanges();

//            Customer c1 = new Customer { Contacts = "DniproAzot" };
//            Customer c2 = new Customer { Contacts = "EnergodarAES" };
//            Customer c3 = new Customer { Contacts = "PavlogradHimMash" };
//            var customers = new List<Customer> { c1, c2, c3 };
//            context.Customers.AddOrUpdate(i => i.Contacts, c1, c2, c3);
//            context.SaveChanges();

//            Order o1 = new Order
//            {
//                Title = "DnAz 1742-16",
//                CustomerId = customers.Single(c => c.Contacts == "DniproAzot").Id,
//                Pipes = { p1 }
//            };

//            Order o2 = new Order
//            {
//                Title = "EnDar 0263-16",
//                CustomerId = customers.Single(c => c.Contacts == "EnergodarAES").Id,
//                Pipes = { p4, p5, p6 }
//            };

//            Order o3 = new Order
//            {
//                Title = "EnDar 0264-16",
//                CustomerId = customers.Single(c => c.Contacts == "EnergodarAES").Id,
//                Pipes = { p1, p7 }
//            };

//            Order o4 = new Order
//            {
//                Title = "PavHim 0946-16",
//                CustomerId = customers.Single(c => c.Contacts == "PavlogradHimMash").Id,
//                Pipes = { p7, p8, p9, p3 }
//            };

//            context.Orders.AddOrUpdate(i => i.Title, o1, o2, o3, o4);
//            context.SaveChanges();
//        }
//    }
//}
