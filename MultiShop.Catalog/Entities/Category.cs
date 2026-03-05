using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MultiShop.Catalog.Entities;
public class Category
{
    public Category(string categoryId , string categoryName)
    {
        CategoryId = categoryId;
        CategoryName = categoryName;
    }

    [BsonId]    
    [BsonRepresentation(BsonType.ObjectId)]
    public  string CategoryId  { get; set; }
    
    public  string CategoryName  { get; set; }

}