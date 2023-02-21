// See https://aka.ms/new-console-template for more information

using DigitalOcean.Client.Extensions;
using Microsoft.Extensions.FileProviders;

Console.WriteLine("Hello, World!");

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(0, opt =>
    {
        opt.UseHttps(opt => opt.ServerCertificateSelector = (context, s) =>
        {

            return null;
        });
    });
});

var app = builder.Build();

var nugetDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),".local", "nuget");
app.UseFileServer(new FileServerOptions
{
    RequestPath = "/nuget",
    FileProvider = new PhysicalFileProvider(nugetDir),
    RedirectToAppendTrailingSlash = true,
    EnableDirectoryBrowsing = true,
    EnableDefaultFiles = false,
    StaticFileOptions =
    {
        ServeUnknownFileTypes = true,
        DefaultContentType = "application/octet-stream"
    }
});
app.Run();