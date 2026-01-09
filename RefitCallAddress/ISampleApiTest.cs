using Refit;
using Xunit.Abstractions;

namespace RiderCallAddress;

public class ISampleApiTest
{
    private readonly ITestOutputHelper _output;

    public ISampleApiTest(ITestOutputHelper output)
    {
        _output = output;
    }

    [Fact]
    public async Task Test1()
    {
        UrlTunnelHandler urlTunnelHandler = new UrlTunnelHandler();
        HttpClient client = new HttpClient(urlTunnelHandler)
        {
            BaseAddress = new Uri("https://api.example.com")
        };

        ISampleApi api = RestService.For<ISampleApi>(client);
        _output.WriteLine(api.Client.BaseAddress?.ToString());

        try
        {
            var response = await api.GetSampleAsync("fromQ");
            _output.WriteLine(response.RequestMessage?.RequestUri?.ToString());

        }
        catch (Exception e)
        {
            _output.WriteLine(e.Message);
        }
    }
}