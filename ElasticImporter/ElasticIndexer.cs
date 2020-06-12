using Nest;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ElasticImporter
{
    public class ElasticIndexer
    {
        ElasticClient client;
        public ElasticIndexer()
        {
            var settings = new ConnectionSettings(new Uri("http://localhost:9200"));
            client = new ElasticClient(settings);
        }
        public void IndexCollection(List<object> data,string indexName)
        {
            var bulkAllObservable = client.BulkAll(data, b => b
                                           .Index(indexName)
                                           .BackOffTime("30s")
                                           .BackOffRetries(2)
                                           .RefreshOnCompleted()
                                           .MaxDegreeOfParallelism(Environment.ProcessorCount)
                                           .Size(1000)
                                             )
                                           .Wait(TimeSpan.FromMinutes(15), next =>
                                           {
                                               Console.WriteLine($"{data.Count} data has indexed!");
                                           });
        }
    }
}
