using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LPipe.Domain.MaterialsAggregate;
namespace LPipe.Data.MsSql.Repositories
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using LPipe.Data.Contracts;
    //using LPipe.Data.Exceptions;
    using LPipe.Data.MsSql.Entities;
    using LPipe.Data.MsSql.Mappers;
    //using LPipe.Data.MsSql.Repositories.Specifications;
    using LPipe.Domain.MaterialsAggregate;
    using LPipeManagement.Data.MsSql;

    /// <summary>
    /// Defines implementation of the ITeamRepository contract.
    /// </summary>
    internal class MaterialRepository : IMaterialRepositiry
    {
        private static readonly MaterialStorageSpecification _dbStorageSpecification
            = new MaterialStorageSpecification();

        private readonly DbSet<MaterialEntity> _dalTeams;

        private readonly LPipeUnitOfWork _unitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="TeamRepository"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        public MaterialRepository(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = (LPipeUnitOfWork)unitOfWork;
            this._dalTeams = _unitOfWork.Context.Materials;
        }

        /// <summary>
        /// Gets unit of work.
        /// </summary>
        public IUnitOfWork UnitOfWork
        {
            get { return this._unitOfWork; }
        }

        /// <summary>
        /// Adds new team.
        /// </summary>
        /// <param name="newEntity">The team for adding.</param>
        public void Add(Material newEntity)
        {
            var newTeam = new MaterialEntity();
            DomainToDal.Map(newTeam, newEntity);

            if (!_dbStorageSpecification.IsSatisfiedBy(newTeam))
            {
                throw new InvalidEntityException();
            }

            this._dalTeams.Add(newTeam);
            this._unitOfWork.Commit();

            newEntity.Id = newTeam.Id;
        }

        /// <summary>
        /// Updates specified team.
        /// </summary>
        /// <param name="updatedEntity">Updated team.</param>
        public void Update(Material updatedEntity)
        {
            var teamToUpdate = _dalTeams.SingleOrDefault(t => t.Id == updatedEntity.Id);

            if (teamToUpdate == null)
            {
                throw new ConcurrencyException();
            }

            DomainToDal.Map(teamToUpdate, updatedEntity);
        }

        /// <summary>
        /// Removes team by id.
        /// </summary>
        /// <param name="id">The id of team to remove.</param>
        public void Remove(int id)
        {
            var dalToRemove = new MaterialEntity { Id = id };
            this._dalTeams.Attach(dalToRemove);
            this._dalTeams.Remove(dalToRemove);
        }
    }
}
