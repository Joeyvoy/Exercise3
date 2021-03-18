using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Exercise3.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required, DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy HH:mm:ss}")]
        public string CheckIn { get; set; }

        [Required, DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy HH:mm:ss}")]
        public string CheckOut { get; set; }

        [Required]
        [Range(1, 50)]
        public int RoomNumber { get; set; }

        [Required]
        public string EmailAddress { get; set; }

        [Required]
        public double Billing { get; set; }

    }
}
