using BackendTest.DTOs;
using BackendTest.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackendTest.Services
{
    public interface IProductsService
    {
        Task<OrderProduct> GetOrderByIdAsync(int orderId);
        Task<IEnumerable<Product>> GetProductsByCustomerIdAsync(int customerId);
        Task<int> AddProductAsync(ProductDTO productDTO);
    }
}