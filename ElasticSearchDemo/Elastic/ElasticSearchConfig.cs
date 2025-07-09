using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nest;

namespace ElasticSearchDemo.Elastic
{
    internal class ElasticSearchConfig
    {
        public static IElasticClient CreateClient(string url)
        {
            var settings = new ConnectionSettings(new Uri(url))
                .DefaultIndex("products")
                .EnableDebugMode();
            return new ElasticClient(settings);
        }
    }
}
