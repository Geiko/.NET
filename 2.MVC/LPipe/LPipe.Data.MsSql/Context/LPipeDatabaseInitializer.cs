//namespace LPipe.Data.MsSql.Context
//{
//    using System.Data.Entity;
//    using LPipe.Data.MsSql.Context.Migrations;
//    using LPipe.Domain.MaterialsAggregate;
//    using LPipe.Data.MsSql.Entities;

//    //internal class LPipeDatabaseInitializer
//    //    : MigrateDatabaseToLatestVersion<LPipeEntities, LPipeContextConfiguration>
//    internal class LPipeDatabaseInitializer
//        : DropCreateDatabaseAlways<LPipeEntities>
//    {
//        protected override void Seed(LPipeEntities context)
//        {
//            context.Materials.Add(new MaterialEntity { Name = "Copper" });
//            context.Materials.Add(new MaterialEntity { Name = "Aliuminum" });
//            context.Materials.Add(new MaterialEntity { Name = "Steel 20" });
//            context.Materials.Add(new MaterialEntity { Name = "Steel 45" });
//        }
//    }
//}