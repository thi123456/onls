using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ONLINESHOP.Model.Models
{
    [Table("Pages")]
    public class Page
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [Column(TypeName = "nvarchar"), MaxLength(256)]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "varchar"), MaxLength(256)]
        public string Alias { get; set; }

        public string Content { get; set; }

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
    }
}