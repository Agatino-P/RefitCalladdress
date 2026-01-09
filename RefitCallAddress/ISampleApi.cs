using Refit;

namespace RiderCallAddress;

public interface ISampleApi
{
    HttpClient Client { get; }
    
    [Get("/sample")]
    Task<ApiResponse<WhoCares>> GetSampleAsync(string fromQuery);
}

public record WhoCares(string FirstName, string LastName);