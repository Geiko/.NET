namespace LPipe.Data.MsSql.Queries
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using LPipe.Data.Contracts;
    using LPipe.Data.MsSql.Entities;
    using LPipe.Data.Queries.Common;
    using LPipe.Data.Queries.Material;
    using LPipe.Domain.MaterialsAggregate;

    public class MaterialQueries : IQuery<Material, FindByIdCriteria>,
                               IQuery<List<Material>, GetAllCriteria>
    {
        private readonly LPipeUnitOfWork _unitOfWork;



        public MaterialQueries(IUnitOfWork unitOfWork)
        {
            _unitOfWork = (LPipeUnitOfWork)unitOfWork;
        }



        public Material Execute(FindByIdCriteria criteria)
        {
            return _unitOfWork.Context.Materials.Where(
                t => t.Id == criteria.Id).Select(GetMaterialMapping()).SingleOrDefault();
        }

        public List<Material> Execute(GetAllCriteria criteria)
        {
            return _unitOfWork.Context.Materials.Select(GetMaterialMapping()).ToList();
        }



        private static Expression<Func<MaterialEntity, Material>> GetMaterialMapping()
        {
            return m => new Material
            {
                Id = m.Id,
                Name = m.Name
            };
        }
    }
}
