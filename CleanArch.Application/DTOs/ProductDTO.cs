using CleanArch.Domain.Entities;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArch.Application.DTOs
{
    public class ProductDTO
    {
        [Required(ErrorMessage = "The name is required")]
        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get; private set; }

        [Required(ErrorMessage = "The description is required")]
        [MinLength(5)]
        [MaxLength(200)]
        public string Description { get; private set; }

        [Required(ErrorMessage = "The price is required")]
        [Column(TypeName = "decimal(18,2")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DataType(DataType.Currency)]
        [DisplayName("Price")]
        public decimal Price { get; private set; }

        [Required(ErrorMessage = "The stock is required")]
        [Range(1, 9999)]
        [DisplayName("Stock")]
        public int Stock { get; private set; }

        [MaxLength(250)]
        [DisplayName("Product Image")]
        public string Image { get; private set; }
        public int CategoryId { get; set; }

        [DisplayName("Categories")]
        public Category Category { get; set; }
    }
}
