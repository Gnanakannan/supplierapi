using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace supplierapi
{
    //Id, productCode, iconPicture, category, subCategory, name, nameEn, quantityMetric
    //, quantityMetricEn, quantitySecondMetric, quantityMeasure, quantityMeasureEn, productTags
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("productCode")]
        public string productCode { get; set; }

        [BsonElement("iconPicture")]
        public string iconPicture { get; set; }

        [BsonElement("name")]
        public string name { get; set; }

        [BsonElement("nameEn")]
        public string nameEn { get; set; }

        [BsonElement("category")]
        public string Category { get; set; }

        [BsonElement("subCategory")]
        public string SubCategory { get; set; }

        [BsonElement("quantityMetric")]
        public string quantityMetric { get; set; }

        [BsonElement("quantityMetricEn")]
        public string quantityMetricEn { get; set; }

        [BsonElement("quantitySecondMetric")]
        public string quantitySecondMetric { get; set; }

        [BsonElement("quantity")]
        public double quantity { get; set; }

        [BsonElement("productTags")]
        public string productTags { get; set; }
    }
}
