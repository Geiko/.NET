using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using LPipe.Data.MsSql.Entities;

namespace LPipe.Data.MsSql.Context.Migrations
{
    internal sealed class LPipeContextConfiguration : DbMigrationsConfiguration<LPipeEntities>
    {
        public LPipeContextConfiguration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Context\Migrations";
            ContextKey = "LPipeManagement.Data.MsSql.Context.LPipeManagementEntities";
        }

        protected override void Seed(LPipeEntities context)
        {
            context.Materials.AddOrUpdate(m => m.Name,
                new MaterialEntity { Name = "12X18H10T" },
                new MaterialEntity { Name = "Copper M1" },
                new MaterialEntity { Name = "Zirconium" });
            context.SaveChanges();
        }
    }

}
