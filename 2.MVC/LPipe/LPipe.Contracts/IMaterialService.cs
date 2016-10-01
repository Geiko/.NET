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
        IEnumerable<Material> GetMaterialList();
        Material GetMaterial(int id);
        void Create(Material item);
        void Update(Material item);
        void Delete(int id);
        void Save();
    }
}
