using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Model
{
    [Table("Menu")]
    public class Menu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50,ErrorMessage ="Tên menu tối đa {0} kí tự")]
        public string Name { get; set; }

        [Required]
        [StringLength(300, ErrorMessage = "TURL tối đa {0} kí tự")]
        public string URL { get; set; }

        public int? DisplayOrder { get; set; }

        [Required]
        public int GroupId { get; set; }

        [ForeignKey("GroupId")]
        public virtual MenuGroup MenuGroup { get; set; }


    }
}
