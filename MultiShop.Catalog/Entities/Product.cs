using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MultiShop.Catalog.Entities.Abstract;

namespace MultiShop.Catalog.Entities;

public class Product :Base
{
    public string ProductName { get; set; }
    public decimal Price { get; set; }
    public string  ProductImageUrl { get; set; }
    public string ProductDescription { get; set; }
    public string  CategoryId { get; set; }
 
    //“Bu property MongoDB’ye kaydedilmesin ve MongoDB’den okunmasın.”
    [BsonIgnore]
    public Category Category  { get; set; }
    
  
}