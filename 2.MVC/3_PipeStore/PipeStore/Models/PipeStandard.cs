//-----------------------------------------------------------------------
// <copyright file="PipeStandard.cs" company="SoftServe">
//     Copyright (c) SoftServe. All rights reserved.
// </copyright>
// <author>Kostiantyn Geiko</author>
//-----------------------------------------------------------------------
namespace PipeStore.Models
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// This class represents a pipe standard.
    /// </summary>
    public class PipeStandard
    {
        /// <summary>
        /// This field represents a unique key.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage = "Standard is required")]
        [StringLength(60, MinimumLength = 2, ErrorMessage = "Standard's name shold be in range 2-60 symbols")]
        [DisplayName("Standard")]
        public string Title { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<Pipe> Pipes { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public PipeStandard()
        {
            Pipes = new List<Pipe>();
        }
    }
}