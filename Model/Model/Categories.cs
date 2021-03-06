﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Model
{
    [Table("Categories")]
    public class Categories
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Tên danh mục")]
        [StringLength(20, ErrorMessage = "Tên danh mục tối đa {0} ký tự")]
        public string Name { get; set; }

        [Display(Name = "Danh mục con")]
        public int? ParentId { get; set; }
        public virtual IEnumerable<Products> Products { get; set; }

    }
}
