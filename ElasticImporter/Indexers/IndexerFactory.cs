using System;
using System.Collections.Generic;
using System.Text;

namespace ElasticImporter.Indexers
{
    public class IndexerFactory
    {
        private  Dictionary<string, BaseIndexer> indexers = new Dictionary<string, BaseIndexer>();
        public IndexerFactory()
        {
            indexers.Add("City", new CityIndexer());
        }
        public  BaseIndexer CreateIndexer(string modelName)
        {
            if(indexers.ContainsKey(modelName))
               return indexers[modelName];
            return null;
        }
    }
}
