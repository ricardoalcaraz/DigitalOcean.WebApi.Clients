using System.ComponentModel.DataAnnotations;

namespace DigitalOcean.Clients;

public record DigitalOceanApiOptions {

    private CancellationTokenSource _stoppingTokenSource = new();
    public bool IsEnabled { get; set; }

    [Required]
    public string? ApiKey { get; set; }

    public CancellationToken StoppingToken => _stoppingTokenSource.Token;
    public CancellationTokenSource SetStoppingToken(CancellationToken token) => _stoppingTokenSource = CancellationTokenSource.CreateLinkedTokenSource(token);
}