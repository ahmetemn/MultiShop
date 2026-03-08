namespace MultiShop.Catalog.Common;

/// <summary>
/// Tüm API cevaplarında tutarlı format (200, 201, 4xx, 5xx).
/// </summary>
public class ApiResponse<T>
{
    public int StatusCode { get; set; }
    public bool IsSuccess { get; set; }
    public string? Message { get; set; }
    public T? Data { get; set; }
    public List<string>? Errors { get; set; }

    public static ApiResponse<T> Success(T? data, string? message = null, int statusCode = 200)
    {
        return new ApiResponse<T>
        {
            StatusCode = statusCode,
            IsSuccess = true,
            Message = message ?? "Operation Successful.",
            Data = data
        };
    }

    public static ApiResponse<T> Fail(string message, int statusCode = 400, List<string>? errors = null)
    {
        return new ApiResponse<T>
        {
            StatusCode = statusCode,
            IsSuccess = false,
            Message = message,
            Errors = errors
        };
    }
}

/// <summary>
/// Data taşımayan cevaplar için (örn. Create sonrası sadece mesaj).
/// </summary>
public class ApiResponse
{
    public int StatusCode { get; set; }
    public bool IsSuccess { get; set; }
    public string? Message { get; set; }
    public List<string>? Errors { get; set; }

    public static ApiResponse Success(string? message = null, int statusCode = 200)
    {
        return new ApiResponse
        {
            StatusCode = statusCode,
            IsSuccess = true,
            Message = message ?? "Operation Successful."
        };
    }

    public static ApiResponse Fail(string message, int statusCode = 400, List<string>? errors = null)
    {
        return new ApiResponse
        {
            StatusCode = statusCode,
            IsSuccess = false,
            Message = message,
            Errors = errors
        };
    }
}
