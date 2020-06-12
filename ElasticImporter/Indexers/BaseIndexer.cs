using Nest;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElasticImporter.Indexers
{
    public abstract class BaseIndexer
    {
        protected ElasticClient client = null;
        protected JsonSerializerSettings jsonSerializerSettings;
        public BaseIndexer()
        {
            var settings = new ConnectionSettings(new Uri("http://localhost:9200"));
            client = new ElasticClient(settings);
            jsonSerializerSettings = new JsonSerializerSettings();
            jsonSerializerSettings.MissingMemberHandling = MissingMemberHandling.Ignore;
        }
        public abstract void IndexJson(string jsonString);
    }
}
