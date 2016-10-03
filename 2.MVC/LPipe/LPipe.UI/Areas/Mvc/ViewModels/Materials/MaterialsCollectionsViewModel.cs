using LPipe.Domain.MaterialsAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LPipe.UI.Areas.Mvc.ViewModels.Materials
{
    public class MaterialsCollectionsViewModel
    {
        public IEnumerable<Material> Materials { get; set; }

        //public IEnumerable<Tournament> UpcomingTournaments { get; set; }

        //public AllowedOperations Authorization { get; set; }
    }
}