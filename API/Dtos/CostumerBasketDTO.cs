using Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class CostumerBasketDTO
    {
        [Required]
        public string Id { get; set; }
        public List<BasketItemsDTO> Items { get; set; } 
    }
}
