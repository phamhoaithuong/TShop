using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Table("Vender")]
    public class Vender
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Tên nhà cung cấp")]
        [StringLength(20, ErrorMessage = "Địa chỉ tối đa {0} ký tự")]
        public String Name { get; set; }

        [Required]
        [Display(Name = "Hình đại diện")]
        public string Image { get; set; }

        public virtual IEnumerable<Products> Products { get; set; }
    }
}
