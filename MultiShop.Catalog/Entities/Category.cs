using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MultiShop.Catalog.Entities;
public class Category : IEntity
{
    public Category(string id , string categoryName)
    {
        Id = id;
        CategoryName = categoryName;
    }


    public  string CategoryName  { get; set; }

}