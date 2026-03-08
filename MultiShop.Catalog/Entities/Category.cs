using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MultiShop.Catalog.Entities.Abstract;

namespace MultiShop.Catalog.Entities;
public class Category : Base
{
    public Category( string categoryName)
    {
        CategoryName = categoryName;
    }


    public  string CategoryName  { get; set; }

}