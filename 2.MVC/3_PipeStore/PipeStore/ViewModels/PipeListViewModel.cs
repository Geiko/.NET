using PipeStore.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace PipeStore.ViewModels
{
    public class PipeListViewModel
    {
        public Pipe Pipe { get; set; }
        public IEnumerable<Pipe> Pipes { get; set; }
        public SelectList PipeStandards { get; set; }
        public SelectList Materials { get; set; }
    }
}