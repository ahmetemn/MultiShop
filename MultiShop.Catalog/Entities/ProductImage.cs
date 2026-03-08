namespace MultiShop.Catalog.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MultiShop.Catalog.Entities.Abstract;

public class ProductImage:Base
{

    public ProductImage(  string productId)
    {

        ProductId = productId;
    }



    public List<string> Images { get; set; } = new();

    public string ProductId  { get; set; }
    [BsonIgnore]
    public Product?  Product { get; set; }
}