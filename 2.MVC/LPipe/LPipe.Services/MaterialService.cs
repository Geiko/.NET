namespace LPipe.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using LPipe.Contracts;
    using LPipe.Domain.MaterialsAggregate;
    using LPipe.Data.Queries.Common;
    using LPipe.Data.Contracts;
    using LPipe.Data.Queries.Material;
    using LPipe.Data.Exceptions;
    using LPipe.Contracts.Exceptions;

    public class MaterialService : IMaterialService
    {
        private readonly IMaterialRepository _materialRepository;     
        private readonly IQuery<List<Material>, GetAllCriteria> _getAllMaterialsQuery;
        private readonly IQuery<Material, FindByIdCriteria> _getMaterialByIdQuery;


        public MaterialService(
            IMaterialRepository materialRepository,
            IQuery<List<Material>, GetAllCriteria> getAllMaterialsQuery ,          
            IQuery<Material, FindByIdCriteria> getMaterialByIdQuery
            )
        {
            _materialRepository = materialRepository;
            _getAllMaterialsQuery = getAllMaterialsQuery;
            _getMaterialByIdQuery = getMaterialByIdQuery;
        }



        public IList<Material> Get()
        {
            return _getAllMaterialsQuery.Execute(new GetAllCriteria());     
        }



        public void Create(Material materialToCreate)
        {
                _materialRepository.Add(materialToCreate);
        }

        public void Edit(Material team)
        {
            try
            {
                _materialRepository.Update(team);
            }
            catch (ConcurrencyException ex)
            {
                throw new MissingEntityException(string.Format("Material NotFound {0}", ex.Message));
            }
        }


        public Material Get(int id)
        {
            return _getMaterialByIdQuery.Execute(new FindByIdCriteria { Id = id });
        }


        public void Delete(int materialId)
        {
            try
            {
                _materialRepository.Remove(materialId);
            }
            catch (InvalidKeyValueException ex)
            {
                throw new MissingEntityException( String.Format("MaterialNotFound {0} {1}", materialId, ex.Message));
            }
            
            _materialRepository.UnitOfWork.Commit();
        }

    }
}
