using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using LPipe.Data.MsSql.Entities;

namespace LPipe.Data.MsSql.Context.Migrations
{
    class LPipeContextConfiguration
    {
        internal sealed class VolleyContextConfiguration : DbMigrationsConfiguration<LPipeEntities>
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="VolleyContextConfiguration"/> class.
            /// </summary>
            public VolleyContextConfiguration()
            {
                AutomaticMigrationsEnabled = false;
                MigrationsDirectory = @"Context\Migrations";
                ContextKey = "VolleyManagement.Data.MsSql.Context.VolleyManagementEntities";
            }

            /// <summary>
            /// This method will be called after migrating to the latest version.
            /// </summary>
            /// <param name="context"> Volley Management context</param>
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
}
