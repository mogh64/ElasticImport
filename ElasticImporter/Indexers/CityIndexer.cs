using ElasticImporter.Model;
using Nest;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElasticImporter.Indexers
{
    public class CityIndexer :BaseIndexer
    {
        
        public CityIndexer()
            :base()
        {
            
        }       
        public override void IndexJson(string jsonString)
        {
            var cityInfoList = JsonConvert.DeserializeObject<List<CityInfo>>(jsonString, jsonSerializerSettings);
            var bulkAllObservable = client.BulkAll(cityInfoList, b => b
                                              .Index("cities")
                                              .BackOffTime("30s")
                                              .BackOffRetries(2)
                                              .RefreshOnCompleted()
                                              .MaxDegreeOfParallelism(Environment.ProcessorCount)
                                              .Size(1000)
                                                )
                                              .Wait(TimeSpan.FromMinutes(15), next =>
                                              {
                                                  Console.WriteLine($"{cityInfoList.Count} data has indexed!");
                                              });
        }
    }
}
