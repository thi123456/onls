using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ONLINESHOP.Model.Models
{
    [Table("Products")]
    public class Product
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [Column(TypeName = "nvarchar"), MaxLength(256)]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "varchar"), MaxLength(256)]
        public string Alias { get; set; }

        [Required]
        public int ProductCategoryID { get; set; }

        [Column(TypeName = "nvarchar"), MaxLength(256)]
        public string Image { get; set; }

        [Column(TypeName = "XML")]
        public string MoreImages { get; set; }

        public decimal Price { get; set; }

        public decimal? PromotionPrice { get; set; }

        public int? Warranty { get; set; }

        public string Description { get; set; }

        public string Content { get; set; }

        public bool? HomeFlag { get; set; }

        public bool? HotFlag { get; set; }

        public int? ViewCount { get; set; }

        public string Tabs { get; set; }

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

        public int Quantity { get; set; }

        [ForeignKey("ProductCategoryID")]
        public virtual ProductCategory ProductCategory { get; set; }
    }
}