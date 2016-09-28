//-----------------------------------------------------------------------
// <copyright file="Material.cs" company="SoftServe">
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
    /// This class represents a pipe material.
    /// </summary>
    public class Material
    {
        /// <summary>
        /// This field represents a unique key.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage = "Material is required")]
        [StringLength(60, MinimumLength = 1, ErrorMessage = "Material's name shold be in range 1-60 symbols")]
        [DisplayName("Material")]
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<Pipe> Pipes { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Material()
        {
            Pipes = new List<Pipe>();
        }
    }
}