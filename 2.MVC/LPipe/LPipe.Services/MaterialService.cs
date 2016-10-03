using LPipe.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LPipe.Domain.MaterialsAggregate;
using LPipe.Data.Queries.Common;


using LPipe.Data.Contracts;
using LPipe.Data.Queries.Common;
using LPipe.Domain.MaterialsAggregate;
using LPipe.Data.Queries.Material;

namespace LPipe.Services
{
    public class MaterialService : IMaterialService
    {
        private readonly IMaterialRepository _materialRepository;

        private readonly IQuery<Material, UniqueMaterialCriteria> _uniqueMaterialQuery;
        private readonly IQuery<List<Material>, GetAllCriteria> _getAllMaterialsQuery;


        public MaterialService(
            IMaterialRepository materialRepository,
            IQuery<List<Material>, GetAllCriteria> getAllMaterialsQuery)
        {
        }



        public IList<Material> Get()
        {
            return _getAllMaterialsQuery.Execute(new GetAllCriteria());
        }



        public void Create(Material teamToCreate)
        {
            //_authService.CheckAccess(AuthOperations.Teams.Create);

            //Player captain = GetPlayerById(teamToCreate.CaptainId);
            //if (captain == null)
            //{
            //    // ToDo: Revisit this case
            //    throw new MissingEntityException(ServiceResources.ExceptionMessages.PlayerNotFound, teamToCreate.CaptainId);
            //}

            //// Check if captain in teamToCreate is captain of another team
            //if (captain.TeamId != null)
            //{
            //    var existTeam = GetPlayerLedTeam(captain.Id);
            //    VerifyExistingTeamOrThrow(existTeam);
            //}

            //ValidateTeam(teamToCreate);

            //_teamRepository.Add(teamToCreate);

            //captain.TeamId = teamToCreate.Id;
            //_playerRepository.Update(captain);
            //_playerRepository.UnitOfWork.Commit();
            throw new NotImplementedException();
        }

        public void Edit(Material team)
        {
            //_authService.CheckAccess(AuthOperations.Teams.Edit);
            //Player captain = GetPlayerById(team.CaptainId);

            //if (captain == null)
            //{
            //    // ToDo: Revisit this case
            //    throw new MissingEntityException(ServiceResources.ExceptionMessages.PlayerNotFound, team.CaptainId);
            //}

            //// Check if captain in teamToCreate is captain of another team
            //if ((captain.TeamId != null) && (captain.TeamId != team.Id))
            //{
            //    var existTeam = GetPlayerLedTeam(captain.Id);
            //    VerifyExistingTeamOrThrow(existTeam);
            //}

            //ValidateTeam(team);

            //try
            //{
            //    _teamRepository.Update(team);
            //}
            //catch (ConcurrencyException ex)
            //{
            //    throw new MissingEntityException(ServiceResources.ExceptionMessages.TeamNotFound, ex);
            //}

            //captain.TeamId = team.Id;
            //_playerRepository.Update(captain);
            //_playerRepository.UnitOfWork.Commit();
            throw new NotImplementedException();
        }


        public Material Get(int id)
        {
            //return _getTeamByIdQuery.Execute(new FindByIdCriteria { Id = id });
            throw new NotImplementedException();
        }


        public void Delete(int teamId)
        {
            //_authService.CheckAccess(AuthOperations.Teams.Delete);
            //try
            //{
            //    _teamRepository.Remove(teamId);
            //}
            //catch (InvalidKeyValueException ex)
            //{
            //    throw new MissingEntityException(ServiceResources.ExceptionMessages.TeamNotFound, teamId, ex);
            //}

            //IEnumerable<Player> roster = GetTeamRoster(teamId);

            //foreach (var player in roster)
            //{
            //    player.TeamId = null;
            //    _playerRepository.Update(player);
            //}

            //_teamRepository.UnitOfWork.Commit();
            throw new NotImplementedException();
        }

    }
}
