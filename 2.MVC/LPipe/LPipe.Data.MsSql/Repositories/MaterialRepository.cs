namespace LPipe.Data.MsSql.Repositories
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using LPipe.Data.Contracts;
    using LPipe.Data.Exceptions;
    using LPipe.Data.MsSql.Entities;
    using LPipe.Data.MsSql.Mappers;
    using LPipe.Data.MsSql.Repositories.Specifications;
    using LPipe.Domain.MaterialsAggregate;

    public class MaterialRepository : IMaterialRepository
    {
        private static readonly MaterialStorageSpecification _dbStorageSpecification
            = new MaterialStorageSpecification();

        private readonly DbSet<MaterialEntity> _dalMaterials;

        private readonly LPipeUnitOfWork _unitOfWork;



        public MaterialRepository(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = (LPipeUnitOfWork)unitOfWork;
            this._dalMaterials = _unitOfWork.Context.Materials;
        }




        public IUnitOfWork UnitOfWork
        {
            get { return this._unitOfWork; }
        }



        public void Add(Material newEntity)
        {
            var newMaterial = new MaterialEntity();
            DomainToDal.Map(newMaterial, newEntity);

            if (!_dbStorageSpecification.IsSatisfiedBy(newMaterial))
            {
                throw new InvalidEntityException();
            }

            this._dalMaterials.Add(newMaterial);
            this._unitOfWork.Commit();

            newEntity.Id = newMaterial.Id;
        }



        public void Update(Material updatedEntity)
        {
            var materialToUpdate = _dalMaterials.SingleOrDefault(t => t.Id == updatedEntity.Id);

            if (materialToUpdate == null)
            {
                throw new ConcurrencyException();
            }

            DomainToDal.Map(materialToUpdate, updatedEntity);
        }



        public void Remove(int id)
        {
            var dalToRemove = new MaterialEntity { Id = id };
            this._dalMaterials.Attach(dalToRemove);
            this._dalMaterials.Remove(dalToRemove);
        }
    }
}
