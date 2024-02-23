using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _context;

        public OrderService(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<Order> GetOrder()
        {
            return await _context.Orders
                .OrderByDescending(order => order.Price * order.Quantity)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Order>> GetOrders()
        {
            return await _context.Orders
                .Where(order => order.Quantity > 10)
                .ToListAsync();
        }
    }
}
