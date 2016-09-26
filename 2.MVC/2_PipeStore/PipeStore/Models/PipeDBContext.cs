using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PipeStore.Models
{
    public class PipeDBContext : DbContext
    {
        public DbSet<Pipe> Pipes { get; set; }
        public DbSet<Standard> Standards { get; set; }
    }
}