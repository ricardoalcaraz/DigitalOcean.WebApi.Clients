using System.Net.Http.Headers;
using DigitalOcean.Clients;
using DigitalOcean.Clients.Clients;
using DigitalOcean.Clients.Http;
using DigitalOcean.Clients.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace DigitalOcean.Client.Extensions;

public static class WebApplicationExtensions {
    public static IServiceCollection AddDigitalOcean(this IServiceCollection builder, Action<DigitalOceanApiOptions>? configureOptions = null) {
        DigitalOceanApiOptions digitalOceanOptions = new ();
        configureOptions?.Invoke(digitalOceanOptions);
        builder.AddHttpClient<IConnection, Connection>("DigitalOcean")
            .ConfigureHttpClient((sp, c) => {
                c.BaseAddress = new Uri(DigitalOceanClient.DIGITAL_OCEAN_API_URL);
                var options = sp.GetRequiredService<IOptions<DigitalOceanApiOptions>>().Value;
                c.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", options.ApiKey);
            });

        builder.AddTransient<IAccountClient, AccountClient>();
        builder.AddTransient<IActionsClient, ActionsClient>();
        builder.AddTransient<IDomainsClient, DomainsClient>();
        builder.AddTransient<IBalanceClient, BalanceClient>();
        builder.AddTransient<IDropletsClient, DropletsClient>();
        builder.AddTransient<IDomainRecordsClient, DomainRecordsClient>();
        builder.AddTransient<IReservedIpsClient, ReservedIpsClient>();
        builder.AddTransient<IKeysClient, KeysClient>();
        builder.AddTransient<ICertificatesClient, CertificatesClient>();
        builder.AddTransient<IFloatingIpActionsClient, FloatingIpActionsClient>();
        return builder;
    }
    
    /// <summary>
    /// Add all required services needed to use digital ocean client
    /// </summary>
    public static WebApplicationBuilder AddDigitalOcean(this WebApplicationBuilder builder, Action<DigitalOceanApiOptions>? config = null) {
        builder.Services.AddDigitalOcean();
        builder.Services.AddOptions<DigitalOceanApiOptions>()
            .BindConfiguration("DigitalOcean");

        return builder;
    }
    
}

