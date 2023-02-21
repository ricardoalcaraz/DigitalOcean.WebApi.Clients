using Microsoft.AspNetCore.Builder;

namespace DigitalOcean.Clients.Tests;

public class ClientBaseTest<T> where T : class {
    protected T Client;

    [SetUp]
    public void Initialize()
    {
        var app = WebApplication.CreateBuilder();
        app.AddDigitalOcean()
            .Logging.AddConsole().AddFilter(f => f == LogLevel.Debug);
        Client = app.Build().Services.GetRequiredService<T>();
    }
}
