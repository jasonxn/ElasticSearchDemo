using ElasticSearchDemo.Elastic;
using ElasticSearchDemo.Repositories;
using ElasticSearchDemo.Services;
using Microsoft.Extensions.DependencyInjection;
using Nest;

var services = new ServiceCollection();


var client = ElasticSearchConfig.CreateClient("http://localhost:9200");
services.AddSingleton<IElasticClient>(client);
services.AddScoped<ProductRepository>();
services.AddScoped<ProductService>();

var provider = services.BuildServiceProvider();
var service = provider.GetRequiredService<ProductService>();


await service.AddSampleProductsAsync();
Console.WriteLine("\nEnter search term:");
var input = Console.ReadLine();
await service.SearchAsync(input!);
