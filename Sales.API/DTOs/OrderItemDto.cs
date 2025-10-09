using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sales.API.DTOs
{
    public class OrderItemDTO
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        [Range(1, 100, ErrorMessage = "Quantidade deve ser entre 1 e 100")]
        public int Quantity { get; set; }
        
    }
}