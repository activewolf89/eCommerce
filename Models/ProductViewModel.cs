using System.ComponentModel.DataAnnotations;

namespace eCommerce.Models
{
    public class ProductModelView
    {
        [Required]
        [MinLength(2)]
        public string ProductName{get;set;}
        [Required]
        [UrlAttribute]
        public string ImgSrc{get;set;}
        [Required]
        [MinLength(2)]
        public string Description{get;set;}
        [Required]
        [RangeAttribute(0, 100)]
        public int Quantity{get;set;}
        [Required]
        [RangeAttribute(0, 20000000, ErrorMessage = "Yo its too low or wayy to high")]
        public double Price{get;set;}
        
    }
}