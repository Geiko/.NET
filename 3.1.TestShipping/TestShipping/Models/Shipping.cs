using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestShipping.Models
{
    public class Shipping
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Required")]
        [Range(1, 12)]
        [DisplayName("Month")]
        public int Month { get; set; }

        [Required(ErrorMessage = "Required")]
        [Range(2000, 2100)]
        [DisplayName("Year")]
        public int Year { get; set; }



        [Required(ErrorMessage = "Required")]
        [StringLength(30)]
        [DisplayName("Departure city")]
        public string Departure { get; set; }

        [Required(ErrorMessage = "Required")]
        [StringLength(30)]
        [DisplayName("Purpose city")]
        public string Purpose { get; set; }



        [Required(ErrorMessage = "Required")]
        [StringLength(50)]
        [DisplayName("Customer")]
        public string Customer { get; set; }

        [Required(ErrorMessage = "Required")]
        [StringLength(50)]
        [DisplayName("Carrier")]
        public string Carrier { get; set; }
        


        [Range(0, 3000)]
        [DisplayName("Scheduled Traffic")]
        public double ScheduledTraffic { get; set; }

        [Range(0, 3000)]
        [DisplayName("Actual Traffic")]
        public double ActualTraffic { get; set; }


        
        public double? Day1Tons { get; set; }
        public double? Day2Tons { get; set; }
        public double? Day3Tons { get; set; }
        public double? Day4Tons { get; set; }
        public double? Day5Tons { get; set; }
        public double? Day6Tons { get; set; }
        public double? Day7Tons { get; set; }
        public double? Day8Tons { get; set; }
        public double? Day9Tons { get; set; }
        public double? Day10Tons { get; set; }
        public double? Day11Tons { get; set; }
        public double? Day12Tons { get; set; }
        public double? Day13Tons { get; set; }
        public double? Day14Tons { get; set; }
        public double? Day15Tons { get; set; }
        public double? Day16Tons { get; set; }
        public double? Day17Tons { get; set; }
        public double? Day18Tons { get; set; }
        public double? Day19Tons { get; set; }
        public double? Day20Tons { get; set; }
        public double? Day21Tons { get; set; }
        public double? Day22Tons { get; set; }
        public double? Day23Tons { get; set; }
        public double? Day24Tons { get; set; }
        public double? Day25Tons { get; set; }
        public double? Day26Tons { get; set; }
        public double? Day27Tons { get; set; }
        public double? Day28Tons { get; set; }
        public double? Day29Tons { get; set; }
        public double? Day30Tons { get; set; }
        public double? Day31Tons { get; set; }
    }
}