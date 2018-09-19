using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
namespace ONLINESHOP.Model.Models
{
    [Table("Posts")]
    public class Post
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
        public int PostCategoryID { get; set; }

        [Column(TypeName = "nvarchar"), MaxLength(256)]
        public string Image { get; set; }

        public string Description { get; set; }

        public string Content { get; set; }

        public bool? HomeFlag { get; set; }

        public bool? HotFlag { get; set; }

        public int? ViewCount { get; set; }

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

        [ForeignKey("PostCategoryID")]
        public virtual PostCategory Postcategory { get; set; }

       
    }
}