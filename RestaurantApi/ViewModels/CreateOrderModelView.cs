using System.ComponentModel.DataAnnotations;
using RestaurantApi.Migrations;

namespace RestaurantApi.ViewModels
{
    public class CreateOrderViewModel
    {
        [Required]
        public string Name { get; set;}
        public double Price {get; set;}
    }
}