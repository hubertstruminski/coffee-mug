using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeMug.Dto
{
    public class ProductCreateRequestDto
    {
        [StringLength(100, ErrorMessage = "Name length can't be more than 100."), Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        public decimal Price { get; set; }
    }
}
