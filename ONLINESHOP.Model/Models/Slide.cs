using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ONLINESHOP.Model.Models
{
    [Table("Slides")]
    public class Slide
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [Column(TypeName = "nvarchar"), MaxLength(256)]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar"), MaxLength(256)]
        public string Image { get; set; }

        public string Description { get; set; }

        public string Content { get; set; }

        [Column(TypeName = "nvarchar"), MaxLength(256)]
        public string URL { get; set; }

        public int? DisplayOrder { get; set; }

        [Required]
        public bool Status { get; set; }
    }
}