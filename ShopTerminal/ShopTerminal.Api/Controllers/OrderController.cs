using Microsoft.AspNetCore.Mvc;
using ShopTerminal.Data.Services;

namespace ShopTerminal.Api.Controllers;

[ApiController]
[Route("api/orders")]
public class OrderController : ControllerBase
{
    private readonly OrderService _orders;

    public OrderController(OrderService orders)
    {
        _orders = orders;
    }

    // Создать новый заказ
    [HttpPost("create")]
    public async Task<IActionResult> CreateOrder()
    {
        var order = await _orders.CreateOrderAsync();
        return Ok(order.Id);
    }

    // Добавить товар в заказ
    [HttpPost("{orderId}/add/{productId}")]
    public async Task<IActionResult> AddItem(int orderId, int productId)
    {
        await _orders.AddItemAsync(orderId, productId);
        return Ok();
    }
}
