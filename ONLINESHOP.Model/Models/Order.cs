﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ONLINESHOP.Model.Models
{
    [Table("Orders")]
    public class Order
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [Column(TypeName = "nvarchar"), MaxLength(256)]
        public string CustomerName { get; set; }

        [Required]
        [Column(TypeName = "nvarchar"), MaxLength(256)]
        public string CustomerAddress { get; set; }

        [Required]
        [Column(TypeName = "nvarchar"), MaxLength(256)]
        public string CustomerEmail { get; set; }

        [Required]
        [Column(TypeName = "nvarchar"), MaxLength(50)]
        public string CustomerMobile { get; set; }

        [Required]
        [Column(TypeName = "nvarchar")]
        public string CustomeeMessage { get; set; }

        [Column(TypeName = "nvarchar"), MaxLength(256)]
        public string PaymentMethod { get; set; }

        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "nvarchar"), MaxLength(50)]
        public string CreatedBy { get; set; }

        public bool? PaymentStatus { get; set; }

        [Required]
        public bool Status { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        [StringLength(128)]
        [Column(TypeName = "nvarchar")]
        public string CustomerId { set; get; }

        [ForeignKey("CustomerId")]
        public virtual ApplicationUser User { set; get; }
    }
}