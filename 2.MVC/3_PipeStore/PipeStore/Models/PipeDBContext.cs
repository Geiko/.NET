using System.Data.Entity;

namespace PipeStore.Models
{
    public class PipeDBContext : DbContext
    {
        public DbSet<Pipe> Pipes { get; set; }
        public DbSet<PipeStandard> PipeStandards { get; set; }
        public DbSet<Material> Materials { get; set; }
    }
}