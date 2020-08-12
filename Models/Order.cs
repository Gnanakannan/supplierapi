using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace supplierapi
{
    public class Order
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("orderNumber")]
        public String orderNumber { get; set; }

        [BsonElement("storeId")]
        public String storeId { get; set; }        

        [BsonElement("shopper")]
        public Shopper shopper { get; set; }

        [BsonElement("deliveryAddress")]
        public ShopperAddress deliveryAddress { get; set; }

        [BsonElement("queueNumber")]
        public int queueNumber { get; set; }


        [BsonElement("status")]
        public String status { get; set; }


        [BsonElement("orderDateTime")]
        public DateTime orderDateTime { get; set; }


        [BsonElement("requestedDeliveryDate")]
        public DateTime requestedDeliveryDate { get; set; }


        [BsonElement("actualDeliveryDate")]
        public DateTime actualDeliveryDate { get; set; }


        [BsonElement("totalPrice")]
        public double totalPrice { get; set; }


        [BsonElement("orderType")]
        public String orderType { get; set; }


        [BsonElement("products")]
        public List<CartProduct> products { get; set; }

    }
}
