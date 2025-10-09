using System.ComponentModel.DataAnnotations;

namespace Sales.API.DTOs
{
    public class CreateOrderRequestDto
    {
        [Required]
        [MinLength(1, ErrorMessage = "O pedido deve conter ao menos um item.")]
        public List<OrderItemDTO> OrderItems { get; set; }
    }
    
}