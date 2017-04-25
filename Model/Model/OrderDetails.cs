using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Model
{
    [Table("OrderDetails")]
    public class OrderDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]        
        public int OrtherId { get; set; }

        [ForeignKey("OrtherId")]
        public virtual Order Orther { get; set; }

        [Required]
        public int Product_Id { get; set; }

        [ForeignKey("Product_Id")]
        public virtual Products Products { get; set; }
        
        [Required]
        [Display(Name = "Số lượng")]
        public int Quantity { get; set; }

        [Required]
        [Display(Name = "Giá")]
        public decimal Price { get; set; }
    }
}
