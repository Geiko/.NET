using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPipe.Data.MsSql.Entities
{
    class MaterialEntity
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        //public virtual ICollection<PipeEntity> Pipes { get; set; }
        
        //public MaterialEntity()
        //{
        //    Pipes = new List<PipeEntity>();
        //}
    }
}
