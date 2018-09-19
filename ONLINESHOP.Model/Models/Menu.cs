using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ONLINESHOP.Model.Models
{
    [Table("Menus")]
    public class Menu
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [Column(TypeName = "nvarchar"), MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "nvarchar"), MaxLength(256)]
        public string URL { get; set; }

        public int? DisplayOrder { get; set; }

        [Column(TypeName = "nvarchar"), MaxLength(10)]
        public string Target { get; set; }

        [Required]
        public bool Status { get; set; }

        [Required]
        public int MenuGroupID { get; set; }

        [ForeignKey("MenuGroupID")]
        public virtual MenuGroup MenuGroup { get; set; }
    }
}