using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace PipeStore.Models
{
    public class Pipe
    {
        public int ID { get; set; }

        [Display(Name = "Size")]
        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Size { get; set; }

        [Display(Name = "Standard")]
        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Standard { get; set; }

        [Display(Name = "Manufacturer")]
        [Required]
        [StringLength(60, MinimumLength = 2)]
        public string Manufacturer { get; set; }

        [Display(Name = "Release")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }
        
        [Required]
        [StringLength(60, MinimumLength = 1)]
        public string Material { get; set; }
        
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