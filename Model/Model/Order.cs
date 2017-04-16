using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Model
{
    [Table("Order")]
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int UserID { get; set; }

        [Required]
        public bool Status { get; set; }

        public DateTime Created { get; set; }

        [StringLength(200, ErrorMessage = "Nội dung tối đa {0} ký tự")]
        [Display(Name = "Nội dung")]
        public string Message { get; set; }

        public virtual IEnumerable<OrderDetails> OrderDetails { get; set; }
    }
}
