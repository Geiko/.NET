namespace LPipe.Data.MsSql.Context
{
    using Migrations;
    using System.Data.Entity;
    using LPipe.Data.MsSql.Context.Migrations;

    internal class LPipeDatabaseInitializer
        : MigrateDatabaseToLatestVersion<LPipeEntities, LPipeContextConfiguration>
    {
    }
}

//namespace VolleyManagement.Data.MsSql.Context
//{
//    using System.Data.Entity;
//    using VolleyManagement.Data.MsSql.Context.Migrations;
    
//    internal class VolleyManagementDatabaseInitializer
//        : MigrateDatabaseToLatestVersion<VolleyManagementEntities, VolleyContextConfiguration>
//    {
//    }
//}