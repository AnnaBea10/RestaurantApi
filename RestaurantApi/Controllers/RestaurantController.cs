using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestaurantApi.Models;
using Microsoft.EntityFrameworkCore;
using RestaurantApi.Data;
using RestaurantApi.ViewModels;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace RestaurantApi.Controllers{

    [ApiController]
    [Route ("v1")]
    public class RestaurantController : ControllerBase{

        [HttpGet]
        [Route("orders/{id}")]
        public async Task<IActionResult> getByIdAsync(
        [FromServices] AppDbContext context,
        [FromRoute] long Id)
        {
            var orders = await context
            .Orders
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == Id);

            return orders == null
            ? NotFound()
            : Ok(orders);
        }

        [HttpPost ("orders")]
        public async Task<IActionResult> postAsync(
            [FromServices] AppDbContext context,
            [FromBody] CreateOrderViewModel model)
        {
            if(!ModelState.IsValid){
                return BadRequest();
            }

            var order = new Order
        {
            Name = model.Name,
            Price = model.Price,
        };

        try{
            await context.Orders.AddAsync(order);
            await context.SaveChangesAsync();
            return Created($"v1/todos/{order.Id}", order);
        }
        catch (Exception e){
            return BadRequest();
        }
    }
     
        [HttpPut ("orders/{Id}")]
        public async Task<IActionResult> putAsync(
            [FromServices] AppDbContext context,
            [FromBody] CreateOrderViewModel model,
            [FromRoute] long Id)
        {
            if(!ModelState.IsValid){
                return BadRequest();
            }

            var order = await context.Orders.FirstOrDefaultAsync(x => x.Id == Id);

            if(order == null){
                return NotFound();
            }

            try{
                order.Name = model.Name;

                context.Orders.Update(order);
                await context.SaveChangesAsync();
                return Ok(order);
            }
            catch (Exception e){
                return BadRequest();
            }
        }

        [HttpDelete ("orders/{Id}")]
        public async Task<IActionResult> DeleteAsync(
            [FromServices] AppDbContext context,
            [FromRoute] long Id )
        {
            var order = await context.Orders.FirstOrDefaultAsync(x => x.Id == Id);

            try{
                context.Orders.Remove(order);
                await context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e){
                return BadRequest();
            }
        }
    }
}
