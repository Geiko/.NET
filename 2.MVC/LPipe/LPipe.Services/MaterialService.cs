using LPipe.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LPipe.Domain.MaterialsAggregate;
using LPipe.Data.Queries.Common;


using LPipe.Data.Contracts;
using LPipe.Data.Queries.Material;

namespace LPipe.Services
{
    public class MaterialService : IMaterialService
    {
        private readonly IQuery<List<Material>, GetAllCriteria> _getAllMaterialsQuery;
        private readonly IQuery<Material, FindByIdCriteria> _getMaterialByIdQuery;        

        //private readonly IMaterialRepository _materialRepository;
        //private readonly IQuery<Material, UniqueMaterialCriteria> _uniqueMaterialQuery;

        public MaterialService(
            //IMaterialRepository materialRepository,
            //IQuery<List<Material>, GetAllCriteria> getAllMaterialsQuery           
            //IQuery<Material, FindByIdCriteria> getMaterialByIdQuery
            )
        {
            IQuery<List<Material>, GetAllCriteria> getAllMaterialsQuery =
                new MaterialQueries(unitOfWork);

            _getAllMaterialsQuery = getAllMaterialsQuery;
            _getMaterialByIdQuery = getMaterialByIdQuery;
        }



        public IList<Material> Get()
        {
            return _getAllMaterialsQuery.Execute(new GetAllCriteria());     ////////
        }



        public void Create(Material teamToCreate)
        {
            throw new NotImplementedException();
        }

        public void Edit(Material team)
        {
            throw new NotImplementedException();
        }


        public Material Get(int id)
        {
            return _getMaterialByIdQuery.Execute(new FindByIdCriteria { Id = id });
        }


        public void Delete(int teamId)
        {
            throw new NotImplementedException();
        }

    }
}
