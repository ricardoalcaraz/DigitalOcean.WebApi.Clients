<p align="center">
  <img src="https://i.imgur.com/llqIpX6.png">
</p>
<h1 align="center">
  DigitalOcean API
</h1>
<p align="center">
  <a href="https://github.com/trmcnvn/DigitalOcean.API"><img alt="GitHub Actions status" src="https://github.com/trmcnvn/DigitalOcean.API/workflows/DigitalOcean.API%20CI/badge.svg"></a>
  <a href="https://www.nuget.org/packages/DigitalOcean.API"><img src="https://img.shields.io/nuget/v/DigitalOcean.API.svg"></a>
  <a href="https://app.fossa.com/projects/git%2Bgithub.com%2Ftrmcnvn%2FDigitalOcean.API?ref=badge_shield"><img src="https://app.fossa.com/api/projects/git%2Bgithub.com%2Ftrmcnvn%2FDigitalOcean.API.svg?type=shield"></a>
</p>

Forked implementation heavily inspired by DigitalOcean.API and modernized to target current APIs. The underlying core now uses HttpClient and System.Text.Json instead of RestSharp and Newtonsoft which are now deprecated. Current targets are .NET 7


## High Performance Async
Added cancellation tokens and leveraged high performance APIs like ValueTask to take advantage of the free upgrades of current versions of .NET

## Install

DigitalOcean.API is available for install from [NuGet](https://www.nuget.org/packages/DigitalOcean.API) and the [GitHub Package Registry](https://github.com/trmcnvn/DigitalOcean.API/packages).

```bash
dotnet add package DigitalOcean.API
```

## Example

```csharp
var builder = WebApplication.CreateDefaultBuilder(args)

builder.AddDigitalOcean();

var request = new Droplet {
  Name = "example.com",
  Region = "nyc3",
  Size = "s-1vcpu-1gb",
  Image = "ubuntu-16-04-x64",
  SshKeys = new List<object> { 107149 },
  Backups = false,
  Ipv6 = true,
  Tags = new List<string> { "web" }
};

Droplets.CreateAsync(request, token);
var droplet = await client.Droplets.Create(request);
```

## Documentation

Check out [DigitalOcean's documentation](https://developers.digitalocean.com/documentation/v2/#introduction) of their API to see all possible interactions.

## License

This project is licensed under the GNU General Public License Version 3(GPLv3) - see the LICENSE.md file for details.
