using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PipeStore.Models
{
    public class PipeListViewModel
    {
        public IEnumerable<Pipe> Pipes { get; set; }
        public SelectList Standards { get; set; }
    }
}