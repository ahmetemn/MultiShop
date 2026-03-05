using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MultiShop.Catalog.Entities;

public class Product
{

    public Product(string productId)
    {
        ProductId = productId;
    }
  
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public  string ProductId   { get; set; }
    public string ProductName { get; set; }
    public decimal Price { get; set; }
    public string  ProductImageUrl { get; set; }
    public string ProductDescription { get; set; }

    public string  CategoryId { get; set; }

  
    //“Bu property MongoDB’ye kaydedilmesin ve MongoDB’den okunmasın.”
    [BsonIgnore]
    public Category Category  { get; set; }
    
  
}