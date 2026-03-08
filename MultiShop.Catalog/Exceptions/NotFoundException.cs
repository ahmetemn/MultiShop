namespace MultiShop.Catalog.Exceptions;

/// <summary>
/// 404 Not Found - Kaynak bulunamadığında fırlatılır.
/// </summary>
public class NotFoundException : Exception
{
    public string? ResourceName { get; }

    public NotFoundException(string message) : base(message) { }

    public NotFoundException(string resourceName, string id)
        : base($"{resourceName} Not Found. (Id: {id})")
    {
        ResourceName = resourceName;
    }
}
