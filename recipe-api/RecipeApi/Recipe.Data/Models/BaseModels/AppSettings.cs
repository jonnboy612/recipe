namespace Recipe.Data.Models;

public class AppSettings
{
    /// <summary>
    /// The app secret.
    /// </summary>
    public string Secret { get; set; } = string.Empty;

    /// <summary>
    /// The token issuer.
    /// </summary>
    public string Issuer { get; set; } = string.Empty;

    /// <summary>
    /// The token audience.
    /// </summary>
    public string Audience { get; set; } = string.Empty;

    /// <summary>
    /// When access expires.
    /// </summary>
    public int AccessExpiration { get; set; }

    /// <summary>
    /// When to refresh expiration.
    /// </summary>
    public int RefreshExpiration { get; set; }
}