using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ONLINESHOP.Model.Models
{
    [Table("Feedbacks")]
    public class Feedback
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [MaxLength(250)]
        public string Name { get; set; }

        [MaxLength(250)]
        public string Email { get; set; }

        public DateTime CreatedDate { get; set; }

        public string Message { get; set; }

        [Required]
        public bool Status { get; set; }
    }
}