using BackendTest.DTOs;
using BackendTest.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendTest.Services
{
    public class ProductsService : IProductsService
    {
        private readonly AppDbContext _context;

        public ProductsService(AppDbContext context) => _context = context;

        public async Task<OrderProduct> GetOrderByIdAsync(int orderId) => await _context.OrderProducts.Where(op => op.OrderId == orderId)/*.Include(p => p.Product)*/.FirstOrDefaultAsync();

        public async Task<IEnumerable<Product>> GetProductsByCustomerIdAsync(int customerId) => await _context.Orders.Where(o => o.CustomerId == customerId).Select(o => o.OrderProducts.Select(op => op.Product).Select(product => new Product()
        {

            Id = product.Id,
            Name = product.Name,
            Price = product.Price

        })).FirstOrDefaultAsync();

        public async Task<int> AddProductAsync(ProductDTO productDTO)
        {
            var _product = new Product()
            {
                Name = productDTO.Name,
                Price = productDTO.Price
            };

            await _context.Products.AddAsync(_product);
            return await _context.SaveChangesAsync();
        }
    }
}
