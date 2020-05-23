using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace supplierapi
{
    public class StoreDatabaseSettings : IStoreDatabaseSettings
    {
        public string StoresCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IStoreDatabaseSettings
    {
        string StoresCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
