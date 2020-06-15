using ElasticImporter.Indexers;
using ElasticImporter.Model;
using Nest;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ElasticImporter
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args == null || args.Length < 2)
            {
                Console.WriteLine("Please Specify Input Json Path and Model Name");
                return;
            }

            string inputPath = args[0];
            var jsonString = File.ReadAllText(inputPath);
            var model = args[1];
            var indexer = new IndexerFactory().CreateIndexer(model);
            if (indexer == null)
            {
                Console.WriteLine("Model Argument is incorrect!!");
                return;
            }
            indexer.IndexJson(jsonString);

            Console.ReadKey();
        }
    }
}
