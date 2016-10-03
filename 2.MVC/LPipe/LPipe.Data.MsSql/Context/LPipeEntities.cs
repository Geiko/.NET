using LPipe.Data.MsSql.Entities;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration.Conventions;
using LPipe.Domain.MaterialsAggregate;

namespace LPipe.Data.MsSql.Context
{
    internal class LPipeEntities : DbContext
    {
        /// <summary>
        /// Initializes static members of the <see cref="LPipeEntities"/> class.
        /// </summary>
        static LPipeEntities()
        {
            Database.SetInitializer(new LPipeDatabaseInitializer());
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LPipeEntities" /> class.
        /// </summary>
        public LPipeEntities()
            : base("LPipeEntities")
        {
        }



        public DbSet<MaterialEntity> Materials { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        { 
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            ConfigureMaterials(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }


        private static void ConfigureMaterials(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MaterialEntity>()
                .ToTable(LPipeDatabaseMetadata.MATERIALS_TABLE_NAME)
                .HasKey(t => t.Id);

            // Name
            modelBuilder.Entity<MaterialEntity>()
                .Property(t => t.Name)
                .IsRequired()
                .IsUnicode()
                .IsVariableLength()
                .HasMaxLength(ValidationConstants.Material.MAX_NAME_LENGTH);
        }
    }
}

