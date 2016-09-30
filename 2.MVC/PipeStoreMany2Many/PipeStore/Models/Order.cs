using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PipeStore.Models
{
    public class Order
    {
        /// <summary>
        /// This field represents a unique key.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "Order Title")]
        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Title { get; set; }

        /// <summary>
        /// 
        /// </summary>
        //[Display(Name = "Release")]
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        //public DateTime OpeningDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? CustomerId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Customer Customer { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<Pipe> Pipes { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Order()
        {
            Pipes = new List<Pipe>();
        }
    }
}