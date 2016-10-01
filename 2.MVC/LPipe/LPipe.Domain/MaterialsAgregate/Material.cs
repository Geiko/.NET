using LPipe.Domain.PipesAgregate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPipe.Domain.MaterialAgregate.MaterialsAgregate
{
    public class Material
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public virtual ICollection<Pipe> Pipes { get; set; }
        
        public Material()
        {
            Pipes = new List<Pipe>();
        }
    }
}
