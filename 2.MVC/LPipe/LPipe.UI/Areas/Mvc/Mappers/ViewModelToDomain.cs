
namespace LPipe.UI.Areas.Mvc.Mappers
{
    using LPipe.Domain.MaterialsAggregate.Material;
    using LPipe.Domain.MaterialsAggregate;
    using LPipe.UI.Areas.Mvc.ViewModels.Materials;
    using System.Collections.Generic;

    /// <summary>
    /// Maps Domain models to view models
    /// </summary>
    public static class DomainToViewModel
    {
        /// <summary>
        /// Maps Tournament.
        /// </summary>
        /// <param name="tournament">Tournament Domain model</param>
        /// <returns>Tournament view model</returns>
        public static MaterialViewModel Map(Material material)
        {
            return new MaterialViewModel
            {
                Id = material.Id,
                Name = material.Name,
                //Pipes { get; set; }   
            };
        }
    }
}
 
           