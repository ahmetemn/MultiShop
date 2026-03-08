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
    


    public string? Image1 { get; set; }
    public string? Image2 { get; set; }

    public string? Image3 { get; set; }

    public string ProductId  { get; set; }
    [BsonIgnore]
    public Product?  Product { get; set; }
}