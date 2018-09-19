using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ONLINESHOP.Model.Models
{
    [Table("MenuGroups")]
    public class MenuGroup
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        [Column(TypeName = "nvarchar")]
        public string Name { get; set; }

        public virtual ICollection<Menu> Menus { get; set; }
    }
}