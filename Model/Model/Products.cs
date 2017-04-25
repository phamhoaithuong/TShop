using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Model
{
    [Table("Products")]
    public class Products
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Tên sản phẩm")]
        [StringLength(30, ErrorMessage = "Tên sản phẩm tối đa {0} ký tự")]
        public String Name { get; set; }

        [Required]
        [Display(Name = "Mã sản phẩm")]
        public string Code { get; set; }

        public string Video { get; set; }

        public int Vender_Id { get; set; }

        [ForeignKey("Vender_Id")]
        public virtual Vender Vender { get; set; }

        public int Category_Id { get; set; }

        [ForeignKey("Category_Id")]
        public virtual Categories Categories { get; set; }

        [Required]
        [Display(Name = "Tổng quát")]
        public string OverView { get; set; }

        [Required]
        [Display(Name = "Thông tin chi tiết")]
        public string Describe { get; set; }

        [Required]
        [Display(Name = "Giá")]
        public decimal Price { get; set; }

        [Display(Name = "Giá cũ")]
        public decimal? OldPrice { get; set; }

        [Required]
        [Display(Name = "Kích thước")]
        public int? Length { get; set; }

        [Display(Name = "Chiết khấu")]
        public int? Discount { get; set; }

        [Display(Name = "Trạng thái")]
        public bool Status { get; set; }

        [Required]
        [Display(Name = "Hình sản phẩm")]
        public string Image { get; set; }

        [Required]
        public DateTime Created { get; set; }

        [Display(Name = "Lượt xem")]
        public int? View { get; set; }

        public string Tags { get; set; }
    }
}
