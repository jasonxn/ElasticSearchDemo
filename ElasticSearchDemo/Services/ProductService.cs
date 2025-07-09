using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElasticSearchDemo.Models;
using ElasticSearchDemo.Repositories;

namespace ElasticSearchDemo.Services
{
    internal class ProductService
    {
        private readonly ProductRepository _repo;

        public ProductService(ProductRepository repo)
        {
            _repo = repo;
        }

        public async Task AddSampleProductsAsync()
        {
            var products = new[]
            {
            new Product { Id = 1, Name = "Laptop", Description = "Gaming laptop with RTX graphics" },
            new Product { Id = 2, Name = "Smartphone", Description = "5G phone with AMOLED display" },
            new Product { Id = 3, Name = "Headphones", Description = "Noise-cancelling headphones" }
        };

            foreach (var p in products)
                await _repo.IndexAsync(p);
        }

        public async Task SearchAsync(string keyword)
        {
            var results = await _repo.SearchAsync(keyword);
            foreach (var p in results)
                Console.WriteLine($"- {p.Name}: {p.Description}");
        }
    }
}
