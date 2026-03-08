namespace MultiShop.Catalog.Exceptions;

/// <summary>
/// 400 Bad Request - Geçersiz istek (validasyon, hatalı parametre vb.)
/// </summary>
public class BadRequestException : Exception
{
    public BadRequestException(string message) : base(message) { }
}
