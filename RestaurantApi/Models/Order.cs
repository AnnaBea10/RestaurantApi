using System;

namespace RestaurantApi.Models
{
    public class Order(){

        private long Id {get; set;}
        private double Price  {get; set;}
        private DateTimeOffset Moment {get; set;}
        private OrderStatus orderStatus {get; set;}

        private Payment payment {get; set;}

        private Payment setPayment(Payment payment)
        {
            if(payment == null){
            throw new NullReferenceException();    
            }
            return payment;
        }
    }
}