﻿//-----------------------------------------------------------------------
// <copyright file="Pipe.cs" company="SoftServe">
//     Copyright (c) SoftServe. All rights reserved.
// </copyright>
// <author>Kostiantyn Geiko</author>
//-----------------------------------------------------------------------
namespace PipeStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// This class represents a pipe.
    /// </summary>
    public class Pipe
    {
        /// <summary>
        /// This field represents a unique key.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "Size")]
        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Size { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? StandardId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Standard Standard { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? MaterialId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Material Material { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? ManufacturerId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Manufacturer Manufacturer { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "Release")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "Price, $USD/tonn")]
        [Range(1000, 150000)]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "In stock, kg")]
        [Range(1, 20000)]
        public double InStock { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "Image URL")]
        [StringLength(1024)]
        public string ImageUrl { get; set; }


        /// <summary>
        /// Many to Many
        /// </summary>
        public virtual ICollection<Order> Orders { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Pipe()
        {
            Orders = new List<Order>();
        }
    }
}