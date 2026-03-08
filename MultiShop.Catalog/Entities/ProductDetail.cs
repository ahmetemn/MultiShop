namespace MultiShop.Catalog.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MultiShop.Catalog.Entities.Abstract;

public class ProductDetail:Base
{

    public string?  ProductDescription { get; set; }
    public string?  ProductInfo { get; set; }

    public string ProductId  { get; set; }
    
    [BsonIgnore]
    public Product Product  { get; set; }
    
}