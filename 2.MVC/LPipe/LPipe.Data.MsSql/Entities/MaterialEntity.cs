using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPipe.Data.MsSql.Entities
{
    public class MaterialEntity
    {
        public int Id { get; set; }


        private string name;

        [StringLength(50, MinimumLength = 1)]
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Material Name is not valid.");
                }

                name = value;
            }
        }
    }
}
