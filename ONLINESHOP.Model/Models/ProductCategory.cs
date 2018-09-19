using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ONLINESHOP.Model.Models
{
    [Table("ProductCategories")]
    public class ProductCategory
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [Column(TypeName = "nvarchar"), MaxLength(256)]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "varchar"), MaxLength(256)]
        public string Alias { get; set; }

        public string Description { get; set; }

        public int? PatentID { get; set; }

        public int? DisplayOrder { get; set; }

        [Column(TypeName = "nvarchar"), MaxLength(256)]
        public string Image { get; set; }

        public bool? HomeFlag { get; set; }

        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "nvarchar"), MaxLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        [Column(TypeName = "nvarchar"), MaxLength(50)]
        public string UpdatedBy { get; set; }

        [Column(TypeName = "nvarchar"), MaxLength(256)]
        public string MetaKeyword { get; set; }

        [Column(TypeName = "nvarchar"), MaxLength(256)]
        public string MetaDescription { get; set; }

        [Required]
        public bool Status { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}