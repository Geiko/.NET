using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PipeStore.Models
{
    public class Manufacturer
    {
        /// <summary>
        /// This field represents a unique key.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage = "Manufacturer is required")]
        [StringLength(60, MinimumLength = 1, ErrorMessage = "Manufacturer's name shold be in range 1-60 symbols")]
        [DisplayName("Manufacturer")]
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<Pipe> Pipes { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Manufacturer()
        {
            Pipes = new List<Pipe>();
        }
    }
}