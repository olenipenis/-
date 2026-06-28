using Microsoft.EntityFrameworkCore;
using ShopTerminal.Data.Models;

namespace ShopTerminal.Data.Services;

public class OrderService
{
    private readonly AppDbContext _context;

    public OrderService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Order> CreateOrderAsync()
    {
        var order = new Order
        {
            CreatedAt = DateTime.Now
        };

        _context.Orders.Add(order);
        await _context.SaveChangesAsync();

        return order;
    }

    public async Task AddItemAsync(int orderId, int productId)
    {
        OrderItem item = new()
        {
            OrderId = orderId,
            ProductId = productId
        };

        _context.OrderItems.Add(item);
        await _context.SaveChangesAsync();
    }
}
