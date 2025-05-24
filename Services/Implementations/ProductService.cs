using Credit_Management_System.Entities;
using Credit_Management_System.Models;
using Credit_Management_System.Repositories.Interfaces;
using Credit_Management_System.Services.Interfaces;

namespace Credit_Management_System.Services.Implementations
{
    public class ProductService(IGenericRepository<Product> productRepository) : IProductService
    {
        private readonly IGenericRepository<Product> _productRepository = productRepository;

        public async Task CreateAsync(ProductVM productVM)
        {
            var product = new Product
            {
                Name = productVM.Name,
                ImageUrl = productVM.ImageUrl,
                Price = productVM.Price,
                CategoryId = productVM.CategoryId
            };
            await _productRepository.AddAsync(product);
            await _productRepository.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                return false;
            }
            _productRepository.Delete(product);
            await _productRepository.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<ProductVM>> GetAllAsync()
        {
            var products = await _productRepository.GetAllAsync();
            return products.Select(p => new ProductVM
            {
                Id = p.Id,
                Name = p.Name,
                ImageUrl = p.ImageUrl,
                Price = p.Price,
                CategoryId = p.CategoryId
            });
        }

        public async Task<ProductVM?> GetByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                return null;
            }
            return new ProductVM
            {
                Id = product.Id,
                Name = product.Name,
                ImageUrl = product.ImageUrl,
                Price = product.Price,
                CategoryId = product.CategoryId
            };
        }

        public async Task<bool> UpdateAsync(ProductVM productVM)
        {
            var product = await _productRepository.GetByIdAsync(productVM.Id);
            if (product == null)
            {
                return false;
            }
            product.Name = productVM.Name;
            product.ImageUrl = productVM.ImageUrl;
            product.Price = productVM.Price;
            product.CategoryId = productVM.CategoryId;
            _productRepository.Update(product);
            await _productRepository.SaveChangesAsync();
            return true;
        }
    }
}
