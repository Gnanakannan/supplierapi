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

        [BsonElement("category")]
        public string category { get; set; }

        [BsonElement("subCategory")]
        public string subCategory { get; set; }

        [BsonElement("productTags")]
        public string productTags { get; set; }

        [BsonElement("quantityMetric")]
        public string quantityMetric { get; set; }

        [BsonElement("quantityMetricEn")]
        public string quantityMetricEn { get; set; }

        [BsonElement("quantitySecondMetric")]
        public string quantitySecondMetric { get; set; }

        [BsonElement("quantity")]
        public double quantity { get; set; }

        [BsonElement("minQuantity")]
        public double minQuantity { get; set; }

        [BsonElement("maxQuantity")]
        public double maxQuantity { get; set; }

        [BsonElement("price")]
        public double price { get; set; }

        [BsonElement("currency")]
        public string currency { get; set; }

        [BsonElement("availablePacks")]
        public List<AvailablePack> availablePacks { get; set; }
    }

    public class CartProduct
    {
        [BsonElement("itemSquence")]
        public int itemSquence { get; set; }

        [BsonElement("productCode")]
        public String productCode { get; set; }

        [BsonElement("quantityMetric")]
        public string quantityMetric { get; set; }

        [BsonElement("quantityMetricEn")]
        public string quantityMetricEn { get; set; }

        [BsonElement("quantitySecondMetric")]
        public string quantitySecondMetric { get; set; }

        [BsonElement("quantity")]
        public double quantity { get; set; }

        [BsonElement("price")]
        public double price { get; set; }

        [BsonElement("currency")]
        public String currency { get; set; }

        [BsonElement("cartQuantity")]
        public double cartQuantity { get; set; }
    }

    public class AvailablePack
    {
        [BsonElement("measureName")]
        public string measureName { get; set; }

        [BsonElement("measureNameEn")]
        public string measureNameEn { get; set; }

        [BsonElement("quantity")]
        public double quantity { get; set; }

        [BsonElement("price")]
        public double price { get; set; }
    }
}
