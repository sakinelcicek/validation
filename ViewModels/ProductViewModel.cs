using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ders2.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage="Ürün isim alanı boş geçilmemelidir!")]
        public string? Name { get; set; }
        [Required(ErrorMessage="Fiyat alanı boş geçilmemelidir!")]
        public decimal Price { get; set; }
        [Required(ErrorMessage="Stok alanı boş geçilmemelidir!")]
        public int Stock { get; set; }
        public bool isPuslish { get; set; }
        public int ExpireDate { get; set; }
        [Required(ErrorMessage="Ürün yayınlanma alanı boş geçilmemelidir!")]
        public string? Description { get; set; }
        [Required(ErrorMessage="Ürün rengi alanı boş geçilmemelidir!")]
        public string Color { get; set; }
        [Required(ErrorMessage="Ürün yayınlanma tarihi alanı boş geçilmemelidir!")]
        public DateTime? PublishDate { get; set; }
        
    }
}