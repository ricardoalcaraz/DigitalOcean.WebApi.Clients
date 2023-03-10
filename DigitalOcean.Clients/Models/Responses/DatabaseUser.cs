namespace DigitalOcean.Clients.Models.Responses;

public class DatabaseUser {
    /// <summary>
    /// The name of a database user.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// A string representing the database user's role. The value will be either "primary" or "normal".
    /// </summary>
    public string Role { get; set; }

    /// <summary>
    /// A randomly generated password for the database user.
    /// </summary>
    public string Password { get; set; }

    /// <summary>
    /// An object containing additional configuration details for MySQL clusters.
    /// </summary>
    [JsonPropertyName("mysql_settings")]
    public MySqlSettings MySqlSettings { get; set; }
}
