using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PipeStore.Models
{
    public class Material
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Material is required")]
        [StringLength(60, MinimumLength = 1, ErrorMessage = "Material's name shold be in range 1-60 symbols")]
        [DisplayName("Material")]
        public string Name { get; set; }

        public virtual ICollection<Pipe> Pipes { get; set; }
        public Material()
        {
            Pipes = new List<Pipe>();
        }
    }
}