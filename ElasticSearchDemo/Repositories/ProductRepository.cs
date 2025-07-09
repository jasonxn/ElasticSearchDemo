using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElasticSearchDemo.Models;
using Nest;

namespace ElasticSearchDemo.Repositories
{
    internal class ProductRepository
    {
        private readonly IElasticClient _client;

        public ProductRepository(IElasticClient client)
        {
            _client = client;
        }

        public async Task IndexAsync(Product product)
        {
            var response = await _client.IndexDocumentAsync(product);

            if (!response.IsValid)
            {
                Console.WriteLine("Elasticsearch indexing error:");
                Console.WriteLine($"Status: {response.ApiCall?.HttpStatusCode}");
                Console.WriteLine($"Server Error: {response.ServerError?.Error?.Reason}");
                Console.WriteLine($"Debug Info: {response.DebugInformation}");
                throw new Exception($"Indexing failed: {response.ServerError?.Error?.Reason}");
            }
        }


        public async Task<IEnumerable<Product>> SearchAsync(string keyword)
        {
            var response = await _client.SearchAsync<Product>(s => s
                .Query(q => q
                    .Match(m => m
                        .Field(f => f.Description)
                        .Query(keyword)
                    )
                )
            );

            return response.Documents;
        }
    }
}
