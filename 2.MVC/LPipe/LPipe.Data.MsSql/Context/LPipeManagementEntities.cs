using LPipe.Data.MsSql.Entities;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPipe.Data.MsSql.Context
{
    class LPipeEntities : DbContext
    {
        #region Constructor
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
        #endregion


        /// <summary>
        /// Gets or sets the materials.
        /// </summary>
        public DbSet<MaterialEntity> Materials { get; set; }



        // Mapping Configuration  ???????????????

    }
}
