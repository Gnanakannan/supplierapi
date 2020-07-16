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

    public class StoreProfile
    {
        [BsonElement("name")]
        public string name { get; set; }
    }


    public class StoreProduct
    {
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
        public double quantityMeasure { get; set; }

        // [BsonElement("quantityMeasureEn")]
        // public string quantityMeasureEn { get; set; }

        [BsonElement("minQuantity")]
        public double minQuantity { get; set; }

        [BsonElement("maxQuantity")]
        public double maxQuantity { get; set; }

        [BsonElement("productPrice")]
        public double productPrice { get; set; }

        [BsonElement("priceCurrency")]
        public string priceCurrency { get; set; }

        [BsonElement("availablePacks")]
        public List<AvailablePack> availablePacks { get; set; }

    }

    public class AvailablePack
    {
        [BsonElement("measureName")]
        public string measureName { get; set; }

        [BsonElement("measureName")]
        public string measureNameEn { get; set; }

        [BsonElement("measureQuantity")]
        public double measureQuantity { get; set; }

        [BsonElement("price")]
        public double price { get; set; }
    }
}
