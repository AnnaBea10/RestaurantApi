using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore; 

namespace RestaurantApi.Models
{
    public class Order{
        
        [Key]
        public long Id {get; set;}

        public string Name {get; set;}
        public double Price  {get; set;}

        public DateTime Date { get; set; } = DateTime.Now;

        private Payment? Payment {get; set;}

        private OrderStatus OrderStatus {get; set;}
    }
}