using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PipeStore.Models
{
    public class Customer
    {
        /// <summary>
        /// This field represents a unique key.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage = "Customer is required")]
        [StringLength(60, MinimumLength = 2, ErrorMessage = "Customer's name shold be in range 2-60 symbols")]
        [DisplayName("Customer")]
        public string Contacts { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<Order> Orders { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Customer()
        {
            Orders = new List<Order>();
        }
    }
}