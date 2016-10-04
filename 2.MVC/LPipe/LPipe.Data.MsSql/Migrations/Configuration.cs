namespace LPipe.Data.MsSql.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using LPipe.Data.MsSql.Entities;

    internal sealed class Configuration : DbMigrationsConfiguration<LPipe.Data.MsSql.Context.LPipeEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }


        protected override void Seed(LPipe.Data.MsSql.Context.LPipeEntities context)
        {
            context.Materials.AddOrUpdate(m => m.Name,
                new MaterialEntity { Name = "12X18H10T" },
                new MaterialEntity { Name = "Copper M1" },
                new MaterialEntity { Name = "Zirconium" });
            context.SaveChanges();
        }
    }
}
