using PipeStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PipeStore.ViewModels
{
    public class PipeListViewModel
    {
        public Pipe Pipe { get; set; }
        public IEnumerable<Pipe> Pipes { get; set; }
        public SelectList PipeStandards { get; set; }
    }
}