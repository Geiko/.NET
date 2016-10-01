namespace LPipe.Data.MsSql.Mappers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using LPipe.Data.MsSql.Entities;
    using LPipe.Domain.MaterialsAggregate;

    internal static class DomainToDal
    {
        public static void Map(MaterialEntity to, Material from)
        {
            to.Id = from.Id;
            to.Name = from.Name;
        }
    }
}
