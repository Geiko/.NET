//-----------------------------------------------------------------------
// <copyright file="PipeDBContext.cs" company="SoftServe">
//     Copyright (c) SoftServe. All rights reserved.
// </copyright>
// <author>Kostiantyn Geiko</author>
//-----------------------------------------------------------------------
namespace PipeStore.Models
{
    using System.Data.Entity;

    /// <summary>
    /// This class represents a context.
    /// </summary>
    public class PipeDBContext : DbContext
    {
        /// <summary>
        /// 
        /// </summary>
        public DbSet<Pipe> Pipes { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<PipeStandard> PipeStandards { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<Material> Materials { get; set; }
    }
}