using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Product
    {
        [Key]  
        public int Id { get; set; }
        [Required]

        [Display(Name = "Ürün Adı")]
        public string ProductName { get; set; }


        [Display(Name = "Açıklama")]
        public string ProductDesc { get; set; }

        [Display(Name = "Stok")]
        public int Stock { get; set; }

        [Display(Name = "Fiyat")]
        public int Price { get; set; }

        public int CategoryId { get; set; }
        public string Img { get; set; }

        [Display(Name = "Kategori")]
        public virtual Category category { get; set; }
    }
}
