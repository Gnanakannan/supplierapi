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


        [BsonElement("queueNumber")]
        public int queueNumber { get; set; }


        [BsonElement("orderStatus")]
        public String orderStatus { get; set; }


        [BsonElement("productItems")]
        public List<ShopProduct> productItems { get; set; }


        [BsonElement("orderDateTime")]
        public DateTime orderDateTime { get; set; }


        [BsonElement("totalPrice")]
        public double totalPrice { get; set; }


        [BsonElement("orderCustomerID")]
        public String orderCustomerID { get; set; }


        [BsonElement("orderType")]
        public String orderType { get; set; }
    }
}
