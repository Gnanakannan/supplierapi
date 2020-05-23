using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace supplierapi
{
    public class Store
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("storeProfile")]
        public StoreProfile storeProfile { get; set; }

        [BsonElement("storeProducts")]
        public List<StoreProduct> storeProducts { get; set; }
    }

    public class StoreProfile {
        [BsonElement("name")]
        public string name { get; set; }
    }


    public class StoreProduct {
        [BsonElement("productCode")]
        public string productCode { get; set; }

        [BsonElement("iconPicture")]
        public string iconPicture { get; set; }

        [BsonElement("name")]
        public string name { get; set; }

        [BsonElement("nameEn")]
        public string nameEn { get; set; }
        
        [BsonElement("quantityMetric")]
        public string quantityMetric { get; set; }
        
        [BsonElement("quantityMetricEn")]
        public string quantityMetricEn { get; set; }
        
        [BsonElement("quantitySecondMetric")]
        public string quantitySecondMetric { get; set; }

        [BsonElement("quantityMeasure")]
        public string quantityMeasure { get; set; }

        [BsonElement("quantityMeasureEn")]
        public string quantityMeasureEn { get; set; }

        [BsonElement("productPrice")]
        public string productPrice { get; set; }

        [BsonElement("priceCurrency")]
        public string priceCurrency { get; set; }
    }
}
