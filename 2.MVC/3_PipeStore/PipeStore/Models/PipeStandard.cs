using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PipeStore.Models
{
    public class PipeStandard
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Standard is required")]
        [StringLength(60, MinimumLength = 2, ErrorMessage = "Standard's name shold be in range 2-60 symbols")]
        [DisplayName("Standard")]
        public string Title { get; set; }

        public virtual ICollection<Pipe> Pipes { get; set; }
        public PipeStandard()
        {
            Pipes = new List<Pipe>();
        }
    }
}