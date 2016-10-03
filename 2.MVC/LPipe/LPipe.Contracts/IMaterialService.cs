using LPipe.Domain;
using LPipe.Domain.MaterialsAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPipe.Contracts
{
    public interface IMaterialService
    {
        IList<Material> Get();
        Material Get(int id);
        void Create(Material material);
        void Edit(Material material);
        void Delete(int id);
    }
}
