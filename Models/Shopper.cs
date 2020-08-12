using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace supplierapi
{
    public class Shopper
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("shopperId")]
        public String shopperId { get; set; }

        [BsonElement("firstName")]
        public String firstName { get; set; }

        [BsonElement("lastName")]
        public String lastName { get; set; }

        [BsonElement("nickName")]
        public String nickName { get; set; }

        [BsonElement("profileDP")]
        public String profileDP { get; set; }

        [BsonElement("primaryPhone")]
        public String primaryPhone { get; set; }

        [BsonElement("secondaryPhone")]
        public String secondaryPhone { get; set; }

        [BsonElement("primaryEmail")]
        public String primaryEmail { get; set; }

        [BsonElement("secondaryEmail")]
        public String secondaryEmail { get; set; }

        [BsonElement("gender")]
        public String gender { get; set; }

        [BsonElement("dob")]
        public DateTime dob { get; set; }

        [BsonElement("status")]
        public String status { get; set; }
    }

public class ShopperAddress
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("customAddressName")]
        public String customAddressName { get; set; }

        [BsonElement("shopperId")]
        public String shopperId { get; set; }

        [BsonElement("doorNumber")]
        public String doorNumber { get; set; }

        [BsonElement("floor")]
        public String floor { get; set; }

        [BsonElement("ApartmentNumber")]
        public String ApartmentNumber { get; set; }

        [BsonElement("streetName")]
        public String streetName { get; set; }

        [BsonElement("streetName2")]
        public String streetName2 { get; set; }

        [BsonElement("areaName")]
        public String areaName { get; set; }

        [BsonElement("city")]
        public String city { get; set; }

        [BsonElement("taluk")]
        public String taluk { get; set; }

        [BsonElement("district")]
        public String district { get; set; }

        [BsonElement("state")]
        public String state { get; set; }

        [BsonElement("country")]
        public String country { get; set; }

        [BsonElement("zipcode")]
        public String zipcode { get; set; }

        [BsonElement("status")]
        public String status { get; set; }
    }    
}
