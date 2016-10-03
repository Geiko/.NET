using LPipe.Domain.MaterialsAggregate;
using LPipe.UI.Areas.Mvc.ViewModels.Materials;
namespace LPipe.UI.Areas.Mvc.Mappers
{
    public static class ViewModelToDomain
    {
        public static Material Map(MaterialViewModel materialViewModel)
        {
            return new Material
            {
                Id = materialViewModel.Id,
                Name = materialViewModel.Name,
            };
        }
    }
}