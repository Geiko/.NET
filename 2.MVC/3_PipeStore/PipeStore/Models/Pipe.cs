﻿using System;
using System.ComponentModel.DataAnnotations;

namespace PipeStore.Models
{
    public class Pipe
    {
        public int Id { get; set; }

        [Display(Name = "Size")]
        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Size { get; set; }

        public int? PipeStandardId { get; set; }
        public virtual PipeStandard PipeStandard { get; set; }

        public int? MaterialId { get; set; }
        public virtual Material Material { get; set; }

        [Display(Name = "Manufacturer")]
        [Required]
        [StringLength(60, MinimumLength = 2)]
        public string Manufacturer { get; set; }

        [Display(Name = "Release")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Price, $USD/tonn")]
        [Range(1000, 150000)]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Display(Name = "In stock, kg")]
        [Range(1, 20000)]
        public double InStock { get; set; }

        [Display(Name = "Image URL")]
        [StringLength(1024)]
        public string ImageUrl { get; set; }
    }
}