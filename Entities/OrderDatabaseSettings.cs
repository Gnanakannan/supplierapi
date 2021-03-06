using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace supplierapi
{
    public class OrderDatabaseSettings : IOrderDatabaseSettings
    {
        public string OrdersCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IOrderDatabaseSettings
    {
        string OrdersCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
